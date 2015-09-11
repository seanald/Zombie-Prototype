Shader "Custom/SpriteLightWithNormals" 
{
Properties 
{
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}

SubShader 
{
    Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutOut" "CanUseSpriteAtlas"="True"}
    LOD 200

    CGPROGRAM

    #pragma surface surf Lambert alpha vertex:vert  alphatest:_Cutoff fullforwardshadows
    #pragma multi_compile DUMMY PIXELSNAP_ON 

    sampler2D _MainTex;
    fixed4 _Color;

    struct Input 
    {
        float2 uv_MainTex;
        float3 nrmls;
    };

    void vert(inout appdata_full v, out Input o)
    {
        v.normal = float3(0,0,-1);
        v.tangent = float4 (0,0,0,0);
        UNITY_INITIALIZE_OUTPUT(Input,o);
        o.nrmls = v.normal;
    }

    void surf (Input IN, inout SurfaceOutput o) 
    {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb;
        o.Alpha = c.a;
        o.Normal = IN.nrmls;
    }

    ENDCG
}   }