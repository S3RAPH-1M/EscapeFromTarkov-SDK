using System;
using EFT.Ballistics;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class BaseBallistic : MonoBehaviour
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x00099503 File Offset: 0x00097703
	public virtual BaseBallistic.ESurfaceSound GetSurfaceSound(Vector3 position)
	{
		return this.SurfaceSound;
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x000349C7 File Offset: 0x00032BC7
	public virtual BallisticCollider Get(Vector3 pos)
	{
		return null;
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x0009950C File Offset: 0x0009770C
	public void Associate(MaterialType typeOfMaterial)
	{
		switch (typeOfMaterial)
		{
		case MaterialType.Asphalt:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Asphalt;
			return;
		case MaterialType.Body:
		case MaterialType.Fabric:
		case MaterialType.GenericSoft:
		case MaterialType.Plastic:
		case MaterialType.Tyre:
		case MaterialType.Rubber:
		case MaterialType.GenericHard:
		case MaterialType.BodyArmor:
			break;
		case MaterialType.Cardboard:
		case MaterialType.GarbagePaper:
		case MaterialType.WoodThin:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Wood;
			return;
		case MaterialType.Chainfence:
		case MaterialType.Grate:
		case MaterialType.MetalThick:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Metal;
			return;
		case MaterialType.Concrete:
		case MaterialType.Stone:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Concrete;
			return;
		case MaterialType.GarbageMetal:
		case MaterialType.MetalThin:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.MetalThin;
			return;
		case MaterialType.Glass:
		case MaterialType.GlassShattered:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Glass;
			return;
		case MaterialType.GrassHigh:
		case MaterialType.GrassLow:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Grass;
			return;
		case MaterialType.Gravel:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Gravel;
			return;
		case MaterialType.Mud:
		case MaterialType.Soil:
		case MaterialType.SoilForest:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Soil;
			return;
		case MaterialType.Pebbles:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Slate;
			return;
		case MaterialType.Tile:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Tile;
			return;
		case MaterialType.Water:
		case MaterialType.WaterPuddle:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Puddle;
			return;
		case MaterialType.WoodThick:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.WoodThick;
			return;
		case MaterialType.Swamp:
			this.SurfaceSound = BaseBallistic.ESurfaceSound.Swamp;
			break;
		default:
			return;
		}
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x0009961A File Offset: 0x0009781A
	public virtual void TakeSettingsFrom(BaseBallistic collider)
	{
		this.SurfaceSound = collider.SurfaceSound;
	}

	// Token: 0x04001BAA RID: 7082
	[HideInInspector]
	public BaseBallistic.ESurfaceSound SurfaceSound;

	// Token: 0x02000487 RID: 1159
	public enum ESurfaceSound
	{
		// Token: 0x04001BAC RID: 7084
		Concrete,
		// Token: 0x04001BAD RID: 7085
		Metal,
		// Token: 0x04001BAE RID: 7086
		Wood,
		// Token: 0x04001BAF RID: 7087
		Soil,
		// Token: 0x04001BB0 RID: 7088
		Grass,
		// Token: 0x04001BB1 RID: 7089
		Asphalt,
		// Token: 0x04001BB2 RID: 7090
		Glass,
		// Token: 0x04001BB3 RID: 7091
		Gravel,
		// Token: 0x04001BB4 RID: 7092
		MetalThin,
		// Token: 0x04001BB5 RID: 7093
		Puddle,
		// Token: 0x04001BB6 RID: 7094
		Slate,
		// Token: 0x04001BB7 RID: 7095
		Tile,
		// Token: 0x04001BB8 RID: 7096
		WoodThick,
		// Token: 0x04001BB9 RID: 7097
		Swamp
	}
}
