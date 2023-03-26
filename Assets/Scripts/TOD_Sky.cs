using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020000BC RID: 188
[RequireComponent(typeof(TOD_Resources))]
[ExecuteInEditMode]
[RequireComponent(typeof(TOD_Components))]
public class TOD_Sky : MonoBehaviour
{
	// Token: 0x0400041D RID: 1053
	private static List<TOD_Sky> list_0 = new List<TOD_Sky>();

	// Token: 0x0400041E RID: 1054
	private int int_0 = -1;

	// Token: 0x0400041F RID: 1055
	public TOD_ColorSpaceType ColorSpace;

	// Token: 0x04000420 RID: 1056
	public TOD_ColorRangeType ColorRange;

	// Token: 0x04000421 RID: 1057
	public TOD_SkyQualityType SkyQuality;

	// Token: 0x04000422 RID: 1058
	public TOD_CloudQualityType CloudQuality = TOD_CloudQualityType.Bumped;

	// Token: 0x04000423 RID: 1059
	public TOD_MeshQualityType MeshQuality = TOD_MeshQualityType.High;

	// Token: 0x04000424 RID: 1060
	public TOD_CycleParameters Cycle;

	// Token: 0x04000425 RID: 1061
	public TOD_WorldParameters World;

	// Token: 0x04000426 RID: 1062
	public TOD_AtmosphereParameters Atmosphere;

	// Token: 0x04000427 RID: 1063
	public TOD_DayParameters Day;

	// Token: 0x04000428 RID: 1064
	public TOD_NightParameters Night;

	// Token: 0x04000429 RID: 1065
	public TOD_SunParameters Sun;

	// Token: 0x0400042A RID: 1066
	public TOD_MoonParameters Moon;

	// Token: 0x0400042B RID: 1067
	public TOD_StarParameters Stars;

	// Token: 0x0400042C RID: 1068
	public TOD_CloudParameters Clouds;

	// Token: 0x0400042D RID: 1069
	public TOD_LightParameters Light;

	// Token: 0x0400042E RID: 1070
	public TOD_FogParameters Fog;

	// Token: 0x0400042F RID: 1071
	public TOD_AmbientParameters Ambient;

	// Token: 0x04000430 RID: 1072
	public TOD_ReflectionParameters Reflection;

	// Token: 0x04000431 RID: 1073
	[CompilerGenerated]
	private bool bool_0;

	// Token: 0x04000432 RID: 1074
	[CompilerGenerated]
	private TOD_Components tod_Components_0;

	// Token: 0x04000433 RID: 1075
	[CompilerGenerated]
	private TOD_Resources tod_Resources_0;

	// Token: 0x04000434 RID: 1076
	[CompilerGenerated]
	private bool bool_1;

	// Token: 0x04000435 RID: 1077
	[CompilerGenerated]
	private bool bool_2;

	// Token: 0x04000436 RID: 1078
	[CompilerGenerated]
	private float float_0;

	// Token: 0x04000437 RID: 1079
	[CompilerGenerated]
	private float float_1;

	// Token: 0x04000438 RID: 1080
	[CompilerGenerated]
	private float float_2;

	// Token: 0x04000439 RID: 1081
	[CompilerGenerated]
	private Vector3 vector3_0;

	// Token: 0x0400043A RID: 1082
	[CompilerGenerated]
	private Vector3 vector3_1;

	// Token: 0x0400043B RID: 1083
	[CompilerGenerated]
	private Vector3 vector3_2;

	// Token: 0x0400043C RID: 1084
	[CompilerGenerated]
	private Vector3 vector3_3;

	// Token: 0x0400043D RID: 1085
	[CompilerGenerated]
	private Vector3 vector3_4;

	// Token: 0x0400043E RID: 1086
	[CompilerGenerated]
	private Vector3 vector3_5;

	// Token: 0x0400043F RID: 1087
	[CompilerGenerated]
	private Color color_0;

	// Token: 0x04000440 RID: 1088
	[CompilerGenerated]
	private Color color_1;

	// Token: 0x04000441 RID: 1089
	[CompilerGenerated]
	private Color color_2;

	// Token: 0x04000442 RID: 1090
	[CompilerGenerated]
	private Color color_3;

	// Token: 0x04000443 RID: 1091
	[CompilerGenerated]
	private Color color_4;

	// Token: 0x04000444 RID: 1092
	[CompilerGenerated]
	private Color color_5;

	// Token: 0x04000445 RID: 1093
	[CompilerGenerated]
	private Color color_6;

	// Token: 0x04000446 RID: 1094
	[CompilerGenerated]
	private Color color_7;

	// Token: 0x04000447 RID: 1095
	[CompilerGenerated]
	private Color color_8;

	// Token: 0x04000448 RID: 1096
	[CompilerGenerated]
	private Color color_9;

	// Token: 0x04000449 RID: 1097
	[CompilerGenerated]
	private Color color_10;

	// Token: 0x0400044A RID: 1098
	[CompilerGenerated]
	private Color color_11;

	// Token: 0x0400044B RID: 1099
	[CompilerGenerated]
	private Color color_12;

	// Token: 0x0400044C RID: 1100
	[CompilerGenerated]
	private ReflectionProbe reflectionProbe_0;

	// Token: 0x0400044D RID: 1101
	private float float_3 = float.MaxValue;

	// Token: 0x0400044E RID: 1102
	private float float_4 = float.MaxValue;

	// Token: 0x0400044F RID: 1103
	private float float_5 = float.MaxValue;

	// Token: 0x04000450 RID: 1104
	private float float_6;

	// Token: 0x04000451 RID: 1105
	private float float_7;

	// Token: 0x04000452 RID: 1106
	private const int int_1 = 2;

	// Token: 0x04000453 RID: 1107
	private Vector3 vector3_6;

	// Token: 0x04000454 RID: 1108
	private Vector4 vector4_0;

	// Token: 0x04000455 RID: 1109
	private Vector4 vector4_1;

	// Token: 0x04000456 RID: 1110
	private Vector4 vector4_2;

	// Token: 0x04000457 RID: 1111
	private Vector4 vector4_3;

	// Token: 0x04000458 RID: 1112
	[Tooltip("sLerp debug rotation speed")]
	public float rotationSpeed = 1f;

	// Token: 0x04000459 RID: 1113
	private const float float_8 = 3.1415927f;

	// Token: 0x0400045A RID: 1114
	private const float float_9 = 6.2831855f;

	// Token: 0x0400045B RID: 1115
	private float float_10;

	// Token: 0x0400045C RID: 1116
	private float float_11;

	// Token: 0x0400045D RID: 1117
	private float float_12;

	// Token: 0x0400045E RID: 1118
	private float float_13;

	// Token: 0x0400045F RID: 1119
	private Quaternion quaternion_0;

	// Token: 0x04000460 RID: 1120
	private Quaternion quaternion_1;
}
