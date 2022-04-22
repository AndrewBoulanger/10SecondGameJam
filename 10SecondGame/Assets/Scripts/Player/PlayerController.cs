using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isMoving, isJumping, isPaused;


    public GameUIController uIController;

    public void Awake()
    {
        if (uIController == null)
            uIController = FindObjectOfType<GameUIController>();
    }

    public void OnPause(InputValue input)
    {
        uIController.TogglePauseMenu();
        PauseGameCheck();
    }

    private void PauseGameCheck()
    {
        isPaused = uIController.IsGamePaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    //collision w floor - leads to death
    private void OnLose()
    {
        uIController.EnableLoseScreen();
        PauseGameCheck();
    }

    //trigger overlap with goal for 3 seconds - win
    private void OnWin()
    {
        uIController.EnableWinScreen();
        PauseGameCheck();
    }
}
