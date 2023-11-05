using System;
using System.Collections.Generic;
using EFT;
using UnityEngine;

public class LightningController : MonoBehaviour
{
	private class Class425
	{
		public bool Strong;

		public float Power;

		public float UVStartY;

		public Vector3[] Points;

		public Vector3[] NormalizedDirections;

		public float[] Ys;

		public int VerticesCount()
		{
			return Points.Length << 1;
		}

		public int TrianglesCount()
		{
			return (Points.Length - 1) * 6;
		}

		public void Fill(int vI, int tI, int[] triangles, Vector3[] positions, Vector3[] directions, Vector2[] uv, Vector4[] values)
		{
			int num = Points.Length - 1;
			Vector3 vector = NormalizedDirections[0];
			for (int i = 0; i < Points.Length; i++)
			{
				int num2 = vI + (i << 1);
				int num3 = num2 + 1;
				Vector3 vector2 = Points[i];
				Vector3 vector3 = NormalizedDirections[i];
				Vector3 vector4 = vector + vector3;
				vector = vector3;
				float y = Ys[i];
				uv[num2] = new Vector2(0f, y);
				uv[num3] = new Vector2(1f, y);
				positions[num2] = (positions[num3] = vector2);
				directions[num2] = (directions[num3] = vector4);
			}
			Vector4 vector5 = new Vector4(Power, 0f, 0f, 0f);
			int num4 = vI + (Points.Length << 1);
			if (Strong)
			{
				for (int j = vI; j < num4; j++)
				{
					values[j] = vector5;
				}
			}
			else
			{
				float num5 = Power / (float)Points.Length;
				int num6 = vI;
				while (num6 < num4)
				{
					values[num6++] = (values[num6++] = vector5);
					vector5.x -= num5;
				}
			}
			for (int k = 0; k < num; k++)
			{
				int num7 = vI + (k << 1);
				int num8 = num7++;
				int num9 = num7++;
				int num10 = num7++;
				triangles[tI++] = num8;
				triangles[tI++] = num10;
				triangles[tI++] = num7;
				triangles[tI++] = num7;
				triangles[tI++] = num9;
				triangles[tI++] = num8;
			}
		}

		public void GenerateValues()
		{
			NormalizedDirections = new Vector3[Points.Length];
			Ys = new float[NormalizedDirections.Length];
			Vector3 vector = Points[0];
			float num = UVStartY;
			Ys[0] = 0f;
			for (int i = 1; i < Points.Length; i++)
			{
				Vector3 vector2 = Points[i];
				Vector3 vector3 = vector2 - vector;
				float magnitude = vector3.magnitude;
				num += magnitude;
				Vector3 vector4 = vector3 / magnitude;
				int num2 = i - 1;
				NormalizedDirections[num2] = vector4;
				Ys[i] = num;
				vector = vector2;
			}
			NormalizedDirections[NormalizedDirections.Length - 1] = NormalizedDirections[NormalizedDirections.Length - 2];
		}
	}

	public Material LightningLightOnClouds;

	public Light LightSource;

	[Range(0f, 1f)]
	public float LightningToThunderRelation = 0.75f;

	[GAttribute6(1f, 50f, -1f)]
	public Vector2 MinMaxShotDelta = new Vector2(10f, 35f);

	[Space(16f)]
	public SoundBank SoundBank;

	[Space(32f)]
	[Header("Generation", order = 2)]
	public float MapSize = 1000f;

	public int MainSegmentsPow2;

	public float MainRndVal;

	public float BranchRndVal;

	public int Iterations;

	public float Probobility;

	public float BranchDirectionality;

	public float CloudYLevel = 100f;

	public float CloudAttraction;

	public float CloudWidthByYLevel = 0.2f;

	public float Damping;

	public float UntouchingLightninigSize = 2f;

	[Space(32f)]
	[Header("Rendering", order = 2)]
	public float CloudBlursIntensity;

	public float[] CloudBlurs;

	[Space(16f)]
	public float LightningIntensity = 1f;

	public float CloudScaterredLightIntensity = 1f;

	public float CloudForwardLightIntensity = 1f;

	public float LightIntensity = 1f;

	public float BlinkingSpeed = 5f;

	[GAttribute6(0f, 2f, -1f)]
	public Vector2 LightningDuration = new Vector2(0.1f, 0.8f);

	public long TimeFactor = 1L;

	private CloudsController.CloudLayer cloudLayer_0;



	private Mesh mesh_0;

	private MeshRenderer meshRenderer_0;

	private RenderTexture renderTexture_0;

	private MaterialPropertyBlock materialPropertyBlock_0;

	private Color color_0;

	private float float_0 = -1f;

	private float float_1;

	private Vector2 vector2_0;

	private float float_2;

	private static readonly int int_0 = Shader.PropertyToID("_CloudBorder");

	private static readonly int int_1 = Shader.PropertyToID("_MapTransform");

	private static readonly int int_2 = Shader.PropertyToID("_LightColor");


}
