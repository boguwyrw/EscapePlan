﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenDoorSystem : MonoBehaviour
{
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject collectedItems;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 10) && collectedItems.transform.Find("KitchenKey"))
        {
            informationText.text = "Use Kitchen Key to open door";
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
