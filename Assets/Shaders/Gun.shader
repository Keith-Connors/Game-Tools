// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Costumized/Gun"
{
	Properties
	{
		_Color("Main Color", Color) = (0,1,0,0.5)
		_Scale("Scale", Range(0,1)) = 0
	}

	SubShader
	{

		Pass
		{

			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 pos : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
			};

			fixed4 _Color;
			float _Scale;

			v2f vertexFunction(appdata v)
			{
				v2f o;
				
				o.pos = v.pos + float4(_Scale * abs(sin(_Time.z)) * v.normal, 1);
				o.pos = UnityObjectToClipPos(o.pos);

				o.normal = UnityObjectToWorldNormal(v.normal);
				
				
				return o;
			}

			fixed4 fragmentFunction(v2f outputVertex) : SV_Target
			{
				return fixed4(outputVertex.normal,1);
			}

			ENDCG
		}
	}
}