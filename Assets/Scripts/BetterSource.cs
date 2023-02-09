using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x02000788 RID: 1928
public abstract class BetterSource : MonoBehaviour
{
	// Token: 0x04002D48 RID: 11592
	private const float TOO_CLOSE_FOR_BINAURAL = 1.5f;

	// Token: 0x04002D49 RID: 11593
	public AudioSource source1;

	// Token: 0x04002D51 RID: 11601
	public bool checkEveryFrame;
}