using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;

// Token: 0x02000132 RID: 306
[Serializable]
public class CustomNavigationPoint
{
	public Vector3 Position
	{
		get
		{
			return this._cachedPosition;
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x0600075D RID: 1885 RVA: 0x00023F64 File Offset: 0x00022164
	// (set) Token: 0x0600075E RID: 1886 RVA: 0x00023F6C File Offset: 0x0002216C
	public bool IsGoodInsideBuilding
	{
		get
		{
			return this._isGoodInsideBuilding;
		}
		set
		{
			this._isGoodInsideBuilding = value;
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x0600075F RID: 1887 RVA: 0x00023F75 File Offset: 0x00022175
	// (set) Token: 0x06000760 RID: 1888 RVA: 0x00023F7D File Offset: 0x0002217D
	public float CoveringWeight
	{
		get
		{
			return this._coveringWeight;
		}
		private set
		{
			this._coveringWeight = value;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06000761 RID: 1889 RVA: 0x00023F86 File Offset: 0x00022186
	public bool IsSpotted
	{
		get
		{
			if (this._blocked)
			{
				return false;
			}
			if (!this._isSpotted)
			{
				return false;
			}
			if (this._unSpottedTime < Time.time)
			{
				this._isSpotted = false;
				return false;
			}
			return true;
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06000762 RID: 1890 RVA: 0x00023FB3 File Offset: 0x000221B3
	// (set) Token: 0x06000763 RID: 1891 RVA: 0x00023FBB File Offset: 0x000221BB
	public float BaseWeight
	{
		get
		{
			return this._startBaseWeight;
		}
		set
		{
			if (value <= 1f)
			{
				this._startBaseWeight = 1f;
				return;
			}
			this._startBaseWeight = value;
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06000764 RID: 1892 RVA: 0x00023FD8 File Offset: 0x000221D8
	public ECoverPointSpecial Special
	{
		get
		{
			return this.CovPointsPlace.Special;
		}
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06000765 RID: 1893 RVA: 0x00023FE5 File Offset: 0x000221E5
	public int EnvironmentId
	{
		get
		{
			return this.CovPointsPlace.IdEnvironment;
		}
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00023FF4 File Offset: 0x000221F4
	public CustomNavigationPoint(int name, Vector3 position, Vector3? altPosition, Vector3 toWallVector, Vector3 firePosition, CoverLevel coverLevel, bool alwaysGood, PointWithNeighborType type, CoverPointDefenceInfo defenceInfo, int placeInfo, bool isGoodInsideBuilding, bool withInit = true)
	{
		this.Id = name;
		this.IsGoodInsideBuilding = isGoodInsideBuilding;
		this.PlaceId = placeInfo;
		this.BasePosition = position;
		this._cachedPosition = this.BasePosition;
		this.HaveAltPosition = false;
		if (altPosition != null && altPosition.Value != Vector3.zero)
		{
			this.HaveAltPosition = true;
			this.AltPosition = altPosition.Value;
		}
		this.FirePosition = firePosition;
		this.CoverLevel = coverLevel;
		this.AlwaysGood = alwaysGood;
		this.ToWallVector = toWallVector.normalized;
		this.StrategyType = type;
		if (withInit)
		{
			this.InitLightBorders();
			this.CovPointsPlaceSerializable = new CoverPointPlaceSerializable(this.Position, defenceInfo, CoverType.Wall, this.IsGoodInsideBuilding);
		}
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x000240EA File Offset: 0x000222EA
	public void SetWeight(float v, bool withBaseWeight = true)
	{
		if (withBaseWeight)
		{
			v *= this.BaseWeight;
		}
		this.CoveringWeight = v * this._decreasedWeightCoef;
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00024109 File Offset: 0x00022309
	public void SetClose()
	{
		this._cachedPosition = this.BasePosition;
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00024117 File Offset: 0x00022317
	public void SetLong()
	{
		if (this.HaveAltPosition)
		{
			this._cachedPosition = this.AltPosition;
		}
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x0002412D File Offset: 0x0002232D
	public void UpdateCoversFromIds(List<CustomNavigationPoint> allPoints)
	{
		this.CovPointsPlace.UpdateCoversFromIds(allPoints);
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x0002413B File Offset: 0x0002233B
	public void UpdateFromSerializable()
	{
		this.CovPointsPlace = new GClass256(this.CovPointsPlaceSerializable);
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x00024150 File Offset: 0x00022350
	public void InitLightBorders()
	{
		if (this.ToWallVector.sqrMagnitude > 0f)
		{
			this.LeftBorderLight = GClass777.RotateOnAngUp(this.ToWallVector, 57f);
			this.RightBorderLight = GClass777.RotateOnAngUp(this.ToWallVector, -57f);
			this.BordersLightHave = true;
			this.LeftBorderLight = GClass777.NormalizeFastSelf(this.LeftBorderLight);
			this.RightBorderLight = GClass777.NormalizeFastSelf(this.RightBorderLight);
			return;
		}
		this.BordersLightHave = false;
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00024454 File Offset: 0x00022654
	public void DrawSides()
	{
		Vector3 up = Vector3.up;
		Gizmos.color = Color.yellow;
		if (this.BordersLightHave)
		{
			if (this.CanLookLeft)
			{
				Gizmos.DrawRay(this.Position + up, this.LeftBorderLight);
			}
			if (this.CanLookRight)
			{
				Gizmos.DrawRay(this.Position + up, this.RightBorderLight);
			}
		}
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x000244B8 File Offset: 0x000226B8
	public void OnDrawGizmosAsAmbush(Vector3? cameraPos = null, float sDist = 0f, bool drawSides = true)
	{
		if (cameraPos != null && (this.Position - cameraPos.Value).sqrMagnitude > sDist)
		{
			return;
		}
		this.method_0();
		this.method_4();
		Vector3 up = Vector3.up;
		Gizmos.color = new Color(0.1f, 0.2f, 0.7f);
		Gizmos.DrawLine(this.Position, this.Position + up);
		if (this.HaveAltPosition)
		{
			Gizmos.DrawLine(this.AltPosition, this.AltPosition + up);
		}
		this.method_5();
		Gizmos.color = new Color(0.7f, 0.2f, 0.2f);
		Gizmos.DrawLine(this.Position + Vector3.right / 6f, this.Position + up + Vector3.right / 6f);
		Gizmos.DrawLine(this.Position + Vector3.left / 6f, this.Position + up + Vector3.left / 6f);
		Gizmos.DrawLine(this.Position + Vector3.back / 6f, this.Position + up + Vector3.back / 6f);
		Gizmos.DrawLine(this.Position + Vector3.forward / 6f, this.Position + up + Vector3.forward / 6f);
		Gizmos.color = new Color(0.5f, 1f, 0.2f);
		Vector3 from = this.Position + up;
		Vector3 to = this.Position + this.ToWallVector.normalized * 0.8f + up;
		Gizmos.DrawLine(from, to);
		Color color = new Color(0.9f, 0.5f, 0.1f);
		CoverLevel coverLevel = this.CoverLevel;
		if (coverLevel != CoverLevel.Sit)
		{
			if (coverLevel == CoverLevel.Lay)
			{
				color = new Color(0.1f, 0.9f, 0.3f);
			}
		}
		else
		{
			color = new Color(0.5f, 0.1f, 0.9f);
		}
		Gizmos.color = color;
		Gizmos.DrawSphere(this.Position + up, 0.166666672f);
		if (drawSides)
		{
			this.DrawSides();
		}
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x00024738 File Offset: 0x00022938
	public void OnDrawGizmosFullAsCover(Vector3? cameraPos = null, float sDist = 0f, bool drawSides = true)
	{
		if (cameraPos != null && sDist > -1f && (this.Position - cameraPos.Value).sqrMagnitude > sDist)
		{
			return;
		}
		if (this.DrawSign)
		{
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube(this.Position + Vector3.up * 2f, Vector3.one / 2f);
			Gizmos.DrawWireCube(this.Position + Vector3.up * 4f, Vector3.one / 2f);
			Gizmos.DrawWireCube(this.Position + Vector3.up * 6f, Vector3.one / 2f);
		}
		this.method_0();
		this.method_5();
		if (this.StrategyType == PointWithNeighborType.both)
		{
			Gizmos.color = new Color(1f, 0.4f, 0f);
			Gizmos.DrawWireCube(this.Position + Vector3.up * 0.5f, Vector3.one / 3f);
		}
		this.method_4();
		Vector3 b = Vector3.up;
		if (this.HaveAltPosition)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.AltPosition, this.AltPosition + b);
		}
		if (drawSides)
		{
			this.DrawSides();
		}
		if (this.AlwaysGood)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.Position, this.Position + b);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(this.Position + b, this.Position + b + Vector3.right / 2f);
			Gizmos.DrawLine(this.Position + b, this.Position + b + Vector3.left / 2f);
			Gizmos.DrawLine(this.Position + b, this.Position + b + Vector3.back / 2f);
			Gizmos.DrawLine(this.Position + b, this.Position + b + Vector3.forward / 2f);
			return;
		}
		if (this.ToWallVector != Vector3.zero)
		{
			float d = 0f;
			switch (this.CoverLevel)
			{
			case CoverLevel.Stay:
				d = 1.7f;
				break;
			case CoverLevel.Sit:
				d = 1f;
				break;
			case CoverLevel.Lay:
				d = 0.5f;
				break;
			}
			b = Vector3.up * d;
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.Position, this.Position + b);
			Gizmos.color = Color.red;
			Vector3 vector = this.Position + b;
			Vector3 vector2 = this.Position + this.ToWallVector.normalized * 0.8f + b;
			Gizmos.DrawLine(vector, vector2);
			Vector3 b2 = vector2 - vector;
			Vector3 normalized = GClass777.RotateOnAngUp(b2, 13f).normalized;
			Vector3 normalized2 = GClass777.RotateOnAngUp(b2, -13f).normalized;
			Gizmos.DrawLine(vector, vector + normalized);
			Gizmos.DrawLine(vector, vector + normalized2);
			if (this.FirePosition != Vector3.zero)
			{
				Vector3 firePosition = this.FirePosition;
				switch (this.CoverLevel)
				{
				case CoverLevel.Stay:
				{
					Vector3 position = this.Position;
					Gizmos.color = Color.yellow;
					position.y = firePosition.y;
					if (firePosition.x != 0f || firePosition.z != 0f)
					{
						Gizmos.DrawLine(firePosition, position);
						Gizmos.color = Color.green;
						Gizmos.DrawLine(firePosition, firePosition + this.ToWallVector.normalized * 0.8f);
					}
					break;
				}
				case CoverLevel.Sit:
				{
					Vector3 vector3 = this.Position + b;
					Gizmos.color = Color.magenta;
					Gizmos.DrawLine(vector3, vector3 + this.ToWallVector.normalized * 0.8f);
					return;
				}
				case CoverLevel.Lay:
				{
					Gizmos.color = Color.cyan;
					Vector3 vector4 = this.Position + b;
					Gizmos.DrawLine(vector4, vector4 + this.ToWallVector.normalized * 0.8f);
					return;
				}
				default:
					return;
				}
			}
		}
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x00024BDC File Offset: 0x00022DDC
	private void method_0()
	{
		Gizmos.color = Color.magenta;
		bool flag = this.CovPointsPlaceSerializable.IdEnvironment > 0 && this.CovPointsPlaceSerializable.EnvironmentType == EnvironmentType.Outdoor;
		bool flag2 = this.CovPointsPlaceSerializable.IdEnvironment == 0 && this.CovPointsPlaceSerializable.EnvironmentType == EnvironmentType.Indoor;
		if (this.CovPointsPlaceSerializable.IdEnvironment > 0)
		{
			Gizmos.DrawWireSphere(this.Position, 0.33f);
			if (flag)
			{
				Gizmos.color = Color.red;
			}
			Gizmos.DrawWireSphere(this.Position, 0.3f);
			if (flag2)
			{
				Gizmos.color = Color.red;
			}
			Gizmos.DrawWireSphere(this.Position, 0.23f);
		}
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x00024C8A File Offset: 0x00022E8A
	public void SetHideLevel(int lockCount)
	{
		this.HideLevel = lockCount;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x00024EC8 File Offset: 0x000230C8
	private void method_4()
	{
		float t = (float)this.HideLevel / 100f;
		Gizmos.color = Color.Lerp(Color.red, Color.green, t);
		float num = 0.3f;
		Gizmos.DrawCube(this.Position + Vector3.up * 0.5f, new Vector3(num, num, num));
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x00024F28 File Offset: 0x00023128
	private void method_5()
	{
		if (this.IsGoodInsideBuilding)
		{
			Gizmos.color = new Color(0.1f, 1f, 0f);
			Gizmos.DrawWireCube(this.Position + Vector3.up * 0.5f, new Vector3(0.3f, 1f, 0.2f));
		}
	}

	// Token: 0x040007A7 RID: 1959
	public const int BASE_HIDE_VAL = 51;

	// Token: 0x040007A8 RID: 1960
	public const float LIGHT_WALL_ANG = 57f;

	// Token: 0x040007A9 RID: 1961
	public const float MAX_DEFENCE_LEVEL_SIDE = 8f;

	// Token: 0x040007AA RID: 1962
	public const int MAX_HIDE_VAL = 100;

	// Token: 0x040007AB RID: 1963
	[SerializeField]
	private Vector3 _cachedPosition;

	// Token: 0x040007AC RID: 1964
	public int Id;

	// Token: 0x040007AD RID: 1965
	public Vector3 AltPosition;

	// Token: 0x040007AE RID: 1966
	public bool HaveAltPosition;

	// Token: 0x040007AF RID: 1967
	public Vector3 BasePosition;

	// Token: 0x040007B0 RID: 1968
	public CoverPointPlaceSerializable CovPointsPlaceSerializable;

	// Token: 0x040007B1 RID: 1969
	public GClass256 CovPointsPlace;

	// Token: 0x040007B2 RID: 1970
	public Vector3 ToWallVector;

	// Token: 0x040007B3 RID: 1971
	public Vector3 FirePosition;

	// Token: 0x040007B4 RID: 1972
	public BotTiltType TiltType;

	// Token: 0x040007B5 RID: 1973
	public CoverLevel CoverLevel;

	// Token: 0x040007B6 RID: 1974
	public bool AlwaysGood;

	// Token: 0x040007B7 RID: 1975
	public bool DrawSign;

	// Token: 0x040007B8 RID: 1976
	public bool BordersLightHave;

	// Token: 0x040007B9 RID: 1977
	public Vector3 LeftBorderLight;

	// Token: 0x040007BA RID: 1978
	public Vector3 RightBorderLight;

	// Token: 0x040007BB RID: 1979
	[HideInInspector]
	public bool CanIShootToEnemy;

	// Token: 0x040007BC RID: 1980
	[HideInInspector]
	public bool lastCanShoot;

	// Token: 0x040007BD RID: 1981
	public bool CanLookLeft;

	// Token: 0x040007BE RID: 1982
	public bool CanLookRight;

	// Token: 0x040007BF RID: 1983
	public int HideLevel = 51;

	// Token: 0x040007C0 RID: 1984
	public int PlaceId = -1;

	// Token: 0x040007C1 RID: 1985
	public PointWithNeighborType StrategyType;

	// Token: 0x040007C2 RID: 1986
	public CoverPointCreatorPreset coverPointCreatorPreset;

	// Token: 0x040007C3 RID: 1987
	private float _startBaseWeight = 1f;

	// Token: 0x040007C4 RID: 1988
	private bool _isSpotted;

	// Token: 0x040007C5 RID: 1989
	private bool _blocked;

	// Token: 0x040007C6 RID: 1990
	private float _spottedTime;

	// Token: 0x040007C7 RID: 1991
	private bool _isGoodInsideBuilding;

	// Token: 0x040007C8 RID: 1992
	private float _coveringWeight;

	// Token: 0x040007C9 RID: 1993
	private float _unSpottedTime;

	// Token: 0x040007CA RID: 1994
	private float _decreasedWeightCoef = 1f;

	// Token: 0x040007CB RID: 1995
	private float _nextCheckCanShootTime;
}