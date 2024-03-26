using UnityEngine;

public class SingleFlareController : MonoBehaviour
{
	public MultiFlareLight Light;

	public float Angle;

	public float YShift = 0.075f;

	public float StartWidth;

	private float float_0;

	private float float_1;

	private const float float_2 = 2f;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			method_0();
		}
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void method_0()
	{
		if (Light == null)
		{
			Light = GetComponent<MultiFlareLight>();
		}
		if (Light == null)
		{
			if (Application.isPlaying)
			{
				Debug.LogError(base.gameObject.name + "(SingleFlareController) Light is not set");
			}
		}
		else
		{
			float_0 = Angle - 1f;
			float_1 = 1f / Angle;
		}
	}

	private void Awake()
	{
		method_0();
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{

	}
}
