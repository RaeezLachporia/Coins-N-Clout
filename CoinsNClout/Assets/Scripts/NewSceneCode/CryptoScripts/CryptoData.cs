using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crypto", menuName = "Crypto/Create New Crypto")]
public class CryptoData : ScriptableObject
{
    public string cryptoName;
    public string Symbol;
    public float basePrice = 100f;
    public float Volatility = 0.05f;//fluctuation update value;
    [HideInInspector] public float currentPrice;

    public void InitializePrice()
    {
        currentPrice = basePrice;
    }

    public void UpdatePrices()
    {
        //fluctuates in the volatility range
        float changePercent = Random.Range(-Volatility, Volatility);
        currentPrice += currentPrice * changePercent;

        //wont let price drop below 0 for now
        currentPrice = Mathf.Max(0.01f, currentPrice);
    }
    


}
