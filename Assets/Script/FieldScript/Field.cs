using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private PlantObject _fPlantObj;
    private bool _fIsWaterable;
    private bool _fIsHarvestable;
    private bool _fIsUnlocked;
    private float _fWaterTime;
    private DateTime _fPlantTime;
    private DateTime _fTimeNow;
    private DateTime _lastTimeWater;
    private TimeSpan _fTimeRemaining;

    public PlantObject fPlantObj { get { return _fPlantObj; } set { _fPlantObj = value; } }
    public bool fIsWaterable { get { return _fIsWaterable; } set { _fIsWaterable = value; } }
    public bool fIsHarvestable { get { return _fIsHarvestable; } set { _fIsHarvestable = value; } }
    public DateTime fPlantTime { get { return _fPlantTime; } set { _fPlantTime = value; } }
    public DateTime fTimeNow { get { return _fTimeNow; } set { _fTimeNow = value; } }
    public float fWaterTime { get { return _fWaterTime; } set { _fWaterTime = value; } }
    public TimeSpan fTimeRemaining { get { return _fTimeRemaining; } set { _fTimeRemaining = value; } }

    void Awake()
    {
        Logic.OnTick += CheckIsHarvestable;
        Logic.OnTick += CheckIsWaterable;
        Logic.OnTick += CheckTimeRemaining;
        Logic.OnTick += UpdateTimeNow;
    }


    public void StartPlant()
    {
        fPlantTime = _fTimeNow;
        _lastTimeWater = DateTime.MinValue;
    }
    public void Watering()
    {
        _fIsWaterable = false;
        _lastTimeWater = _fTimeNow;
        _fWaterTime += _fPlantObj.pGrowTimeSec / _fPlantObj.pStage * Logic.FieldManager.waterEffectiveness;
    }
    public void Harvesting()
    {
        _fIsHarvestable = false;
        Logic.ResourceManager.IncreaseInv(_fPlantObj);
        _fPlantObj = null;
        _lastTimeWater = DateTime.MinValue;
    }

    void UpdateTimeNow(object sender, EventArgs e)
    {
        _fTimeNow = DateTime.Now.AddSeconds(_fWaterTime);
    }
    void CheckTimeRemaining(object sender, EventArgs e)
    {
        if (_fPlantObj == null) return;

        _fTimeRemaining = _fPlantTime.AddSeconds(_fPlantObj.pGrowTimeSec) - _fTimeNow;
    }
    void CheckIsWaterable(object sender, EventArgs e)
    {
        if (_fPlantObj == null) return;

        if (_fIsHarvestable)
        {
            _fIsWaterable = false;
            return;
        }

        if (_fIsWaterable) return;

        float timeThen = _fPlantObj.pGrowTimeSec * Logic.FieldManager.wateringCooldown;

        if (_fTimeNow > _lastTimeWater.AddSeconds(timeThen))
        {
            _fIsWaterable = true;
        }
    }
    void CheckIsHarvestable(object sender, EventArgs e)
    {
        if (_fPlantObj == null) return;

        if (fTimeNow >= fPlantTime.AddSeconds(fPlantObj.pGrowTimeSec))
        {
            _fIsHarvestable = true;
            return;
        }
    }
}
