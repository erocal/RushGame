Shader "Custom/AnimalCrossingBending"
{
    Properties
    {
	   [NoScaleOffset]
        _MainTex ("�C�⯾�z", 2D) = "white" {}
		_BendY("�s���{��", Range(0,0.01)) = 0.0

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

				//�w�q���I�@���ܶq
				float4 WordData : TEXCOORD1;
				float4 vertex : SV_POSITION;
				UNITY_FOG_COORDS(4)
            };

			//�C�⯾�z
            sampler2D _MainTex;
			float _BendY;

            v2f vert (appdata v)
            {
                v2f o;
                
                o.uv = v.uv;
				
				float3 WordPos = mul(unity_ObjectToWorld, v.vertex);
				//���Y�b�y��
				o.WordData.x = WordPos.y;

				//Y�b�ᦱ�̾�XZ�y���ܤ�
				WordPos.y -= pow(WordPos.x, 2)*_BendY;
				WordPos.y -= pow(WordPos.z, 2)*_BendY;

				//����첾��m
				WordPos -= mul(unity_ObjectToWorld, float4(0, 0, 0, 1));

				//�ק�@�ɳ��I��^����ۨ����I�C
				v.vertex = mul(unity_WorldToObject, WordPos);
				//�ഫ�������Ŷ�
				o.vertex = UnityObjectToClipPos(v.vertex);
				
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				//����C��K��
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
