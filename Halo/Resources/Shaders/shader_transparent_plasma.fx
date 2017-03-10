// shader_transparent_glass.fx - provides a technique for drawing glass environment shaders
// written by SwampFox

// offset
float offset;
// intensity
float intensity;
// texture scales
float primaryScale, secondaryScale;
// texture coordinates
float primaryI, primaryJ, primaryK;
float secondaryI, secondaryJ, secondaryK;
// modulates environment maps depending on view angle
float parallelBrightness, perpendicularBrightness;
// colors
float4 parallelColor, perpendicularColor;
// current camera position
float4 cameraPosition;
// transforms
float4x4 world, worldViewProjection;
// textures
texture PrimaryMap, SecondaryMap;

sampler3D primary = sampler_state
{
    Texture = <PrimaryMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    AddressW = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler3D secondary = sampler_state
{
    Texture = <SecondaryMap>;
    AddressU = Wrap;
    AddressV = Wrap;
    AddressW = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

float4 plasmaVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	return mul(position + float4(offset * normal, 0.0f), worldViewProjection);
}

float4 ps_plasma(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float4 color = lerp(parallelColor * parallelBrightness, perpendicularColor * perpendicularBrightness, angle);
	float3 primaryCoords = float3(uvs.x + primaryI, uvs.y + primaryJ, primaryK) * primaryScale;
	float3 secondaryCoords = float3(uvs.x + secondaryI, uvs.y + secondaryJ, secondaryK) * secondaryScale;
	float4 primaryColor = tex3D(primary, primaryCoords);
	float4 secondaryColor = tex3D(secondary, secondaryCoords);
	float primaryValue = (primaryColor.r + primaryColor.g + primaryColor.b + primaryColor.a) / 4.0f;
	float secondaryValue = (secondaryColor.r + secondaryColor.g + secondaryColor.b + secondaryColor.a) / 4.0f;
	return clamp(1.0f - 10.0f * abs(primaryValue - secondaryValue), 0.0f, 1.0f) * color;
}

technique Plasma
{
	pass plasma
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 plasmaVS_1_1();
		PixelShader = compile ps_2_0 ps_plasma();
	}
}
