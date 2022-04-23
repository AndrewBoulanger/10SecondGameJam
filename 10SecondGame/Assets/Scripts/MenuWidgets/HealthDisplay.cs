using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int numLives = 3;

    List<Image> healthIcons;

    public Image healthIcon;

    private void Awake()
    {
        healthIcons = new List<Image>(numLives);
        for(int i = 0; i< numLives; i++)
        {
            healthIcons.Add(Instantiate(healthIcon, transform));
        }
    }

    void LoseLife()
    {
        numLives--;

        healthIcons[numLives].rectTransform.localScale = Vector3.zero;

        if(numLives <= 0)
            PlayerEvents.Invoke_OnPlayerLose();
    }

    private void OnEnable()
    {
        PlayerEvents.OnFloorCollision += LoseLife;
    }
    private void OnDisable()
    {
        PlayerEvents.OnFloorCollision -= LoseLife;
    }
}
