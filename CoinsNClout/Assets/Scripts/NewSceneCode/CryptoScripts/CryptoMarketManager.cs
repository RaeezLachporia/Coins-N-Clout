using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoMarketManager : MonoBehaviour
{
    public List<CryptoData> cryptoList;
    public float updateInterval = 5f; //time till markets update
    private float timer;

    private void Start()
    {
        foreach (var crypto in cryptoList)
        {
            crypto.InitializePrice();
        }
    }
    private void Update()
    {
        
    }
}
