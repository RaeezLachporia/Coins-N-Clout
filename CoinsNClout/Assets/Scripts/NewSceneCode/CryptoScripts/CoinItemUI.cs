using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CoinItemUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Button buyButton;
    public Button sellButton;
    private CryptoData cryptoData;
    private PlayerWallet playerWallet;

    public void Setup(CryptoData data, PlayerWallet wallet)
    {
        cryptoData = data;
        playerWallet = wallet;
        nameText.text = data.cryptoName;
        priceText.text = "$" + data.currentPrice.ToString("F2");
        buyButton.onClick.AddListener(OnBuy);
        sellButton.onClick.AddListener(OnSell);
    }
    void OnBuy()
    {
        if (playerWallet.BuyCrypto(cryptoData,1))
        {
            Debug.Log($"Bought 1 {cryptoData.cryptoName}");
        }
        else
        {
            Debug.Log("Not enough funds");
        }
    }
    void OnSell()
    {
        if (playerWallet.SellCrypto(cryptoData,1))
        {
            Debug.Log($"Sold 1 {cryptoData.cryptoName}");
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}
