Shader "ConstantTimeStudios/Seaweed"
{
	Properties
	{
		_mainTex("mainTex", 2D) = "white" {}
		_normal("normal", 2D) = "bump" {}
		_metalic("metalic", Range(0 , 1)) = 0
		_smoothness("smoothness", Range(0 , 1)) = 0.5
		_ambient_light("ambient_light", Range(0 , 1)) = 0.2
		_cut_off("cut_off", Range(0 , 5)) = 0.5

		_wave_speed("wave_speed", Range( 0 , 10)) = 1
		_wave_frequency("wave_frequency", Range( 0 , 10)) = 0
		_wave_strength("wave_strength", Range( 0 , 10)) = 0
		_wave_direction("wave_direction", Vector) = (1,0,0,0)

		_origin_damping_ramp("origin_damping_ramp", Range( 1 , 10)) = 3
		_origin_offset("origin_offset", Vector) = (0,-0.5,0,1)
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc
		struct Input
		{
			float2 uv_normal;
			float2 uv_mainTex;
		};

		uniform sampler2D _normal;
		uniform sampler2D _mainTex;
		uniform float _ambient_light;
		uniform float _metalic;
		uniform float _smoothness;
		uniform float _cut_off;
		uniform float4 _origin_offset;
		uniform float _origin_damping_ramp;
		uniform float _wave_frequency;
		uniform float _wave_speed;
		uniform float _wave_strength;
		uniform float4 _wave_direction;

		void vertexDataFunc(inout appdata_full vertexData, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			vertexData.vertex.xyz += ( clamp( pow( distance( vertexData.vertex , _origin_offset ) , _origin_damping_ramp ) , 0.0 , 1.0 ) * ( ( sin( ( ( vertexData.vertex.y * _wave_frequency ) - ( _Time[1] * _wave_speed ) ) ) * _wave_strength ) * _wave_direction ) );
		}

		void surf( Input input , inout SurfaceOutputStandard output )
		{
			output.Normal = UnpackNormal( tex2D( _normal,input.uv_normal) );
			float4 tex2DNode110 = tex2D( _mainTex,input.uv_mainTex);
			output.Albedo = tex2DNode110.xyz;
			output.Emission = ( tex2DNode110 * _ambient_light ).xyz;
			output.Metallic = _metalic;
			output.Smoothness = _smoothness;
			clip( ( tex2DNode110.a * _cut_off ) - 0.5 );
		}

		ENDCG
	}
	Fallback "Diffuse"
}