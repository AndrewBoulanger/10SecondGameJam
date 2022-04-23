using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericMenuWIdget : GameHUDWidget
{
    [SerializeField]
    AudioClip click;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        PersistantBGMPlayer.PlaySFX(click);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
