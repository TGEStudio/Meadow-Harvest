using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    private PlantObject _plant;
    public PlantObject plant { set { _plant = value; } }
    public int count { set { _count.text = value.ToString(); } }

    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _count;
    [SerializeField]
    private TextMeshProUGUI _title;

    void Start()
    {
        _icon.sprite = _plant.pSpriteIcon;
        _title.text = _plant.pName;
    }
}
