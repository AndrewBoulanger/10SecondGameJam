using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float timeTilRotate = 10;
    public float rotationSpeed = 5;
    float timer, rotSOfar ;

    Vector3 rotationDir = Vector3.back;

    bool isRotating = false;

    List<Vector3> dirs = new List<Vector3> {Vector3.back };


    // Start is called before the first frame update
    void Start()
    {
        timer = timeTilRotate;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotating)
        {
            float rotAmount = Time.deltaTime * rotationSpeed;
            rotSOfar += rotAmount;

            if(rotSOfar < 90)
                transform.Rotate(rotationDir * rotAmount);
            else
            StopRotating();

        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                StartRotating();
        }

    }
    public string getRotatingText()
    {
        if(isRotating)
            return "Rotating...";
        else
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(timer);
            return time.ToString("ss\\.ff");
        }
    }

    void StartRotating()
    {
       // int random = Random.Range(0, dirs.Count);
       // rotationDir = dirs[random];

        isRotating = true;
    }

    void StopRotating()
    {
        rotSOfar = 0;
        isRotating = false;
        timer = timeTilRotate;
    }

    void resetRotation()
    {
        StopRotating();
        transform.rotation = Quaternion.identity;
    }

    private void OnEnable()
    {
        PlayerEvents.OnFloorCollision += resetRotation;
    }
    private void OnDisable()
    {
        PlayerEvents.OnFloorCollision -= resetRotation;
    }
}
