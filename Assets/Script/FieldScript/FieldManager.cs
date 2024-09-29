using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FieldManager
{
    private Field _selectedField;
    [SerializeField]
    private float _waterEffectiveness;
    [SerializeField]
    private float _wateringCooldown;
    public Field selectedField { get { return _selectedField; } set { _selectedField = value; } }
    public float waterEffectiveness { get { return _waterEffectiveness; } set { _waterEffectiveness = value; } }
    public float wateringCooldown { get { return _wateringCooldown; } set { _wateringCooldown = value; } }

    public void SetSeed(PlantObject plant)
    {
        _selectedField.fPlantObj = plant;
        _selectedField.StartPlant();
        Logic.ResourceManager.ReduceSeed(plant);
    }

}
