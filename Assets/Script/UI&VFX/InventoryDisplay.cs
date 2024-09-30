using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private RectTransform openRect;
    [SerializeField]
    private RectTransform closeRect;
    [SerializeField]
    private GameObject[] tabObj;
    [SerializeField]
    private RectTransform[] tabButton;
    [SerializeField]
    private TextMeshProUGUI[] tabText;
    [SerializeField]
    private Color darkColor;
    [SerializeField]
    private Color lightColor;
    public void CloseAllTab()
    {
        for (int i = 0; i < 3; i++)
        {
            tabButton[i].SetParent(closeRect);
            tabText[i].color = darkColor;
            tabObj[i].SetActive(false);
        }
    }
    public void OpenTab(int tabID)
    {
        CloseAllTab();
        tabButton[tabID].SetParent(openRect);
        tabText[tabID].color = lightColor;
        tabObj[tabID].SetActive(true);
    }
    void OnEnable()
    {
        OpenTab(0);
    }
    void OnDisable()
    {
        CloseAllTab();
    }
}
