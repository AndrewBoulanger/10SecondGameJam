using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : GameHUDWidget
{
    [SerializeField] Button selectedButton;

    private void OnEnable()
    {
        GetComponentInChildren<Button>().Select();
    }
      

    public void setSelected()
    {
        selectedButton.Select();
    }

    public void OnRestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
