using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveStartButton : MonoBehaviour
{
    private Microwave microwave;
    private string strTime;
    private bool correctTime;
    private MicrowaveDoorHinge microwaveDoor;
    private bool doorClosed;

    void Start()
    {
        microwave = FindObjectOfType<Microwave>();
        strTime = "";
        correctTime = false;
        microwaveDoor = FindObjectOfType<MicrowaveDoorHinge>();
        doorClosed = false;
    }

    void Update()
    {
        strTime = microwave.GetStrDigits();
        doorClosed = microwaveDoor.GetDoorAreClose();

        if (doorClosed)
        {
            if (strTime.Equals("60") && Input.GetMouseButtonDown(0))
            {
                correctTime = true;
            }
        }
        
    }

    public bool GetCorrectTime()
    {
        return correctTime;
    }
}
