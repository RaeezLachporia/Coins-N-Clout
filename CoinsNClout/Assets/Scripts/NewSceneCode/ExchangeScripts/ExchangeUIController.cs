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

    private List<CoinItemUI> spawnedItems = new List<CoinItemUI>();

    private void Start()
    {
        UpdateWalletUI(); // no PopulateExchange here
    }

    private void Update()
    {
        if (spawnedItems.Count > 0)
            UpdatePrices();
    }

    public void PopulateExchange()
    {
        // Clear previous items
        foreach (var item in spawnedItems)
            Destroy(item.gameObject);
        spawnedItems.Clear();

        // Spawn a coin for each crypto
        foreach (var crypto in marketManager.cryptoList)
        {
            GameObject newItemGO = Instantiate(coinItemPrefab, coinListContainer);
            CoinItemUI itemUI = newItemGO.GetComponent<CoinItemUI>();
            itemUI.Setup(crypto, playerWallet);
            spawnedItems.Add(itemUI);
        }

        // Force layout rebuild
        LayoutRebuilder.ForceRebuildLayoutImmediate(coinListContainer.GetComponent<RectTransform>());
    }

    void UpdatePrices()
    {
        foreach (var item in spawnedItems)
        {
            item.Refresh(); // safe now because spawnedItems is CoinItemUI
        }
    }

    void UpdateWalletUI()
    {
        cashText.text = "Cash: $" + playerWallet.cashBalance.ToString("F2");

        string holdingInfo = "Holdings:\n";
        foreach (var h in playerWallet.holdings)
        {
            holdingInfo += $"{h.crypto.Symbol}: {h.amount:F2}\n";
        }
        holdingsText.text = holdingInfo;
    }
}
