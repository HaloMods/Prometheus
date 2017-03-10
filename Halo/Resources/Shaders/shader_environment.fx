// shader_environment.fx - provides a technique for drawing an environment shader
// written by SwampFox

// fog variables
float fogStart, fogEnd, fogDensity;
// texture scales
float bumpScale, detailAScale, detailBScale, microDetailScale, glowScale;
// modulates environment maps depending on view angle
float parallelShininess, perpendicularShininess;
// current camera position
float4 cameraPosition;
// animation values
float primaryAnimationValue, secondaryAnimationValue, plasmaAnimationValue, uAnimationValue, vAnimationValue;
// animation colors
float4 primaryAnimationColor, secondaryAnimationColor, plasmaAnimationColor;
// ambient light color
float4 ambientColor;
// transforms
float4x4 world, worldViewProjection;
// textures
texture BaseMap, BumpMap, EnvironmentMap, DetailMapA, DetailMapB, MicroDetailMap, LightMap, GlowMap, VectorNormalization;

sampler2D base = sampler_state
{
    Texture = <BaseMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D bump = sampler_state
{
    Texture = <BumpMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D detailA = sampler_state
{
    Texture = <DetailMapA>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D detailB = sampler_state
{
    Texture = <DetailMapB>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D microDetail = sampler_state
{
    Texture = <MicroDetailMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D lightmap = sampler_state
{
    Texture = <LightMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = None;
};

sampler2D glow = sampler_state
{
    Texture = <GlowMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

samplerCUBE environment = sampler_state
{
    Texture = <EnvironmentMap>;
    AddressU = Clamp;
    AddressV = Clamp;
    AddressW = Clamp;
    MinFilter = None;
    MagFilter = Linear;
    MipFilter = None;
};

samplerCUBE normalization = sampler_state
{
    Texture = <VectorNormalization>;
    AddressU = Wrap;
    AddressV = Wrap;
    AddressW = Wrap;
    MinFilter = None;
    MagFilter = Linear;
    MipFilter = None;
};

// this function attempts to emulate the glow map lighting
float4 glow_map_illumination(float2 uvs)
{
	float4 color = float4(0.0f, 0.0f, 0.0f, 0.0f);
	float4 glowColor = tex2D(glow, uvs * glowScale);
	
	color += primaryAnimationColor * glowColor.r * primaryAnimationValue;
	color += secondaryAnimationColor * glowColor.g * secondaryAnimationValue;
	color += plasmaAnimationColor * clamp(1.0f - 10.0f * abs(plasmaAnimationValue - glowColor.a), 0.0f, 1.0f) * glowColor.b;
	
	color.a = 0.0f;
	return color;
}

float4 environmentVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4, out float fog : FOG) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	uvs.x += uAnimationValue;
	uvs.y += vAnimationValue;
	fog = 1.0f - saturate((distance(cameraPosition.xyz, worldPosition.xyz) - fogStart) / fogEnd) * fogDensity;
	return mul(position, worldViewProjection);
}

float4 ps_flat_environment_mapped_dm(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb *= tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb *= tex2D(detailA, uvs * detailAScale).rgb;
	color.rgb *= 4.0f;
	color = (color + (texCUBE(environment, view) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_flat_environment_mapped_m(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb *= tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb *= tex2D(detailA, uvs * detailAScale).rgb;
	color = (color + (texCUBE(environment, view) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_flat_environment_mapped_a(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb += tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb += tex2D(detailA, uvs * detailAScale).rgb;
	color.rgb -= 1.0f;
	color = (color + (texCUBE(environment, view) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_bumped_environment_mapped_dm(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb *= tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb *= tex2D(detailA, uvs * detailAScale).rgb;
	color.rgb *= 4.0f;
	color = (color + (texCUBE(environment, reflect(view, 2.0f * bumpVector.xyz - 1.0f)) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_bumped_environment_mapped_m(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb *= tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb *= tex2D(detailA, uvs * detailAScale).rgb;
	color = (color + (texCUBE(environment, reflect(view, 2.0f * bumpVector.xyz - 1.0f)) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_bumped_environment_mapped_a(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(base, uvs);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	color.rgb += tex2D(microDetail, uvs * microDetailScale).rgb;
	color.rgb += tex2D(detailA, uvs * detailAScale).rgb;
	color.rgb -= 1.0f;
	color = (color + (texCUBE(environment, reflect(view, 2.0f * bumpVector.xyz - 1.0f)) - 0.5f) * color.a * lerp(parallelShininess, perpendicularShininess, angle)) * tex2D(lightmap, luvs);
	color.a = bumpVector.a;
	return saturate(color * ambientColor + glow_map_illumination(uvs));
}

float4 ps_normal_dm_dm_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color *= lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a);
	color *= tex2D(microDetail, uvs * microDetailScale);
	color *= 4.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_dm_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color *= lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a);
	color *= tex2D(microDetail, uvs * microDetailScale);
	color *= 2.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_m_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color *= lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a);
	color *= tex2D(microDetail, uvs * microDetailScale);
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_dm_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color *= lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a) * 2.0f;
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_m_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color *= lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a);
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_a_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color += lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a) - 0.5f;
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_a_dm_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color += lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a) - 0.5f;
	color *= tex2D(microDetail, uvs * microDetailScale) * 2.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_normal_a_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float4 dbColor = tex2D(detailB, uvs * detailBScale);
	
	color += lerp(dbColor, tex2D(detailA, uvs * detailAScale), dbColor.a) - 0.5f;
	color *= tex2D(microDetail, uvs * microDetailScale);
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_dm_dm_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color *= lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor);
	color *= tex2D(microDetail, uvs * microDetailScale);
	color *= 4.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_dm_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color *= lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor);
	color *= tex2D(microDetail, uvs * microDetailScale);
	color *= 2.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_m_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color *= lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor);
	color *= tex2D(microDetail, uvs * microDetailScale);
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_dm_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color *= lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor) * 2.0f;
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_a_dm_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color += lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor) - 0.5f;
	color *= tex2D(microDetail, uvs * microDetailScale) * 2.0f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_m_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color *= lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor);
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_a_m_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color += lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor) - 0.5f;
	color *= tex2D(microDetail, uvs * microDetailScale);
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

float4 ps_blended_a_a_detail(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = tex2D(base, uvs);
	float blendFactor = color.a;
	
	color += lerp(tex2D(detailB, uvs * detailBScale), tex2D(detailA, uvs * detailAScale), blendFactor) - 0.5f;
	color += tex2D(microDetail, uvs * microDetailScale) - 0.5f;
	
	color.a = tex2D(bump, uvs * bumpScale).a;
	return saturate(color * ambientColor * tex2D(lightmap, luvs) + glow_map_illumination(uvs));
}

technique FlatEnvironmentMapDM
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_environment_mapped_dm();
	}
}

technique BumpedEnvironmentMapDM
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_environment_mapped_dm();
	}
}

technique FlatEnvironmentMapM
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_environment_mapped_m();
	}
}

