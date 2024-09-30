using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantDisplayFocus : PlantDisplay
{
    [SerializeField]
    private TextMeshProUGUI pName;
    [SerializeField]
    private TextMeshProUGUI timeTextLight;
    [SerializeField]
    private TextMeshProUGUI timeTextDark;
    [SerializeField]
    private GameObject sliderObj;
    [SerializeField]
    private Slider timeBar;
    public override void Display(object sender, EventArgs e)
    {
        _field = Logic.FieldManager.selectedField;

        base.Display(sender, e);


        if (_field.fPlantObj == null)
        {
            sliderObj.SetActive(false);
            pName.text = "";
            return;
        }

        sliderObj.SetActive(true);
        pName.text = _field.fPlantObj.pName;

        SetTimeBar();
        SetTimeRemaining();
    }
    void SetTimeBar()
    {
        float progress = (float)_field.fTimeRemaining.TotalSeconds/_field.fPlantObj.pGrowTimeSec;
        timeBar.value = progress * 100;
    }
    void SetTimeRemaining()
    {
        if (_field.fIsHarvestable)
        {
            timeTextDark.text = "Harvestable";
            return;
        }
        timeTextDark.text = (_field.fTimeRemaining.Days > 0 ? $"{_field.fTimeRemaining.Days}d: " : "") +
                            (_field.fTimeRemaining.Hours > 0 ? $"{_field.fTimeRemaining.Hours}h: " : "") +
                            (_field.fTimeRemaining.Minutes > 0 ? $"{_field.fTimeRemaining.Minutes}m: " : "") +
                            (_field.fTimeRemaining.Seconds > 0 ? $"{_field.fTimeRemaining.Seconds}s" : "").TrimEnd(':', ' ');
        timeTextLight.text = timeTextDark.text;
    }
}
