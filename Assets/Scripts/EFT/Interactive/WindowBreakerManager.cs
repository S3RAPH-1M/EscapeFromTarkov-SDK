using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT.Ballistics;
using UnityEngine;

namespace EFT.Interactive
{

	public sealed class WindowBreakerManager : MonoBehaviour
	{
		public interface GInterface293
		{
			void Break(WindowBreakingConfig.Crack crack, in Vector3 position, in Vector3 force, float angle);
		}

		private struct Struct632
		{
			public GInterface293 Breakable;

			public WindowBreakingConfig.Crack Crack;

			public Vector3 Position;

			public Vector3 Force;

			public float Angle;
		}

		private const int int_0 = 5000;

		[CompilerGenerated]
		private static WindowBreakerManager windowBreakerManager_0;

		private static readonly Queue<Struct632> queue_0 = new Queue<Struct632>();

		[SerializeField]
		private BrokenWindowPieceTemplate _stuckPiecePrefab;



		public static WindowBreakerManager Instance
		{
			[CompilerGenerated]
			get
			{
				return windowBreakerManager_0;
			}
			[CompilerGenerated]
			private set
			{
				windowBreakerManager_0 = value;
			}
		}

		

		

	}
}
