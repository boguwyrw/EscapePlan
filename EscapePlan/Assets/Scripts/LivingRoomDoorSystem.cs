using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingRoomDoorSystem : MonoBehaviour
{
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject collectedItems;

    private DoorsSystem doorsSystem;
    private bool canOpen;

    private void Start()
    {
        doorsSystem = FindObjectOfType<DoorsSystem>();
        canOpen = false;
    }

    private void Update()
    {
        if (canOpen)
        {
            doorsSystem.OpenCloseDoorSystem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 10) && collectedItems.transform.Find("LivingRoomKey"))
        {
            informationText.text = "Use Living Room Key to open door";
            canOpen = true;
        }
        else
        {
            informationText.text = "You don't have the key";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            informationText.text = "";
        }
    }
}
