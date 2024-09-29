using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceManager
{
	private Dictionary<PlantObject, int> _invCount = new Dictionary<PlantObject, int>();
	private Dictionary<PlantObject, int> _seedCount = new Dictionary<PlantObject, int>();

	public int GetSeedCount(PlantObject plant)
	{
		_seedCount.TryGetValue(plant, out int value);
		return value;
	}
	public Dictionary<PlantObject, int> GetSeedList()
	{
		return _seedCount;
	}
	public int GetInvCount(PlantObject plant)
	{
		_invCount.TryGetValue(plant, out int value);
		return value;
	}
	public Dictionary<PlantObject, int> GetInvList()
	{
		return _invCount;
	}
	public void ReduceSeed(PlantObject plant)
	{
		_seedCount[plant]--;

		if (_seedCount.TryGetValue(plant, out int value) && value <= 0)
			_seedCount.Remove(plant);
	}
	public void IncreaseSeed(PlantObject plant)
	{
		if (!_seedCount.ContainsKey(plant))
			_seedCount.Add(plant, 1);
		else
			_seedCount[plant]++;
	}
	public void ReduceInv(PlantObject plant)
	{
		_invCount[plant]--;

		if (_invCount.TryGetValue(plant, out int value) && value <= 0)
			_invCount.Remove(plant);
	}
	public void IncreaseInv(PlantObject plant)
	{
		if (!_invCount.ContainsKey(plant))
			_invCount.Add(plant, 1);
		else
			_invCount[plant]++;
	}
}
