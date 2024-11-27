using System;
using UnityEngine;

namespace EFT.InventoryLogic
{
	public interface IAdjustableOpticData
	{
		bool IsAdjustableOptic { get; }
		Vector3 MinMaxFov { get; }
		float ZoomSensitivity { get; }
		float AdjustableOpticSensitivity { get; }
		float AdjustableOpticSensitivityMax { get; }
	}
}
