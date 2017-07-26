Shader "Vision/Thermal Body"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ThermalGradient ("Thermal Gradient Texture", 2D) = "white" {}
		_Temperature ("Average Temperature", Range (0.5, 1.5)) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float3 viewDir : TEXCOORD0;
				float3 normalDir : TEXCOORD1;
			};

			sampler2D _MainTex;
			sampler2D _ThermalGradient;
			float4 _MainTex_ST;
			float _Temperature;
			
			v2f vert (appdata v)
			{
				v2f o;
 
	            o.normalDir = normalize(mul(v.normal, unity_WorldToObject));
    	        o.viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex).xyz);
				o.vertex = UnityObjectToClipPos(v.vertex);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{		
				float thermalFactor = dot(normalize(i.viewDir), normalize(i.normalDir));

				float2 uv = (0.5, thermalFactor * _Temperature);

				fixed4 col = tex2D(_ThermalGradient, uv);

				return col;
			}
			ENDCG
		}
	}
}
