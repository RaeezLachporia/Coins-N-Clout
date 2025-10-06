using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExchangeUIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject BrowserPanel;
    public GameObject ByteExchangePanel;
    public GameObject MoonTradeExchangePanel;
    public GameObject DogLiraExchangePanel;
    public GameObject PcPanel;

    public void OpenByteExchange()
    {
        Debug.Log("Opening byte exchange panel");
        PcPanel.SetActive(false);
        BrowserPanel.SetActive(false);
        ByteExchangePanel.SetActive(true);
    }
    public void OpenMoonTradeExchange()
    {
        Debug.Log("Opening Moon Trade exchange");
        PcPanel.SetActive(false);
        BrowserPanel.SetActive(false);
        MoonTradeExchangePanel.SetActive(true);
    }
    public void OpenDogLiraExchange()
    {
        Debug.Log("Opening DogLira Exchange");
        PcPanel.SetActive(false);
        BrowserPanel.SetActive(false);
        DogLiraExchangePanel.SetActive(true);
    }
    public void BackToBrowserByteExchange()
    {
        ByteExchangePanel.SetActive(false);
        BrowserPanel.SetActive(true);
    }
    public void BactoBrowserMoonTrade()
    {
        MoonTradeExchangePanel.SetActive(false);
        BrowserPanel.SetActive(true);
    }
    public void BackToBrowserDogLira()
    {
        DogLiraExchangePanel.SetActive(false);
        BrowserPanel.SetActive(true);

    }
}
