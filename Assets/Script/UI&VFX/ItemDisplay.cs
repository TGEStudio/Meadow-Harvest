using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemDisplay : MonoBehaviour, IDeselectHandler, ISelectHandler
{
    private PlantObject _plant;
    public PlantObject plant { set { _plant = value; } }
    public int count { set { _count.text = value.ToString(); } }
    private bool _isSelected;
    public bool isSelected { get { return _isSelected; } }

    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Image _item;
    [SerializeField]
    private TextMeshProUGUI _count;
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _desc;

    void Start()
    {
        if (_icon != null)
            _icon.sprite = _plant.pSpriteIcon ?? _plant.pSpriteItem;
        if (_title != null)
            _title.text = _plant.pName;
        if (_desc != null)
            _desc.text = _plant.pDescription;
    }
    public PlantObject GetPlant()
    {
        return _plant;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _isSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        _isSelected = true;
    }
}
