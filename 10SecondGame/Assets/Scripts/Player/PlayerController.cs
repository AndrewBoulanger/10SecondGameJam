using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isMoving, isJumping, isPaused;

    Vector3 startPos;
    Quaternion startQuat;

    public GameUIController uIController;

    public AudioClip hurt;
    public void Awake()
    {
        if (uIController == null)
            uIController = FindObjectOfType<GameUIController>();
        startPos = transform.position;
        startQuat = transform.rotation;
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

    private void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += OnLose;
        PlayerEvents.OnPlayerWin += OnWin;
    }
    private void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= OnLose;
        PlayerEvents.OnPlayerWin -= OnWin;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("KillFloor"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerEvents.Invoke_OnFloorCollision();
            transform.position = startPos;
            transform.rotation = startQuat;
            PersistantBGMPlayer.PlaySFX(hurt);
        }
    }
}
