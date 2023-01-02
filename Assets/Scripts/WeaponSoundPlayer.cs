using System;
using EFT;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x020007F8 RID: 2040
public class WeaponSoundPlayer : BaseSoundPlayer
{
	// Token: 0x04002F8E RID: 12174
	public SoundBank Body;

	// Token: 0x04002F8F RID: 12175
	public SoundBank Tail;

	// Token: 0x04002F90 RID: 12176
	public SoundBank Doublet;

	// Token: 0x04002F91 RID: 12177
	public SoundBank BodySilenced;

	// Token: 0x04002F92 RID: 12178
	public SoundBank TailSilenced;

	// Token: 0x04002F93 RID: 12179
	public SoundBank DoubletSilenced;

	// Token: 0x04002F94 RID: 12180
	private bool _isSilenced;

	// Token: 0x04002F95 RID: 12181
	private float _prevDistance;

	// Token: 0x04002F97 RID: 12183
	private bool _isFiring;

	// Token: 0x04002F99 RID: 12185
	private float _firingLoopLength;

	// Token: 0x04002F9A RID: 12186
	private const int BEATS = 16;

	// Token: 0x04002F9B RID: 12187
	public bool Non_auto;

	// Token: 0x04002F9C RID: 12188
	private float _releaseTime;

	// Token: 0x04002F9D RID: 12189
	private float _occlusionReleaseTime;

	// Token: 0x04002F9E RID: 12190
	public const float SOUND_SPEED = 340.29f;

	// Token: 0x04002F9F RID: 12191
	private float _pitch = 1f;

	// Token: 0x04002FA0 RID: 12192
	private float _balance = 1f;

	// Token: 0x04002FA1 RID: 12193
	private float _tailLn;

	// Token: 0x04002FA2 RID: 12194
	private float _start;

	// Token: 0x04002FA3 RID: 12195
	private float _delay;

	// Token: 0x04002FA4 RID: 12196
	private float _prevPitchMult;
}
