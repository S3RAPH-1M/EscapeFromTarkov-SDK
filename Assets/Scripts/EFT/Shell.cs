using System.Runtime.CompilerServices;
using EFT.Ballistics;
using UnityEngine;

namespace EFT
{
	public class Shell : BouncingObject
	{
		[SerializeField]
		private ECaliber _caliber;
	}
}
