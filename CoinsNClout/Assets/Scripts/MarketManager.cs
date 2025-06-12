using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public List<CryptoCurrency> coins = new List<CryptoCurrency>();
    void Start()
    {
        coins.Add(new CryptoCurrency("ByteCoin", 1.0f, 0.05f));
        coins.Add(new CryptoCurrency("GhostToken", 0.5f, 0.1f));
        coins.Add(new CryptoCurrency("HustleCoin", 2.0f, 0.02f));

        //call update market every 5 seconds
        InvokeRepeating(nameof(UpdateMarket), 1f, 5f);
    }

    void UpdateMarket()
    {
        Debug.Log("--- MARKET UPDATE ---");
        foreach (var coin in coins)
        {
            coin.UpdateValue();
            Debug.Log($"{coin.name}: ${coin.currentValue:F2}");
        }
    }
}
