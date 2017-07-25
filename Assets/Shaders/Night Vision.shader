Shader "Hidden/Night Vision"
{
	Properties
	{
		_MainTex ("Screen", 2D) = "white" {}
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_LuminanceAmplifier ("Luminance Amplifier", Range(1, 5)) = 2.5
		_NoiseIntensity ("Noise Intensity", Range(0, 1)) = 0.8
		_NoiseFrequency ("Noise Frequency", Range(10, 100)) = 50.0
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex VS
			#pragma fragment FS
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f VS (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _NoiseTex;
			fixed4 _GreenAmplifier;

			uniform float _LuminanceAmplifier;
			uniform float _NoiseIntensity;
			uniform float _NoiseFrequency;
		
			fixed4 FS (v2f i) : SV_Target
			{
				fixed4 screenColor = tex2D(_MainTex, i.uv);
			
				screenColor *= _LuminanceAmplifier;

				// Change noise texture offset with time (no need to have a parameter for this)
  				float2 noiseST;   
				noiseST.x = _SinTime.w * 50.0;
				noiseST.y = _CosTime.w * 50.0;

				// Sample noise texture - TODO: try with a texture with an higher resolution.
			  	fixed4 noise = tex2D(_NoiseTex, (i.uv * 6) + noiseST);	

				// To consider only the green component of col vector.
				_GreenAmplifier.g = 1.0;
		
				return ((screenColor + (noise * _NoiseIntensity)) * _GreenAmplifier).rgba;
			}
			ENDCG
		}
	}
}