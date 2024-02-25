using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsToggleByDistance : MonoBehaviour
{
	[Tooltip("Default state of game objects enable or disable")]
	[SerializeField]
	private bool defaultObjectsState = true;

	[SerializeField]
	private List<GameObject> objectsForToggle = new List<GameObject>();

	[SerializeField]
	private Transform pointForCalculation;

	[SerializeField]
	private float distanceForToggle = 0.01f;

	[SerializeField]
	private bool autoStart;

	private Coroutine coroutine_0;

	private float float_0;

	private List<Transform> list_0 = new List<Transform>();

	private WaitForEndOfFrame waitForEndOfFrame_0 = new WaitForEndOfFrame();
}
