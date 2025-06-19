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
            TMP_Text text = row.transform.Find("CoinText").GetComponent<TMP_Text>();
            text.text = $"{coin.Name}: ${coin.currentValue:F2}";

            //Buy buttons
            Button BuyBtn = row.transform.Find("BuyButton").GetComponent<Button>();
            BuyBtn.onClick.AddListener(() => OnBuyCoin(coin));
            //Sell button
            Button sellBtn = row.transform.Find("SellButton").GetComponent<Button>();
            sellBtn.onClick.AddListener(() => OnSellCoin(coin));

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

    private void OnBuyCoin(CryptoCurrency coin)
    {
        Debug.Log($"BUY {coin.Name} at ${coin.currentValue:F2}");
        //implement buy logic here
    }
    private void OnSellCoin(CryptoCurrency coin)
    {
        Debug.Log($"SELL {coin.Name} at ${coin.currentValue:F2}");
        //implement sell logic here
    }
}
