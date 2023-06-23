using System;
using UnityEngine;

namespace EFT
{
	public sealed class LocationExportInfo : MonoBehaviour
	{
		[ContextMenu("Set current time")]
		public void SetTime()
		{
			_unixDateTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}
		
		[SerializeField]
		public long _unixDateTime;
	}
}