using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplaySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject itemBase;
    public void SpawnItems()
    {
        foreach (var item in Logic.ResourceManager.GetSeedList())
        {
            GameObject itemSpawn = Instantiate(itemBase);
            itemSpawn.transform.SetParent(this.transform);
            ItemDisplay itemDisplay = itemSpawn.GetComponent<ItemDisplay>();

            itemSpawn.GetComponent<Button>().onClick.AddListener(() => {
                Logic.FieldManager.SetSeed(item.Key);
                SpawnPlantingPar(Logic.FieldManager.selectedField.transform);
                DespawnItems();
                Logic.UIManager.inventoryUI.SetActive(false);
            });
            SetItemDisplay(itemDisplay, item);
        }
    }
    void SpawnPlantingPar(Transform spawnPos)
    {
        GameObject par = Instantiate(Logic.UIManager.plantingPar, spawnPos.position, Quaternion.identity);
        Destroy(par, 2f);
    }
    public void DespawnItems()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        } 
    }
    void SetItemDisplay(ItemDisplay itemDisplay, KeyValuePair<PlantObject, int> item)
    {
        itemDisplay.plant = item.Key;
        itemDisplay.count = item.Value;
    }
}
