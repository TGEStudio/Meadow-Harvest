using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawnIn : ItemSpawnIn
{
    void OnEnable()
    {
        SpawnItem(Logic.ResourceManager.GetSeedList());
    }
}
