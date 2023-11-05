using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SceneLights : MonoBehaviour
{
	public static List<Light> AllLights = new List<Light>();

	[SerializeField]
	private Light[] _lights;

	
}
