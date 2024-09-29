using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlantManager 
{
	[SerializeField]
    private List<PlantObject> _plantList = new List<PlantObject>();
	public List<PlantObject> GetPlantList()
	{
		return _plantList;
	}
}
