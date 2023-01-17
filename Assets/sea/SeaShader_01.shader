Shader "Unlit/SeaShader"
{

	Properties{
		_MainTex("海テクスチャ", 2D) = "red"{}
		_SubTex("海テクスチャ", 2D) = "red"{}
	}
		SubShader{

			Tags { "RenderType" = "Opaque"  }
			LOD 200

			CGPROGRAM
			
			#pragma surface surf Standard fullforwardshadows
			#pragma vertex vert
			#pragma target 3.0
			
			struct Input {
				float2 uv_MainTex;
			};
			
			sampler2D _MainTex;
		
			void vert(inout appdata_full v, out Input o )
			{
			   UNITY_INITIALIZE_OUTPUT(Input, o);
			   float amp = 00.5*sin(_Time*100 + v.vertex.x * 100);
			   v.vertex.xyz = float3(v.vertex.x, v.vertex.y+amp, v.vertex.z);
			}
			
			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed2 uv = IN.uv_MainTex;
				uv.x += 5* _Time;
				uv.y += 5* _Time;

				fixed4 c = tex2D (_MainTex, uv);
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
			ENDCG
	}
		FallBack "Diffuse"
}
