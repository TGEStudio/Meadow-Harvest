using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Plant", menuName = "New Plant")]
public class PlantObject : ScriptableObject
{
	[SerializeField]
    private string _pName;
	[SerializeField]
    private float _pCost;
	[SerializeField]
    private float _pGrowTimeSec;
	[SerializeField]
    private Sprite[] _pSprites;
	[SerializeField]
    private Sprite _pSpriteIcon;
	[SerializeField]
    private Sprite _pSpriteItem;

    public string pName { get { return _pName; } }
	public float pCost { get { return _pCost; } }
	public float pGrowTimeSec { get { return _pGrowTimeSec; } }
	public int pStage { get { return _pSprites.Length; } }
	public Sprite[] pSprites { get { return _pSprites; } }
	public Sprite pSpriteIcon { get { return _pSpriteIcon; } }
	public Sprite pSpriteItem { get { return _pSpriteItem; } }
}