technique BumpedEnvironmentMapM
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_environment_mapped_m();
	}
}

technique FlatEnvironmentMapA
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_environment_mapped_a();
	}
}

technique BumpedEnvironmentMapA
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_environment_mapped_a();
	}
}

technique NormalDMDMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_dm_dm_detail();
	}
}

technique BlendedDMDMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_dm_dm_detail();
	}
}

technique NormalMDMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_dm_m_detail();
	}
}

technique BlendedMDMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_dm_m_detail();
	}
}

technique NormalADMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_a_dm_detail();
	}
}

technique BlendedADMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_a_dm_detail();
	}
}

technique NormalDMMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_dm_m_detail();
	}
}

technique BlendedDMMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_dm_m_detail();
	}
}

technique NormalMMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_m_m_detail();
	}
}

technique BlendedMMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_m_m_detail();
	}
}

technique NormalAMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_a_m_detail();
	}
}

technique BlendedAMDetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_a_m_detail();
	}
}

technique NormalDMADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_dm_a_detail();
	}
}

technique BlendedDMADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_dm_a_detail();
	}
}

technique NormalMADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_m_a_detail();
	}
}

technique BlendedMADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_m_a_detail();
	}
}

technique NormalAADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_normal_a_a_detail();
	}
}

technique BlendedAADetailBlend
{
	pass environment
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 environmentVS_1_1();
		PixelShader = compile ps_2_0 ps_blended_a_a_detail();
	}
}