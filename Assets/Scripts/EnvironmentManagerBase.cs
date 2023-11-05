using System.Collections.Generic;
using System.Threading.Tasks;
using EFT;
using EFT.EnvironmentEffect;
using JetBrains.Annotations;
using UnityEngine;

public class EnvironmentManagerBase : MonoBehaviour
{
	public interface GInterface16
	{
		void Reinit();

		IndoorTrigger Check(Vector3 pos);
	}

	protected TriggerGroup _rootTriggerGroup;

	private bool bool_0;

	private bool bool_1 = true;

	protected static EnvironmentManagerBase _instance;

	public static EnvironmentManagerBase Instance => _instance;
}
