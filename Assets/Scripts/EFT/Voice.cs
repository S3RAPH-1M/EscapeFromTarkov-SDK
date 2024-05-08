using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Voice", menuName = "ScriptableObjects/TarkovCustomVoices/Voice", order = 1)]
public sealed class Voice : ScriptableObject
{
	public string Name;

	public TagBank[] Banks;
}
