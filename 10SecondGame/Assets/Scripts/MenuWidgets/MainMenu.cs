using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MainMenu : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnCreditsClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnInstructionsClicked()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
