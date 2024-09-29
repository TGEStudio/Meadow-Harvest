using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIManager
{
    [SerializeField]
    private GameObject _inventoryUI;
    [SerializeField]
    private GameObject _plantingPar;
    [SerializeField]
    private GameObject _wateringPar;
    [SerializeField]
    private GameObject _collectingPar;
    [SerializeField]
    private Sprite _transSprite;

    public GameObject inventoryUI { get { return _inventoryUI; } }
    public GameObject plantingPar { get { return _plantingPar; } }
    public GameObject wateringPar { get { return _wateringPar; } }
    public GameObject collectingPar { get { return _collectingPar; } }
    public Sprite transSprite { get { return _transSprite; } }
}
