// this file is part of a shader_tranaparent_generic shader generation method.
// written by SwampFox

// maximum number of stages supported by the game
#define MAX_STAGE_COUNT 7

// fog variables
float fogStart, fogEnd, fogDensity;
// current camera position
float4 cameraPosition;
// transforms
float4x4 world, worldViewProjection;
// textures
texture Map0, Map1, Map2, Map3;
// texture scales
float2 map0Scale, map1Scale, map2Scale, map3Scale;
// texture offsets
float2 map0Offset, map1Offset, map2Offset, map3Offset;

// stage variables
float4 constantColor0Low[MAX_STAGE_COUNT];
float4 constantColor0High[MAX_STAGE_COUNT];
float4 constantColor1[MAX_STAGE_COUNT];
float colorValues[MAX_STAGE_COUNT];

// samplers
#if UNFILTERED_0
sampler2D map0 = sampler_state
{
    Texture = <Map0>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Point;
    MagFilter = Point;
    MipFilter = Point;
};
#else
sampler2D map0 = sampler_state
{
    Texture = <Map0>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};
#endif
#if UNFILTERED_1
sampler2D map1 = sampler_state
{
    Texture = <Map1>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Point;
    MagFilter = Point;
    MipFilter = Point;
};
#else
sampler2D map1 = sampler_state
{
    Texture = <Map1>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};
#endif
#if UNFILTERED_2
sampler2D map2 = sampler_state
{
    Texture = <Map2>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Point;
    MagFilter = Point;
    MipFilter = Point;
};
#else
sampler2D map2 = sampler_state
{
    Texture = <Map2>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};
#endif
#if UNFILTERED_3
sampler2D map3 = sampler_state
{
    Texture = <Map3>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Point;
    MagFilter = Point;
    MipFilter = Point;
};
#else
sampler2D map3 = sampler_state
{
    Texture = <Map3>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};
#endif

float4 genericVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4, out float fog : FOG) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	fog = 1.0f;// - saturate((distance(cameraPosition.xyz, worldPosition.xyz) - fogStart) / fogEnd) * fogDensity;
	return mul(position, worldViewProjection);
}

float4 ps_transparent_generic(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	//float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 scratch_0 = float4(0.0f, 0.0f, 0.0f, 0.0f);
	float4 scratch_1 = float4(0.0f, 0.0f, 0.0f, 0.0f);
	float4 vertex_0 = float4(1.0f, 1.0f, 1.0f, 1.0f);
	float4 vertex_1 = float4(1.0f, 1.0f, 1.0f, 1.0f);
	float4 map_0 = tex2D(map0, uvs * map0Scale + map0Offset);
	float4 map_1 = tex2D(map1, uvs * map1Scale + map1Offset);
	float4 map_2 = tex2D(map2, uvs * map2Scale + map2Offset);
	float4 map_3 = tex2D(map3, uvs * map3Scale + map3Offset);
	float4 constant_0 = float4(0.0f, 0.0f, 0.0f, 0.0f);
	float4 constant_1 = float4(0.0f, 0.0f, 0.0f, 0.0f);
	
	float alphaInputA, alphaInputB, alphaInputC, alphaInputD;
	float alphaOutputAB, alphaOutputCD, alphaOutputABCD;
	float4 colorInputA, colorInputB, colorInputC, colorInputD;
	float4 colorOutputAB, colorOutputCD, colorOutputABCD;
	
