using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant
{
    public PlantObject plantObj;
    public int growStage;
    public TimeSpan timeRemaining;
    public DateTime timeNow;
    public bool isWaterable;
    public bool isHarvestable;
}
