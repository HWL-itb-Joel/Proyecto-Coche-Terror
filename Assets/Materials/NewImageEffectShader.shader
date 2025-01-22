Shader "Hidden/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float _LensDistortionTightness;
            float _LensDistortionStrength;
            float4 _OutOfBoundColour;

            fixed4 frag(v2f i): SV_Target
            {
              const float2 uvNormalized = i.uv * 2 - 1; //change UV range from (0,1) to (-1,1)
              const float distortionMagnitude=abs(uv_centered[0]*uv_centered[1]);//get value with 1 at corner and 0 at middle
              return distortionMagnitude;//preview distortionMagnitude
              const float smoothDistortionMagnitude = pow(distortionMagnitude, _LensDistortionTightness);//use exponential function
                  // const float smoothDistortionMagnitude=1-sqrt(1-pow(distortionMagnitude,_LensDistortionTightness));//use circular function
                  // const float smoothDistortionMagnitude=pow(sin(UNITY_HALF_PI*distortionMagnitude),_LensDistortionTightness);// use sinusoidal function
                  return distortionFunction;// previewing smooth distortion map
            float2 uvDistorted = i.uv + uv_centered * smoothDistortionMagnitude * _LensDistortionStrength;
if (uvDistorted[0] < 0 || uvDistorted[0] > 1 || uvDistorted[1] < 0 || uvDistorted[1] > 1) {
    return _OutOfBoundColour;//uv out of bound so display out of bound color
  } else {
    return tex2D(_MainTex, uvDistorted);
  }

            }
            ENDCG
        }
    }
}
