Shader "Custom/RailRushBending/Coin"
{
    Properties
    {
        _MainTex ("顏色紋理", 2D) = "white" {}
        _SwerveX_Min("SwerveX 最小值", Float) = -0.003
        _SwerveX_Max("SwerveX 最大值", Float) = 0.003
		_SwerveX("左右彎曲程度", Float) = 0.0
		_SwerveY("上下彎曲程度", Range(-0.003,0.003)) = 0.0
        _SwerveTarget("參考目標點", Vector) = (0, 0, 1, 0)
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
				float4 vertex : SV_POSITION;
				UNITY_FOG_COORDS(4)
            };

			//顏色紋理
            sampler2D _MainTex;
			float _SwerveX;
			float _SwerveY;
            float4 _SwerveTarget;

            v2f vert (appdata v)
            {
                v2f o;

                o.uv = v.uv;
				
				//獲取頂點在世界空間的座標
				float3 WorldSpacePosition = mul(unity_ObjectToWorld, v.vertex);

                // 目標點的坐標
                // float3 targetPoint = float3(100, 0, 10);

                // 計算頂點到目標點的向量
                float3 distanceToTarget = WorldSpacePosition - _SwerveTarget.xyz;

                // 計算向量的長度
                float distance = length(distanceToTarget);

				//-- 左右座標作为彎道 --
				//依據Z座標求平方獲取彎曲曲線，越遠離世界座標原點，彎曲效果越明顯。
				//最後乘以左右彎道彎曲方向，和彎曲强度
				WorldSpacePosition.x += pow(distance, 2)*_SwerveX;
				//方法與上面相同，改變Y軸，獲得上下坡效果
				WorldSpacePosition.y += pow(distance, 2)*_SwerveY;

				//修正模型位置，WorldSpacePosition 不包含物體自身的空間位移
				WorldSpacePosition -= mul(unity_ObjectToWorld, float4(0, 0, 0, 1));

				//修改世界頂點轉回物體自身頂點
				v.vertex = mul(unity_WorldToObject, WorldSpacePosition);

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
