Shader "Cg texturing with alpha discard" {
   Properties {
      _MainTex ("RGBA Texture Image", 2D) = "white" {} 
     
   }
   SubShader {
      Pass {    
         Cull Off // since the front is partially transparent, 
            // we shouldn't cull the back

         CGPROGRAM
 
         #pragma vertex vert_img
         #pragma fragment frag 

         #include "UnityCG.cginc"
      
         sampler2D _MainTex;
		 float _CenterX, _CenterY;
		 float _Radius;
		 float _Sharpness;
        
 
         struct vertexInput {
            float4 vertex : POSITION;
            float4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 tex : TEXCOORD0;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            output.tex = input.texcoord;
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }

         fixed4 frag (v2f_img i) : SV_Target
			{
				float dist = distance(float2(_CenterX, _CenterY), ComputeScreenPos(i.pos).xy / _ScreenParams.x);
				fixed4 col = tex2D(_MainTex, i.uv);


            	return col * (-1 + pow(dist / _Radius, _Sharpness));
			}

        
 
         ENDCG
      }
   }
   Fallback "Unlit/Transparent Cutout"
}
