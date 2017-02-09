Shader "Custom/Spotlight"
{
	Properties
	{
		 _MainTex ("Color (RGB) Alpha (A)", 2D) = "white"{}
		_CenterX ("Center X", Range(0.0, 0.5)) = 0.25
		_CenterY ("Center Y", Range(0.0, 0.5)) = 0.25
		_Radius ("Radius", Range(0.01, 0.5)) = 0.1
		_Sharpness ("Sharpness", Range(0, 20)) = 1
		//_Cutoff ("Alpha Cutoff", Float) = 0.5
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
		 Blend One OneMinusSrcAlpha
		 Pass
			//Blend One One
		
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float _CenterX, _CenterY;
			float _Radius;
			float _Sharpness;
			//float _Cutoff;

			fixed4 frag (v2f_img i) : SV_Target
			{
				float dist = distance(float2(_CenterX, _CenterY), ComputeScreenPos(i.pos).xy / _ScreenParams.x);
				fixed4 col = tex2D(_MainTex, i.uv);
				return col * ( 2-_Radius/dist);

            	
			}


			ENDCG
		}
	}
}