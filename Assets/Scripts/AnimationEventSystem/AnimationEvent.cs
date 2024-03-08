using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E35 RID: 3637
	[Serializable]
	public class AnimationEvent
	{
		// Token: 0x04005802 RID: 22530
		public const float MAX_EVENT_TIME = 1f;

		// Token: 0x04005803 RID: 22531
		public AnimationEventParameter Parameter;

		// Token: 0x04005804 RID: 22532
		[SerializeField]
		private string _functionName;

		// Token: 0x04005805 RID: 22533
		[SerializeField]
		private int _functionNameHash;

		// Token: 0x04005806 RID: 22534
		public bool Enabled = true;

		// Token: 0x04005807 RID: 22535
		[SerializeField]
		private float _time;

		// Token: 0x04005808 RID: 22536
		public List<EventCondition> EventConditions;
#if UNITY_EDITOR				
		public void UpdateHash()
        {
            // Change the Hash depending on the name
            // also change param type if the name supports it
            // Not Included; PutMagToRig, MessageName, ReplaceSecondMag, ShowAmmo, ShowMag, SliderOut, SoundAtPoint
            // UseSecondMagForReload, OnCurrentAnimStateEnded, OnSetActiveObject, OnDeactivateObject

            switch (_functionName) 
			{				
                case "AddAmmoInChamber":
                    _functionNameHash = -508605542;
                    break;
                case "AddAmmoInMag":
                    _functionNameHash = -1583670125;
                    break;
				case "Arm":
                    _functionNameHash = -386854108;
                    break;
				case "Cook":
                    _functionNameHash = 963907342;
                    break;
                case "DelAmmoChamber":
                    _functionNameHash = -945517627;
                    break;
                case "DelAmmoFromMag":
                    _functionNameHash = 1434365820;
                    break;
                case "Disarm":
                    _functionNameHash = 1239352288;
                    break;
                case "FireEnd":
                    _functionNameHash = -1677976749;
                    break;
                case "FiringBullet":
                    _functionNameHash = -58181185;
                    break;
                case "FoldOff":
                    _functionNameHash = -1051941490;
                    break;
                case "FoldOn":
                    _functionNameHash = 1704018560;
                    break;
                case "IdleStart":
                    _functionNameHash = 198060848;
                    break;
                case "LauncherAppeared":
                    _functionNameHash = 1390148366;
                    break;
                case "LauncherDisappeared":
                    _functionNameHash = 148436330;
                    break;
                case "MagHide":
                    _functionNameHash = 798565163;
                    break;
                case "MagIn":
                    _functionNameHash = 1258896930;
                    break;
                case "MagOut":
                    _functionNameHash = 1947938901;
                    break;
                case "MagShow":
                    _functionNameHash = 1551431816;
                    break;
                case "MalfunctionOff":
                    _functionNameHash = 1041383721;
                    break;
                case "ModChanged":
                    _functionNameHash = 1199378086;
                    break;
                case "OffBoltCatch":
                    _functionNameHash = 2091345647;
                    break;
                case "OnBoltCatch":
                    _functionNameHash = -1518700811;
                    break;
                case "RemoveShell":
                    _functionNameHash = 211630556;
                    break;
                case "ShellEject":
                    _functionNameHash = -1819682913;
                    break;
                case "StartUtilityOperation":
                    _functionNameHash = 1134400241;
                    break;
                case "ThirdAction":
                    _functionNameHash = -612501071;
                    Parameter.ParamType = (EAnimationEventParamType)1;
                    break;
                case "UseProp":
                    _functionNameHash = -1376281788;
                    Parameter.BoolParam = true;
                    break;
                case "WeapIn":
                    _functionNameHash = -224219248;
                    break;
                case "WeapOut":
                    _functionNameHash = 1174204865;
                    break;
                case "Sound":
                    _functionNameHash = 1554795451;
                    Parameter.ParamType = (EAnimationEventParamType)3;
                    break;
                default:
					_functionNameHash = 0;
                    Parameter.ParamType = 0;
                    Parameter.BoolParam = false;
                    break;
            }
        }
#endif
	}
}
