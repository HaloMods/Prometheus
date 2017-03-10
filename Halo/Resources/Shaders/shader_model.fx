// shader_model.fx - lets us draw Halo's sexy models. mmmmm... sexy models...
// written by SwampFox

// fog variables
float fogStart, fogEnd, fogDensity;
// texture scales
float detailScale, detailVScale, uScale, vScale;
// animation values
float selfIlluminationValue;
// enumerations
int detailFunction;
// flags
bool detailAfterReflection;
// modulates environment maps depending on view angle
float parallelBrightness, perpendicularBrightness;
// colors
float4 selfIlluminationLower, selfIlluminationUpper, changeColor;
// ambient light color
float4 ambientColor;
// current camera position
float4 cameraPosition;
// transforms
float4x4 world, worldViewProjection;
// textures
texture BaseMap, MultipurposeMap, EnvironmentMap, DetailMap, LightMap;

sampler2D base = sampler_state
{
    Texture = <BaseMap>;
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

sampler2D multi = sampler_state
{
    Texture = <MultipurposeMap>;
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

float4 modelVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4, out float fog : FOG) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	uvs.x *= uScale;
	uvs.y *= vScale;
	fog = 1.0f - saturate((distance(cameraPosition.xyz, worldPosition.xyz) - fogStart) / fogEnd) * fogDensity;
	return mul(position, worldViewProjection);
}

float4 do_detail(float4 color, float2 uvs, float mask)
{
	uvs *= detailScale;
	uvs.y *= detailVScale;
	if (detailFunction == 0) // biased multiply
		color *= lerp(1.0f, tex2D(detail, uvs) * 2.0f, mask);
	else if (detailFunction == 1) // multiply
		color *= lerp(1.0f, tex2D(detail, uvs), mask);
	else // biased add
		color += (tex2D(detail, uvs) - 0.5f) * mask;
	return color;
}

float4 ps_model_no_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, 1.0f);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, 1.0f);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_reflection_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.r);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.r);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_inverse_reflection_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.r);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.r);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_illum_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.g);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.g);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_inverse_illum_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.g);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.g);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_change_color_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.b);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.b);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_inverse_change_color_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.b);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.b);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_auxiliary_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.a);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, multipurpose.a);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

float4 ps_model_inverse_auxiliary_detail_mask(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 multipurpose = tex2D(multi, uvs);
	float4 diffuse = tex2D(base, uvs);
	diffuse = lerp(diffuse, diffuse * changeColor, multipurpose.b);
	float4 color = diffuse;
	if (!detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.a);
	color += texCUBE(environment, -view) * multipurpose.r * lerp(parallelBrightness, perpendicularBrightness, angle);
	if (detailAfterReflection)
		color = do_detail(color, uvs, 1.0f - multipurpose.a);
	color *= tex2D(lightmap, luvs) * ambientColor;
	color = (diffuse * multipurpose.g * lerp(selfIlluminationLower, selfIlluminationUpper, selfIlluminationValue)) + (color * (1.0f - selfIlluminationValue * multipurpose.g));
	color.a = diffuse.a;
	return color;
}

technique ModelNoDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_no_detail_mask();
	}
}

technique ModelReflectionDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_reflection_detail_mask();
	}
}

technique ModelIReflectionDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_inverse_reflection_detail_mask();
	}
}

technique ModelIllumDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_illum_detail_mask();
	}
}

technique ModelIIllumDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_inverse_illum_detail_mask();
	}
}

technique ModelChangeColorDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_change_color_detail_mask();
	}
}

technique ModelIChangeColorDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_inverse_change_color_detail_mask();
	}
}

technique ModelAuxiliaryDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_auxiliary_detail_mask();
	}
}

technique ModelIAuxiliaryDetailMask
{
	pass model
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 modelVS_1_1();
		PixelShader = compile ps_2_0 ps_model_inverse_auxiliary_detail_mask();
	}
}
