Shader "Unlit/MaskShader"
{
  Properties{}

	SubShader{

		Tags {
			"RenderType" = "Opaque"
		}

		Pass {
			ZWrite Off
		}
	}
}
