//--------------------------------------------------------------------------------------
// Provides a simple material shading. Self shadowing + Texture diffuse.
// TODO:
//		-Maybe consider computer hardware other than graphics abilities?
//		-Multiple lights, Detail maps, Bump maps for all versions.
//		-normal maps, specular for ps/vs 2.0, 3.0
//--------------------------------------------------------------------------------------

//World information.
float4x4 g_WorldViewProjection; //World view projection.
float4x4 g_World;				//World matrix.

//Lighting information.
float4	 g_LightAmbience;		//Light ambient colour.
float4	 g_LightDiffuse;		//Diffuse colour of light.
float4	 g_LightDirection;		//Direction of light.
float	 g_LightIntensity;		//Intensity of light.

//Material information.
float4	 g_MaterialDiffuse;		//Diffuse colour of material.
texture	 g_MaterialTexture;		//Base texture.

//--------------------------------------------------------------------------------------
// Texture sampler
//--------------------------------------------------------------------------------------
sampler MeshTextureSampler = 
sampler_state
{
    Texture = <g_MaterialTexture>;
    MipFilter = LINEAR;
    MinFilter = LINEAR;
    MagFilter = LINEAR;
};

//--------------------------------------------------------------------------------------
// Vertex shader output structure
//--------------------------------------------------------------------------------------
struct VS_OUTPUT
{
	float4 pos : POSITION;
	float3 light : TEXCOORD0;
	float3 norm : TEXCOORD1;
	float2 textUV : TEXCOORD2;
};


//--------------------------------------------------------------------------------------
// Staggered vertex shaders from 1.0 -> 3.0
//--------------------------------------------------------------------------------------
VS_OUTPUT VS(float4 vPos : POSITION, float3 vNormal : NORMAL, float2 vTextUV : TEXCOORD)
{
    VS_OUTPUT Output;
    
    Output.pos = mul(vPos, g_WorldViewProjection);
    Output.light = g_LightDirection;
    Output.norm = normalize(mul(vNormal, g_World));
    Output.textUV = vTextUV;
    
    return Output;    
}


//--------------------------------------------------------------------------------------
// Staggered pixel shaders from 1.0 -> 3.0
//--------------------------------------------------------------------------------------
float4 PS(float3 vLight : TEXCOORD0, float3 vNorm : TEXCOORD1, VS_OUTPUT In) : COLOR
{
	//TODO: Set these to global values.
    float4 diffuse = {0.5, 0.5, 0.5, 0.0};
    float4 ambient = {0.05, 0.05, 0.05, 0.0};
    
    float4 text = tex2D(MeshTextureSampler, In.textUV) * diffuse; 
    float4 diff = dot(vLight, vNorm);
    float shadow = saturate(4 * diff);
    
    return (text + ambient) * diff + shadow;
}

//--------------------------------------------------------------------------------------
// Render techniques.
//--------------------------------------------------------------------------------------
technique RenderScene
{
    pass P0
    {          
        VertexShader = compile vs_1_0 VS();
        PixelShader  = compile ps_1_0 PS();
    }
}

