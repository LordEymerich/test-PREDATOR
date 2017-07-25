Shader "Hidden/Night Vision"
{
	Properties
	{
		_MainTex ("Screen", 2D) = "white" {}
		_LuminanceAmplifier ("Luminance Amplifier", Range(1, 5)) = 2.5
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
		
			fixed4 FS (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col *= _LuminanceAmplifier;

				// To consider only the green component of col vector.
				_GreenAmplifier.g = 1.0;
		
				return (col * _GreenAmplifier).rgba;
			}
			ENDCG
		}
	}
}