using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnPlayerLoseEvent();
    public static event OnPlayerLoseEvent OnPlayerDeath;

    public static void Invoke_OnPlayerLose()
    {
        OnPlayerDeath?.Invoke();
    }

    public delegate void OnPlayerWinEvent();
    public static event OnPlayerWinEvent OnPlayerWin;

    public static void Invoke_OnPlayerWin()
    {
        OnPlayerWin?.Invoke();
    }

    public delegate void CollisionWithFloor();
    public static event CollisionWithFloor OnFloorCollision;

    public static void Invoke_OnFloorCollision()
    {
        OnFloorCollision?.Invoke();
    }

}
