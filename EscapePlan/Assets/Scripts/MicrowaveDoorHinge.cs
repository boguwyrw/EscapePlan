using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveDoorHinge : MonoBehaviour
{
    private bool doorAreClose;

    private void Start()
    {
        doorAreClose = true;
    }

    private void Update()
    {
        if (transform.rotation.y > 0.249f)
        {
            doorAreClose = false;
        }
        else
        {
            doorAreClose = true;
        }
    }

    public bool GetDoorAreClose()
    {
        return doorAreClose;
    }
}
