using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUImanager : MonoBehaviour
{
    [Header("UI references")]
    public GameObject computerScrenPanel;
    public GameObject Browser;
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
    }

    public void OpenExchange(string exchangeName)
    {
        Debug.Log($"Opening {exchangeName} exchange...");
    }
}
