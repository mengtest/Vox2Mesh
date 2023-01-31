Shader "Vox2Mesh/Vox2Mesh_BuiltIn"
{
    Properties
    {
        _Glossiness ("Smoothness", Range(0,1)) = 0.0
        _Metallic ("Metallic", Range(0,1)) = 0.0
        [HDR] _Emission ("Emission", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            fixed4 color: COLOR;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        half4 _Emission;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = pow(IN.color, 2.2);
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Emission = _Emission;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
