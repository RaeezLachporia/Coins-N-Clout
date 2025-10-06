using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExchangeUIController : MonoBehaviour
{
    [Header("References")]
    public CryptoMarketManager marketManager;
    public PlayerWallet playerWallet;

    [Header("UI Elements")]
    public Transform coinListContainer;
    public GameObject coinItemPrefab;

    [Header("Wallet UI")]
    public TMP_Text cashText;
    public TMP_Text holdingsText;

    private List<GameObject> spawnedItems = new List<GameObject>();

    private void Start()
    {
        PopulateExchange();
        UpdateWalletUI();
    }
    private void Update()
    {
        UpdatePrices();
    }

    void PopulateExchange()
    {
        //clear previous items if any
        foreach (var item in spawnedItems)
            Destroy(item);
        spawnedItems.Clear();

        //spawn a coin for each crypto
        foreach (var crypto in marketManager.cryptoList)
        {
            GameObject newitem = Instantiate(coinItemPrefab, coinListContainer);
            spawnedItems.Add(newitem);

            //Grabs all tmpro texts from the prefab
            TMP_Text[] texts = newitem.GetComponentsInChildren<TMP_Text>();
            TMP_Text nameText = texts[0];
            TMP_Text priceText = texts[1];

            //sets basic info
            nameText.text = crypto.cryptoName;
            priceText.text = "$" + crypto.currentPrice.ToString("F2");
            //Get buy/sell buttons from prefab
            Button[] buttons = newitem.GetComponentsInChildren<Button>();
            Button buyButton = buttons[0];
            Button sellButton = buttons[1];

            //funtionality for button
            buyButton.onClick.AddListener(() => BuyCrypto(crypto));
            sellButton.onClick.AddListener(() => SellCrypto(crypto));
        }

        
    }
    void UpdatePrices()
    {
        //loop through everycoin in the exchange and refresh price
        for (int i = 0; i < marketManager.cryptoList.Count; i++)
        {
            CryptoData crypto = marketManager.cryptoList[i];
            TMP_Text priceText = spawnedItems[i].GetComponentsInChildren<TMP_Text>()[1];
            priceText.text = "$" + crypto.currentPrice.ToString("F2");
        }
    }
    void BuyCrypto(CryptoData crypto)
    {
        bool success = playerWallet.BuyCrypto(crypto, 1);
        if (success)
        {
            Debug.Log("Bought 1" + crypto.cryptoName);
            UpdateWalletUI();
        }
        else
        {
            Debug.Log("Not enough funds");
        }
    }
    void SellCrypto(CryptoData crypto)
    {
        bool success = playerWallet.SellCrypto(crypto, 1);
        if (success)
        {
            Debug.Log("Sold 1" + crypto.cryptoName);
            UpdateWalletUI();
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    void UpdateWalletUI()
    {
        //Update cash balance
        cashText.text = "Cash: $" + playerWallet.cashBalance.ToString("F2");

        //update holdings
        string holdingInfo = "Holdings:\n";
        foreach (var h in playerWallet.holdings)
        {
            holdingInfo += $"{h.crypto.Symbol}: {h.amount:F2}\n";
        }
        holdingsText.text = holdingInfo;
    }
}
