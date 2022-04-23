using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScreen : GameHUDWidget
{

    [SerializeField] Rotator rotator;
    [SerializeField] TMPro.TextMeshProUGUI timeText;
    [SerializeField] HealthDisplay health;

    private void Update()
    {
        timeText.text = rotator.getRotatingText();
    }
}
