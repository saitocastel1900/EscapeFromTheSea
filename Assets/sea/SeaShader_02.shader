Shader "VertexWave"
{
    Properties
    {
        _MainTex("海テクスチャ", 2D) = "red"{}
        _Speed("Speed ",Range(0, 100)) = 1
        _Frequency("Frequency ", Range(0, 3)) = 1
        _Amplitude("Amplitude", Range(0, 1)) = 0.5
        
         //X方向のシフトとスピードに関するパラメータを追加
        _XShift("Xuv Shift", Range(-1.0, 1.0)) = 0.1
        _XSpeed("X Scroll Speed", Range(1.0, 100.0)) = 10.0

        //Y方向のシフトとスピードに関するパラメータを追加
        _YShift("Yuv Shift", Range(-1.0, 1.0)) = 0.1
        _YSpeed("Y Scroll Speed", Range(1.0, 100.0)) = 10.0
        
         _TopColor("Top Color", Color) = (1, 1, 1, 1)
        _BottomColor("Bottom Color", Color) = (1, 1, 1, 1)
        _TransparencyColor("Transparency Color", Color) = (1, 1, 1, 0.5)
    }
    SubShader
    {
        Tags { 
            "Queue"      = "Transparent"
            "RenderType" = "Transparent"
            }
         Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            
           #pragma vertex vert
           #pragma fragment frag
            
           #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _XShift;
            float _YShift;
            float _XSpeed;
            float _YSpeed;

             fixed4 _TransparencyColor;
            
            struct Input {
				float2 uv_MainTex;
			};
            
            struct appdata
            {
                float4 vertex : POSITION;
                 float2 uv : TEXCOORD0;
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            
            float _Speed;
            float _Frequency;
            float _Amplitude;

            v2f vert (appdata v)
            {
                v2f o;
                
                float2 factors          = _Time.x * _Speed + v.vertex.xz * _Frequency;
                float2 offsetYFactors   = sin(factors) * _Amplitude;
                v.vertex.y              += offsetYFactors.x + offsetYFactors.y;
                o.vertex                = UnityObjectToClipPos(v.vertex);

                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                // 法線を補正
                float2 normalOffsets    = -cos(factors) * _Amplitude;
                v.normal.xyz            = normalize(half3(normalOffsets.x, 1, normalOffsets.y));

                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                //Speed
                _XShift = _XShift * _XSpeed;
                _YShift = _YShift * _YSpeed;

                //add Shift
                i.uv.x = i.uv.x + _XShift * _Time;
                i.uv.y = i.uv.y + _YShift * _Time;
                
                fixed4 col = tex2D(_MainTex, i.uv)*_TransparencyColor;
                return col;
            }
            
            ENDCG
        }
    }
}