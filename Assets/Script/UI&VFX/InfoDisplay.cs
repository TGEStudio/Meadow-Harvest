using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    [SerializeField]
    private ItemDisplay infoDisplay;
    [SerializeField]
    private ItemDisplay itemChoose;
    [SerializeField]
    private GameObject displayObj;

    public void selectPlant(PlantObject plant, ItemDisplay itemDisplay)
    {
        infoDisplay.plant = plant;
        itemChoose = itemDisplay;
    }
    void Awake()
    {
        Logic.OnTick += (object sender, EventArgs e) =>
        {
            displayObj.SetActive(itemChoose != null);
        };
    }
}
