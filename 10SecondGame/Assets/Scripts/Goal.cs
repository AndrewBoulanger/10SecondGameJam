using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] 
    float stayInTime = 3;
    float timer;

    

    private void OnTriggerStay(Collider other)
    {
        timer+= Time.deltaTime;
        if(timer >= stayInTime)
        { 
            PlayerEvents.Invoke_OnPlayerWin();
            this.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0;
    }
}
