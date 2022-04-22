using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{

    [SerializeField] private GameHUDWidget GameCanvas;
    [SerializeField] private GameHUDWidget PauseCanvas;
    [SerializeField] private GameHUDWidget LoseScreen, WinScreen;

    private GameHUDWidget ActiveWidget;

    public bool IsGamePaused => ActiveWidget != GameCanvas; 

    private void Start()
    {
        DisableAllMenus();
        EnableGameMenu();
       
    }

    public void TogglePauseMenu()
    {
        if (ActiveWidget == PauseCanvas)
            EnableGameMenu();
        else
            EnablePauseMenu();
    }

    public void EnablePauseMenu()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();
       
        ActiveWidget = PauseCanvas;
        ActiveWidget.EnableWidget();
    }

    public void EnableGameMenu()
    {
        if (ActiveWidget) ActiveWidget.DisableWidget();

        ActiveWidget = GameCanvas;
        ActiveWidget.EnableWidget();
    }

    public void EnableLoseScreen()
    {
        //if (ActiveWidget) ActiveWidget.DisableWidget();

        ActiveWidget = LoseScreen;
        ActiveWidget.EnableWidget();
    }
    public void EnableWinScreen()
    {
       // if (ActiveWidget) ActiveWidget.DisableWidget();

        ActiveWidget = WinScreen;
        ActiveWidget.EnableWidget();
    }

    public void DisableAllMenus()
    {
        GameCanvas.DisableWidget();
        PauseCanvas.DisableWidget();
        WinScreen.DisableWidget();
        LoseScreen.DisableWidget();
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerWin += EnableWinScreen;
    }
    private void OnDisable()
    {
         PlayerEvents.OnPlayerWin -= EnableWinScreen;
    }
}

public abstract class GameHUDWidget : MonoBehaviour
{
    public virtual void EnableWidget() 
    {
        gameObject.SetActive(true);
        
    }
    public virtual void DisableWidget()
    {
        gameObject.SetActive(false);
    }

}