using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform parPos;
    public void SelectField(Field field)
    {
        Logic.FieldManager.selectedField = field;
    }
    public void Watering()
    {
        GameObject par = Instantiate(Logic.UIManager.wateringPar, parPos.position, Quaternion.identity);
        Destroy(par, 5f);
        Logic.FieldManager.selectedField.Watering();
    }
    public void Harvesting()
    {
        GameObject par2 = Instantiate(Logic.UIManager.collectingPar, parPos.position, Quaternion.identity);
        par2.GetComponent<ParticleSystem>().textureSheetAnimation.SetSprite(0, Logic.FieldManager.selectedField.fPlantObj.pSpriteItem);
        Destroy(par2, 5f);
        Logic.FieldManager.selectedField.Harvesting();
    }
}
