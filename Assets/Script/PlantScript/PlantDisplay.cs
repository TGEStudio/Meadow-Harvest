using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantDisplay : MonoBehaviour
{
    [SerializeField]
    protected Field _field;
    [SerializeField]
    private GameObject addSeedButton;
    [SerializeField]
    protected GameObject waterIcon;
    [SerializeField]
    protected GameObject harvestIcon;
    public Field field { set { _field = value; } }
    private Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
        Logic.OnTick += Display;
    }

    public virtual void Display(object sender, EventArgs e)
    {
        waterIcon.GetComponent<Image>().enabled = _field.fIsWaterable;
        harvestIcon.GetComponent<Image>().enabled = _field.fIsHarvestable;
        
        if (_field.fPlantObj == null)
        {
            addSeedButton.SetActive(true);
            _image.sprite = Logic.UIManager.transSprite;
            return;
        }

        addSeedButton.SetActive(false);
        if (GetGrowStage() < 0 || GetGrowStage() >= _field.fPlantObj.pStage) return;

        _image.sprite = _field.fPlantObj.pSprites[GetGrowStage()];
    }
    int GetGrowStage()
    {
        TimeSpan timePassed = _field.fTimeNow-_field.fPlantTime;
        return (int)((int)timePassed.TotalSeconds/(_field.fPlantObj.pGrowTimeSec/_field.fPlantObj.pStage));
    }
}
