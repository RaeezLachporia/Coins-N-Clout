using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CryptoCurrency : MonoBehaviour
{
    public string Name;
    public float currentValue;
    public float Volatility;

    public CryptoCurrency(string name, float startValue, float volatility)
    {
        Name = name;
        currentValue = startValue;
        Volatility = volatility;
    }

    public void UpdateValue()
    {
        float fluctuation = Random.Range(-Volatility, Volatility);
        currentValue += currentValue * fluctuation;
        currentValue = Mathf.Max(0.01f, currentValue); // prevents value from going 0 or negative
    }
}
