using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuUiController : MonoBehaviour
{
    [SerializeField] private GameHUDWidget MenuCanvas;
    [SerializeField] private GameHUDWidget InstructionsCanvas;
    [SerializeField] private GameHUDWidget CreditsCanvas;

    private GameHUDWidget ActiveWidget;

    [SerializeField]
    AudioClip click;

    private void Start()
    {
        DisableAllMenus();
        EnableMainMenu();
       
    }


    public void EnableInstructions()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();
       
        ActiveWidget = InstructionsCanvas;
        ActiveWidget.EnableWidget();
        PersistantBGMPlayer.PlaySFX(click);
    }

    public void EnableMainMenu()
    {
        if (ActiveWidget)
        { 
            PersistantBGMPlayer.PlaySFX(click);
            ActiveWidget.DisableWidget();
        }

        ActiveWidget = MenuCanvas;
        ActiveWidget.EnableWidget();
    }

    public void EnableCreditsScreen()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();

        ActiveWidget = CreditsCanvas;
        ActiveWidget.EnableWidget();
        PersistantBGMPlayer.PlaySFX(click);
    }

    public void DisableAllMenus()
    {
        MenuCanvas.DisableWidget();
        InstructionsCanvas.DisableWidget();
        CreditsCanvas.DisableWidget();
    }
}
