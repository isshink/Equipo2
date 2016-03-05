Shader "SphereLitOutline" 
{
	Properties
	{
		_MainTex("Main", 2D) = "white" {}
		_SphereMap("Sphere map", 2D) = "white" {}
		_OutlineColor("Outline Color", Color) = (1,1,1,1)//blanco
		_Outline("Outline width", Range(.002, 0.03)) = .005//
	}

		SubShader
		{
			Tags{ "RenderType" = "Fade" "Queue" = "Geometry" }
			UsePass "Toon/Lit/FORWARD"
			UsePass "Toon/Basic Outline/OUTLINE"
			Pass
		{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		struct v2f {
			float4 pos : SV_POSITION;
			float4 uv : TEXCOORD0;
			float4 color : COLOR0;
		};

		v2f vert(appdata_full v)
		{
			v2f o;
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv.xy = v.texcoord;
			o.uv.zw = normalize(mul(UNITY_MATRIX_IT_MV, float4(v.normal, 1.0)).xyz).xy * .5 + .5;
			o.color = v.color;
			return o;
		}

		sampler2D _SphereMap;
		sampler2D _MainTex;

		float4 frag(v2f i) : COLOR
		{
			return tex2D(_MainTex, i.uv.xy) * tex2D(_SphereMap, i.uv.zw) * i.color;
		}

			ENDCG
		}
		}
			Fallback "Toon/Lit"

}
