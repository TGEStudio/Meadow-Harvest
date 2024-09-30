using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSpawnIn : ItemSpawnIn
{
    void OnEnable()
    {
        SpawnItem(Logic.ResourceManager.GetInvList());
    }
}
