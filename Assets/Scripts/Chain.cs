using System;

[Serializable]
public class Chain
{
	public EPhraseTrigger Event;

	public int Probability;

	public Chain.ESpeaker Who;

	public enum ESpeaker
	{
		Self,
		Group,
		Other
	}
}
