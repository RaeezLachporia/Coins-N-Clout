using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ComputerUImanager : MonoBehaviour
{
    [Header("UI references")]
    public GameObject computerScrenPanel;
    public GameObject Browser;
    public GameObject UseComp;
    public TMP_Text exchangeNameText;
    private bool isBrowerOpen = false;
    private bool isComputerOpen = false;
    

    public void ToggleComputer()
    {
        isComputerOpen = !isComputerOpen;
        computerScrenPanel.SetActive(isComputerOpen);
    }
    public void CloseComputer()
    {
        isComputerOpen = false;
        computerScrenPanel.SetActive(false);
    }

    public void ToggleBrowser()
    {
        isBrowerOpen = !isBrowerOpen;
        computerScrenPanel.SetActive(false);
        Browser.SetActive(isBrowerOpen);
    }

    public void closeBrowser()
    {
        isBrowerOpen = false;
        computerScrenPanel.SetActive(true);
        Browser.SetActive(false);
        UseComp.SetActive(true);
    }

    public void OpenExchange(Button clickedButton)
    {
        TMP_Text exchangeText = clickedButton.GetComponentInChildren<TMP_Text>();
        if (exchangeText == null)
        {
            Debug.LogWarning("No tmp_text found on button");
            return;
        }
        string exchangeName = exchangeText.text;
        Debug.Log($"Opening {exchangeName} exchange...");
    }
}
