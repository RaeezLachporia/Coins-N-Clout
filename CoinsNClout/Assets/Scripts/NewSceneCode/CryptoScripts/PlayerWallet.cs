using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CryptoHolding
{
    public CryptoData crypto;
    public float amount;
}
public class PlayerWallet : MonoBehaviour
{
    public float cashBalance = 1000f;
    public List<CryptoHolding> holdings = new List<CryptoHolding>();
    public bool BuyCrypto(CryptoData crypto, float amount)
    {
        float cost = crypto.currentPrice * amount;
        if (cashBalance>=cost)
        {
            cashBalance -= cost;
            AddToHoldings(crypto, amount);
            return true;
        }
        return false;
    }

    public bool SellCrypto(CryptoData crypto, float amount)
    {
        var holding = holdings.Find(h => h.crypto == crypto);
        if (holding != null && holding.amount>=amount)
        {
            holding.amount -= amount;
            cashBalance += crypto.currentPrice * amount;
            return true;
        }
        return false;
    }
    private void AddToHoldings(CryptoData crypto, float amount)
    {
        var holding = holdings.Find(h => h.crypto == crypto);
        if (holding == null)
        {
            holdings.Add(new CryptoHolding { crypto = crypto, amount = amount });
        }
        else
        {
            holding.amount += amount;
        }
    }
}
