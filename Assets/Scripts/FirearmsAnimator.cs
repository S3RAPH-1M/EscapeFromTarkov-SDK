using System;
using EFT;
using EFT.InventoryLogic;

// Token: 0x020005E4 RID: 1508
public class FirearmsAnimator : ObjectInHandsAnimator
{
	// Token: 0x0400225D RID: 8797
	public const string JAM_STATE_NAME = "JAM";

	// Token: 0x0400225E RID: 8798
	public const string FIRE_STATE_NAME = "FIRE";

	// Token: 0x0400225F RID: 8799
	public const string SEMIFIRE_STATE_NAME = "SA FIRE";

	// Token: 0x04002260 RID: 8800
	public const string DOUBLE_ACTION_FIRE_STATE_NAME = "DOUBLE_ACTION_FIRE";

	// Token: 0x04002261 RID: 8801
	public const string MISFIRE_STATE_NAME = "MISFIRE";

	// Token: 0x04002262 RID: 8802
	public const string SOFT_SLIDE_STATE_NAME = "SOFT_SLIDE";

	// Token: 0x04002263 RID: 8803
	public const string HARD_SLIDE_STATE_NAME = "HARD_SLIDE";

	// Token: 0x04002264 RID: 8804
	public const string FEED_STATE_NAME = "FEED";

	// Token: 0x04002265 RID: 8805
	public const string IDLE_STATE_NAME = "IDLE";

	// Token: 0x04002266 RID: 8806
	public const string IDLE_UNDERBARREL_NAME = "IDLE WEAPON";

	// Token: 0x04002267 RID: 8807
	public const string SPAWN_STATE_NAME = "SPAWN";

	// Token: 0x04002268 RID: 8808
	public const string PATROL_STATE_NAME = "PATROL";

	// Token: 0x04002269 RID: 8809
	public const string DRY_FIRE_STATE_NAME = "DRY FIRE";

	// Token: 0x0400226A RID: 8810
	public const string DRY_FIRE_DISARMED_STATE_NAME = "Hands.DRY FIRE DISARMED";

	// Token: 0x0400226B RID: 8811
	public const int HANDS_LAYER_INDEX = 1;

	// Token: 0x0400226C RID: 8812
	public const string HANDS_LAYER_NAME = "Hands";

	// Token: 0x0400226D RID: 8813
	public const string BOLT_CATCH_LAYER_NAME = "Catch";

	// Token: 0x0400226E RID: 8814
	public const string HAMMER_LAYER_NAME = "Hammer";

	// Token: 0x0400226F RID: 8815
	public const string ADDITIONAL_HANDS_LAYER_NAME = "Additional_Hands";

	// Token: 0x04002270 RID: 8816
	public const string STOCK_LAYER = "Stock";

	// Token: 0x04002271 RID: 8817
	public const string MALFUNCTION_LAYER = "Malfunction";

	// Token: 0x04002272 RID: 8818
	public const string LHANDS_LAYER = "LActions";

	// Token: 0x04002273 RID: 8819
	public int ADDITIONAL_HANDS_LAYER_INDEX;

	// Token: 0x04002274 RID: 8820
	public int BOLT_CATCH_LAYER_INDEX;

	// Token: 0x04002275 RID: 8821
	public int HAMMER_LAYER_INDEX;

	// Token: 0x04002276 RID: 8822
	public int STOCK_LAYER_INDEX;

	// Token: 0x04002277 RID: 8823
	public int MALFUNCTION_LAYER_INDEX;

	// Token: 0x04002278 RID: 8824
	public new int LACTIONS_LAYER_INDEX;

	// Token: 0x020005E5 RID: 1509
	public enum EGrenadeFire
	{
		// Token: 0x0400227E RID: 8830
		Idle,
		// Token: 0x0400227F RID: 8831
		Hold,
		// Token: 0x04002280 RID: 8832
		Throw
	}
}
