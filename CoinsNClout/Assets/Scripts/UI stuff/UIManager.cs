using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject computerScreenPanel;
    public GameObject coinRowPrefab;
    public Transform contentParent; //scrollView Object

    private MarketManager market;
    private List<GameObject> currentRows = new List<GameObject>();

    private void Start()
    {
        market = FindObjectOfType<MarketManager>();
        computerScreenPanel.SetActive(false);
        
    }
    public void toggleCompScreen()
    {
        bool isActive = !computerScreenPanel.activeSelf;
        computerScreenPanel.SetActive(isActive);

        if (isActive)
        {
            RefreshDisplay();
        }
    }

    public void RefreshDisplay()
    {
        //clear old rows
        foreach(var row in currentRows)
        {
            Destroy(row);
        }
        currentRows.Clear();

        //Add new rows
        foreach(var coin in market.coins)
        {
            GameObject row = Instantiate(coinRowPrefab, contentParent);
            row.GetComponentInChildren<TMP_Text>().text = $"{coin.Name}:${coin.currentValue:F2}";
            currentRows.Add(row);
        }
    }
    private void Update()
    {
        if (computerScreenPanel.activeSelf)
        {
            RefreshDisplay();
        }
    }
}
