// shader_transparent_glass.fx - provides a technique for drawing glass environment shaders
// written by SwampFox

// fog variables
float fogStart, fogEnd, fogDensity;
// texture scales
float bumpScale, diffuseScale, detailScale, tintScale, specularScale;
// modulates environment maps depending on view angle
float parallelBrightness, perpendicularBrightness;
// colors
float4 backgroundTintColor, parallelColor, perpendicularColor;
// current camera position
float4 cameraPosition;
// transforms
float4x4 world, worldViewProjection;
// textures
texture DiffuseMap, BumpMap, EnvironmentMap, DetailMap, TintMap, LightMap, SpecularMap;

sampler2D diffuse = sampler_state
{
    Texture = <DiffuseMap>;
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

sampler2D detail = sampler_state
{
    Texture = <DetailMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D tint = sampler_state
{
    Texture = <TintMap>;
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

samplerCUBE specular = sampler_state
{
    Texture = <SpecularMap>;
    AddressU = Clamp;
    AddressV = Clamp;
    AddressW = Clamp;
    MinFilter = None;
    MagFilter = Linear;
    MipFilter = None;
};

float4 glassVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4, out float fog : FOG) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	fog = 1.0f;// - saturate((distance(cameraPosition.xyz, worldPosition.xyz) - fogStart) / fogEnd) * fogDensity;
	return mul(position, worldViewProjection);
}

float4 ps_bumped_glass(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	float4 color = tex2D(diffuse, uvs * diffuseScale);
	color.rgb *= tex2D(detail, uvs * detailScale).rgb;
	color *= tex2D(lightmap, luvs);
	color.rgb += texCUBE(environment, reflect(view, 2.0f * bumpVector.xyz - 1.0f)).rgb * lerp(parallelColor.rgb * parallelBrightness, perpendicularColor.rgb * perpendicularBrightness, angle);
	return saturate(color);
}

float4 ps_flat_glass(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = tex2D(diffuse, uvs * diffuseScale);
	color.rgb *= tex2D(detail, uvs * detailScale).rgb;
	color *= tex2D(lightmap, luvs);
	color.rgb += texCUBE(environment, -view).rgb * lerp(parallelColor.rgb * parallelBrightness, perpendicularColor.rgb * perpendicularBrightness, angle);
	return saturate(color);
}

float4 ps_bumped_glass_specular(in float2 uvs : TEXCOORD0, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 bumpVector = tex2D(bump, uvs * bumpScale);
	float4 color = texCUBE(specular, reflect(view, 2.0f * bumpVector.xyz - 1.0f) * specularScale) * lerp(parallelBrightness, perpendicularBrightness, angle);
	color.a = 1.0f;
	return saturate(color);
}

float4 ps_flat_glass_specular(in float2 uvs : TEXCOORD0, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = texCUBE(specular, -view * specularScale) * lerp(parallelBrightness, perpendicularBrightness, angle);
	color.a = 1.0f;
	return saturate(color);
}

technique BumpedGlassTwoPass
{
	pass glass
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_glass();
	}
	pass specular
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_glass_specular();
	}
}

technique FlatGlassTwoPass
{
	pass glass
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_glass();
	}
	pass specular
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_glass_specular();
	}
}

technique FlatGlassSpecular
{
	pass specular
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_glass_specular();
	}
}

technique BumpedGlassSpecular
{
	pass specular
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_glass_specular();
	}
}

technique BumpedGlass
{
	pass glass
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_bumped_glass();
	}
}

technique FlatGlass
{
	pass glass
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 glassVS_1_1();
		PixelShader = compile ps_2_0 ps_flat_glass();
	}
}