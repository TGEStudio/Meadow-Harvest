using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawnIn : MonoBehaviour
{
    [SerializeField]
    private RectTransform spawnParent;
    [SerializeField]
    private GameObject itemObj;
    [SerializeField]
    private InfoDisplay infoDisplay;

    protected void SpawnItem(Dictionary<PlantObject, int> list)
    {
        foreach (var item in list)
        {
            GameObject seed = Instantiate(itemObj);
            seed.transform.SetParent(spawnParent);
            seed.GetComponent<ItemDisplay>().plant = item.Key;
            seed.GetComponent<ItemDisplay>().count = item.Value;
            seed.GetComponent<Button>().onClick.AddListener(() => 
            {
                infoDisplay.selectPlant(item.Key, seed.GetComponent<ItemDisplay>());
            });
        }
    }
    void OnDisable()
    {
        foreach (Transform item in spawnParent)
        {
            Destroy(item.gameObject);
        }
    }
}
