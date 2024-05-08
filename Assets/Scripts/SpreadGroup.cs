using System;
using CommonAssets.Scripts.Audio;

[Serializable]
public class SpreadGroup
{
	public ELoudnessType LoudnessType = ELoudnessType.Normal;

	public int Falloff = 50;

	public float Volume = 1f;

	public TaggedClip[] Clips = new TaggedClip[0];
}
