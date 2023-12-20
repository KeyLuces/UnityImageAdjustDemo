Shader "ImageEffectsShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Saturation ("Saturation", Float) = 1.0
        _Exposure ("Exposure", Float) = 1.0
        _Shadows ("Shadows", Float) = 1.0
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
            };

            sampler2D _MainTex;
            float _Saturation;
            float _Exposure;
            float _Shadows;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);

    // 调整饱和度
    float grey = dot(col.rgb, float3(0.3, 0.59, 0.11));
    col.rgb = lerp(grey, col.rgb, _Saturation);

    // 调整曝光度
    col.rgb *= _Exposure; // 增加或减少每个颜色通道的亮度

    // 阴影效果的调整代码（如果需要）
    // ...

    return col;
}

            ENDCG
        }
    }
}
