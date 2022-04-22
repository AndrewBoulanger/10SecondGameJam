using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnPlayerDeathEvent();
    public static event OnPlayerDeathEvent OnPlayerDeath;

    public static void Invoke_OnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public delegate void OnPlayerWinEvent();
    public static event OnPlayerWinEvent OnPlayerWin;

    public static void Invoke_OnPlayerWin()
    {
        OnPlayerWin?.Invoke();
    }

}
