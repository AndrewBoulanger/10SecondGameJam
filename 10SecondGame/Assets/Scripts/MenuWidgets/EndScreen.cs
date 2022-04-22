using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : GameHUDWidget
{
    public Button focusedButton;
    public float fadeInSpeed;
    public CanvasGroup canvasGroup;

    private void OnEnable()
    {
      
        canvasGroup.alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(canvasGroup.alpha < 1)
            canvasGroup.alpha += Time.deltaTime * fadeInSpeed;
    }

    public void OnRestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
