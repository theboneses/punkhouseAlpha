 Shader "houseMask" {
      
    SubShader {
      Tags { "RenderType" = "Opaque" "Queue"="Geometry-1"}
      ColorMask 0
      Zwrite off

      Stencil{
      Ref 1
      Comp always
      Pass replace
      }

      Pass{
      Cull Back
      Ztest less

       CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;          
            };

            struct v2f
            {
              float4 pos : SV_POSITION;
            };

           
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
                return o;
            }
            
           half4 frag (v2f i) : COLOR
            {
               
                return half4(1,1,1,1);
            }
      ENDCG
      }
    } 
  }