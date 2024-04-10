Shader "Custom/AnimalCrossingBending"
{
    Properties
    {
	   [NoScaleOffset]
        _MainTex ("顏色紋理", 2D) = "white" {}
		_BendY("彎曲程度", Range(0,0.01)) = 0.0

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
            // make fog work
            #pragma multi_compile_fog


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;

                float2 uv : TEXCOORD0;

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;

				//定義頂點世界變量
				float4 WordData : TEXCOORD1;
				float4 vertex : SV_POSITION;
				UNITY_FOG_COORDS(4)
            };

			//顏色紋理
            sampler2D _MainTex;
			float _BendY;

            v2f vert (appdata v)
            {
                v2f o;
                
                o.uv = v.uv;
				
				float3 WordPos = mul(unity_ObjectToWorld, v.vertex);
				//獲取Y軸座標
				o.WordData.x = WordPos.y;

				//Y軸扭曲依據XZ座標變化
				WordPos.y -= pow(WordPos.x, 2)*_BendY;
				WordPos.y -= pow(WordPos.z, 2)*_BendY;

				//獲取位移位置
				WordPos -= mul(unity_ObjectToWorld, float4(0, 0, 0, 1));

				//修改世界頂點轉回物體自身頂點。
				v.vertex = mul(unity_WorldToObject, WordPos);
				//轉換為裁切空間
				o.vertex = UnityObjectToClipPos(v.vertex);
				
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				//獲取顏色貼圖
                fixed4 col = tex2D(_MainTex, i.uv);
				
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
