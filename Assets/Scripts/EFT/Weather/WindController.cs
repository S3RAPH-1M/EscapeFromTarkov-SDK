using System;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.SpeedTree;
using UnityEngine;

namespace EFT.Weather
{
	public class WindController : MonoBehaviour
	{


		private static readonly int int_0 = Shader.PropertyToID("_BilboardTreesWindPower");

		private static readonly int int_1 = Shader.PropertyToID("_WindVector");

		private static readonly int int_2 = Shader.PropertyToID("_PrevWindVector");

		private static readonly int int_3 = Shader.PropertyToID("_ST_WindVector");

		public ComputeShader _windShader;

		public WiresController Wires;

		public float RainWindMultiplier = 1f;

		public float CloudWindMultiplier = 1f;

		public float BilboardTreesWindMultiplier = 0.4f;

		[SerializeField]
		private Vector2 defaultWindVector = new Vector2(0.05f, 0.1f);

		private Vector2 vector2_0 = Vector2.zero;

		

	}
}
