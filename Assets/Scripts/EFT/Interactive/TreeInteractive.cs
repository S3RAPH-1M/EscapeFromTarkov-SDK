using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

namespace EFT.Interactive
{
	public class TreeInteractive : MonoBehaviour
	{
		public Terrain Terrain;

		public int InstanceIndex;

		[SerializeField]
		public SoundBank _soundBank;

		private Dictionary<Collider, BetterSource> dictionary_0 = new Dictionary<Collider, BetterSource>();

		private const float float_0 = 1f;

		private Dictionary<Collider, Player> dictionary_1 = new Dictionary<Collider, Player>();

		private float float_1 = 1f;

		private const float float_2 = -0.33f;

		private const float float_3 = 4.5f;

		private const float float_4 = 0.1f;

		private const float float_5 = 0.0233f;

		private const float float_6 = 0.5f;

		private float float_7;

		[CompilerGenerated]
		private readonly string string_0 = "TreeInteractive";

		public string Description
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
		}
	}
}
