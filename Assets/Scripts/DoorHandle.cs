using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000577 RID: 1399
[ExecuteInEditMode]
public class DoorHandle : MonoBehaviour
{
	// Token: 0x0600245F RID: 9311 RVA: 0x000AB958 File Offset: 0x000A9B58
	[ContextMenu("Open Position")]
	public void OpenPos()
	{
		base.transform.localRotation = Quaternion.Slerp(this.DefaultRotation, this.OpenRotation, 1f);
		if (this.pos)
		{
			base.transform.localPosition = Vector3.Lerp(this.DefaultPosition, this.OpenPosition, 1f);
		}
	}

	// Token: 0x06002460 RID: 9312 RVA: 0x000AB9B0 File Offset: 0x000A9BB0
	[ContextMenu("Default Position")]
	public void DefPos()
	{
		base.transform.localRotation = Quaternion.Slerp(this.OpenRotation, this.DefaultRotation, 1f);
		if (this.pos)
		{
			base.transform.localPosition = Vector3.Lerp(this.OpenPosition, this.DefaultPosition, 1f);
		}
	}

	// Token: 0x06002461 RID: 9313 RVA: 0x000ABA07 File Offset: 0x000A9C07
	public void Awake()
	{
		if (this.pos)
		{
			base.transform.localPosition = this.DefaultPosition;
			base.transform.localRotation = this.DefaultRotation;
		}
	}

	// Token: 0x06002462 RID: 9314 RVA: 0x000ABA33 File Offset: 0x000A9C33
	public void Open()
	{
		base.StartCoroutine(this.OpenCoroutine());
	}

	// Token: 0x06002463 RID: 9315 RVA: 0x000ABA42 File Offset: 0x000A9C42
	public IEnumerator OpenCoroutine()
	{
		if (this.DownSound != null && this.DownSound.Length != 0)
		{
			AudioClip audioClip = this.DownSound[UnityEngine.Random.Range(0, this.DownSound.Length)];
			if (audioClip == null)
			{
				Debug.LogError(string.Format("DoorHandle {0} has empty array of sounds", base.transform.parent));
			}
		}
		bool flag = false;
		if (this.OpenAnimation != null && this.OpenAnimation.length != 0)
		{
			float num = 0f;
			do
			{
				num += Time.deltaTime;
				float t = this.OpenAnimation.Evaluate(num);
				base.transform.localRotation = Quaternion.Slerp(this.DefaultRotation, this.OpenRotation, t);
				if (this.pos)
				{
					base.transform.localPosition = Vector3.Lerp(this.DefaultPosition, this.OpenPosition, t);
				}
				if (this.UpSound.Length != 0 && !flag && num > this.OpenAnimation[this.OpenAnimation.length - 1].time / 2f)
				{
					AudioClip audioClip2 = this.UpSound[UnityEngine.Random.Range(0, this.UpSound.Length)];
					if (audioClip2 == null)
					{
						Debug.LogError(string.Format("DoorHandle {0} has empty array of sounds", base.transform.parent));
					}
					flag = true;
				}
				yield return null;
			}
			while (num < this.OpenAnimation[this.OpenAnimation.length - 1].time);
			yield break;
		}
		Debug.LogErrorFormat(this, "Door handle doesn't have any open animation:" + base.transform.GetFullPath(true), Array.Empty<object>());
		yield break;
	}

	// Token: 0x04001FF9 RID: 8185
	private const int int_0 = 14;

	// Token: 0x04001FFA RID: 8186
	public Quaternion OpenRotation;

	// Token: 0x04001FFB RID: 8187
	public Quaternion DefaultRotation;

	// Token: 0x04001FFC RID: 8188
	public AnimationCurve OpenAnimation;

	// Token: 0x04001FFD RID: 8189
	public AnimationCurve LockedAnimation;

	// Token: 0x04001FFE RID: 8190
	public bool pos;

	// Token: 0x04001FFF RID: 8191
	public Vector3 OpenPosition;

	// Token: 0x04002000 RID: 8192
	public Vector3 DefaultPosition;

	// Token: 0x04002001 RID: 8193
	public AudioClip[] DownSound;

	// Token: 0x04002002 RID: 8194
	public AudioClip[] UpSound;

	// Token: 0x04002003 RID: 8195
	private float float_0;
}