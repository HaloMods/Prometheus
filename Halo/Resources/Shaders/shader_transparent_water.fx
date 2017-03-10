// shader_transparent_water.fx - makes the silent cartographer look pretty
// written by SwampFox

// texture scales
float rippleScale;
// modulates environment maps depending on view angle
float parallelBrightness, perpendicularBrightness;
// colors
float4 parallelColor, perpendicularColor;
// ripple map count
int rippleCount;
// master angle
float rippleAngle;
// ripple fields
float factor0, factor1, factor2, factor3;
float repeat0, repeat1, repeat2, repeat3;
float angle0, angle1, angle2, angle3;
float4 offset0, offset1, offset2, offset3;
// ripple animations
float animation0, animation1, animation2, animation3;
// flags
bool alphaModulatesReflection, colorModulatesBackground;
// current camera position
float4 cameraPosition;
// transforms
float4x4 world, worldViewProjection;
// textures
texture BaseMap, RippleMap0, RippleMap1, RippleMap2, RippleMap3, EnvironmentMap, LightMap;

sampler2D base = sampler_state
{
    Texture = <BaseMap>;
    AddressU = Clamp;
    AddressV = Clamp;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D ripple0 = sampler_state
{
    Texture = <RippleMap0>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D ripple1 = sampler_state
{
    Texture = <RippleMap1>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D ripple2 = sampler_state
{
    Texture = <RippleMap2>;
    AddressU = Wrap;
    AddressV = Wrap;
    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};

sampler2D ripple3 = sampler_state
{
    Texture = <RippleMap3>;
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

float2 animate_angle(float animationAngle, float animationValue)
{
	float2 coordinates = float2(0.0f, 0.0f);
	coordinates.x = -sin(animationAngle) * animationValue;
	coordinates.y = cos(animationAngle) * animationValue;
	return coordinates;
}

float3 sample_reflection(float3 view, float angle)
{
	return texCUBE(environment, view).rgb * lerp(parallelBrightness * parallelColor.rgb, perpendicularBrightness * perpendicularColor.rgb, angle);
}

float4 waterVS_1_1(in float4 position : POSITION, in float3 normal : NORMAL, inout float2 uvs : TEXCOORD0, inout float2 luvs : TEXCOORD1, out float angle : TEXCOORD2, out float3 norm : TEXCOORD3, out float3 pos : TEXCOORD4) : POSITION
{
	float4 worldPosition = mul(position, world);
	norm = normal;
	pos = worldPosition.xyz;
	angle = abs(dot(normalize(worldPosition.xyz - cameraPosition.xyz), normal)); // 1.0f = perpendicular; 0.0f = parallel
	return mul(position, worldViewProjection);
}

float4 ps_water(in float2 uvs : TEXCOORD0, in float2 luvs : TEXCOORD1, in float angle : TEXCOORD2, in float3 norm : TEXCOORD3, in float3 pos : TEXCOORD4) : COLOR0
{
	float3 view = reflect(normalize(cameraPosition.xyz - pos), norm);
	float4 color = float4(0.0f, 0.0f, 0.0f, 0.0f);
	float4 baseSample = tex2D(base, uvs);
	float2 rippleCoords = float2(0.0f, 0.0f);
	
	if (colorModulatesBackground)
		color.rgb = baseSample.rgb;
	
	if(rippleCount > 0)
	{
		rippleCoords = animate_angle(rippleAngle + angle0, animation0) + uvs;
		rippleCoords *= repeat0 * rippleScale;
		rippleCoords += offset0.xy;
		color.rgb += sample_reflection(reflect(view, 2.0f * tex2D(ripple0, rippleCoords).xyz - 1.0f), angle) * factor0;
		
		if(rippleCount > 1)
		{
			rippleCoords = animate_angle(rippleAngle + angle1, animation1) + uvs;
			rippleCoords *= repeat1 * rippleScale;
			rippleCoords += offset1.xy;
			color.rgb += sample_reflection(reflect(view, 2.0f * tex2D(ripple1, rippleCoords).xyz - 1.0f), angle) * factor1;
			
			if(rippleCount > 2)
			{
				rippleCoords = animate_angle(rippleAngle + angle2, animation2) + uvs;
				rippleCoords *= repeat2 * rippleScale;
				rippleCoords += offset2.xy;
				color.rgb += sample_reflection(reflect(view, 2.0f * tex2D(ripple2, rippleCoords).xyz - 1.0f), angle) * factor2;
				
				if(rippleCount > 3)
				{
					rippleCoords = animate_angle(rippleAngle + angle3, animation3) + uvs;
					rippleCoords *= repeat3 * rippleScale;
					rippleCoords += offset3.xy;
					color.rgb += sample_reflection(reflect(view, 2.0f * tex2D(ripple3, rippleCoords).xyz - 1.0f), angle) * factor3;
				}
			}
		}
	}
		
	if(alphaModulatesReflection)
		color.rgb *= baseSample.a;
	
	return saturate(color);
}

technique Water
{
	pass water
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 waterVS_1_1();
		PixelShader = compile ps_2_0 ps_water();
	}
}
