﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsSystem : MonoBehaviour
{
    private Player player;
    private bool doorAction;
    private bool openning;
    private string objectName;
    private float distanceFromPlayer;
    private GameObject selectedGameObject;
    private int layerNumber;

    private void Start()
    {
        doorAction = false;
        openning = false;
        player = FindObjectOfType<Player>();
        objectName = "";
        distanceFromPlayer = 0.0f;
        selectedGameObject = null;
        layerNumber = 0;
    }

    private void Update()
    {
        string childName = gameObject.transform.GetChild(0).name;
        objectName = player.GetSelectingObject();
        distanceFromPlayer = player.GetDistanceToObject();
        selectedGameObject = player.GetSelectingGameObject();

        if (selectedGameObject != null)
        {
            layerNumber = selectedGameObject.layer;
        }

        if (Input.GetKeyDown(KeyCode.F) && objectName.Equals(childName) && (distanceFromPlayer < 2.2f))
        {
            doorAction = true;
        }

        if (layerNumber != 13)
        {
            OpenCloseDoorSystem();
        }
    }

    public void OpenCloseDoorSystem()
    {
        if (doorAction)
        {
            if (transform.localEulerAngles.y < 0.25f)
            {
                openning = true;
            }

            if (openning)
            {
                Quaternion openDoor = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, openDoor, 2 * Time.deltaTime);
                if (transform.localEulerAngles.y > 89.75f)
                {
                    doorAction = false;
                    openning = false;
                }
            }
            else
            {
                Quaternion closeDoor = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, closeDoor, 2 * Time.deltaTime);
                if (transform.localEulerAngles.y < 0.25f)
                {
                    doorAction = false;
                }
            }

        }
    }

}
