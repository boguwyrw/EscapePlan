using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDoorSystem : MonoBehaviour
{
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject collectedItems;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 10) && collectedItems.transform.Find("RoomKey"))
        {
            informationText.text = "Use Room Key to open door";
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
