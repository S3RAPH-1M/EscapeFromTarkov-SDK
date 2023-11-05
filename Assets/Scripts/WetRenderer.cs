using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class WetRenderer: MonoBehaviour
{
	public Shader WetShader;

	[Range(0f, 1f)]
	public float Intensity;

	public Color DiffuseColor;

	public Color SpecColor;

	public float WetBias = 0.0016f;

	private Material material_0;

	private static readonly int int_0 = Shader.PropertyToID("_SurfaceWetIntensity");

	private static readonly int int_1 = Shader.PropertyToID("_SurfaceWetDiffuseColor");

	private static readonly int int_2 = Shader.PropertyToID("_SurfaceWetSpecColor");

	private static readonly int int_3 = Shader.PropertyToID("_SurfaceWetBias");

	private Mesh mesh_0;

	private readonly RenderTargetIdentifier[] renderTargetIdentifier_0 = new RenderTargetIdentifier[2]
	{
		BuiltinRenderTextureType.GBuffer0,
		BuiltinRenderTextureType.GBuffer1
	};



	
}
