using System.Collections;
using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
	[SerializeField]
	private float _lerpToTargetRotationSpeed;

	[SerializeField]
	private float _angleDifForStartRotation;

	[SerializeField]
	private float _angleDifForStopRotation = 1f;

	[SerializeField]
	private bool _returnStartRotationOnEnd = true;

	[SerializeField]
	private float _returnToStartRotationTime = 1f;

	private Transform transform_0;

	private Transform transform_1;

	private Vector3 vector3_0;

	private Vector3 vector3_1;

	private Coroutine coroutine_0;

	private Coroutine coroutine_1;

	private Quaternion quaternion_0;

	private void OnDestroy()
	{
		method_0();
	}

	private void method_0()
	{
		ToggleWorking(enable: false);
		if (coroutine_1 != null)
		{
			StopCoroutine(coroutine_1);
			coroutine_1 = null;
		}
	}

	public void SetTransformForRotation(Transform forRotation)
	{
		transform_0 = forRotation;
	}

	public void SetTransformToLookAt(Transform toLookAt)
	{
		transform_1 = toLookAt;
	}

	public void ToggleWorking(bool enable)
	{
		if (enable)
		{
			if (transform_1 != null && transform_0 != null && coroutine_0 == null)
			{
				quaternion_0 = transform_0.localRotation;
				vector3_0 = transform_0.position + transform_0.forward - transform_0.position;
				vector3_1 = vector3_0;
				coroutine_0 = StartCoroutine(method_2());
			}
		}
		else if (coroutine_0 != null)
		{
			StopCoroutine(coroutine_0);
			coroutine_0 = null;
			if (_returnStartRotationOnEnd && transform_0 != null)
			{
				coroutine_1 = StartCoroutine(method_1());
			}
		}
	}

	private IEnumerator method_1()
	{
		Quaternion localRotation = transform_0.localRotation;
		float num = 0f;
		while (num <= 1f)
		{
			transform_0.localRotation = Quaternion.Lerp(localRotation, quaternion_0, num);
			num += Time.deltaTime / _returnToStartRotationTime;
			yield return null;
		}
		coroutine_1 = null;
	}

	public float GetTimeToLookAt()
	{
		Vector3 to = transform_1.position - transform_0.position;
		return Vector3.Angle(vector3_1, to) / _lerpToTargetRotationSpeed;
	}

	private IEnumerator method_2()
	{
		bool flag = false;
		while (!(transform_1 == null) && !(transform_0 == null))
		{
			vector3_0 = transform_1.position - transform_0.position;
			Quaternion b = Quaternion.LookRotation(vector3_0);
			float num = Quaternion.Angle(transform_0.rotation, b);
			if (!flag && num > _angleDifForStartRotation)
			{
				vector3_1 = Vector3.Lerp(vector3_1, vector3_0, Time.deltaTime * _lerpToTargetRotationSpeed);
				transform_0.rotation = Quaternion.LookRotation(vector3_1);
				flag = true;
			}
			else if (flag)
			{
				vector3_1 = Vector3.Lerp(vector3_1, vector3_0, Time.deltaTime * _lerpToTargetRotationSpeed);
				transform_0.rotation = Quaternion.LookRotation(vector3_1);
				if (num <= _angleDifForStopRotation)
				{
					flag = false;
				}
			}
			yield return null;
		}
		method_0();
	}
}
