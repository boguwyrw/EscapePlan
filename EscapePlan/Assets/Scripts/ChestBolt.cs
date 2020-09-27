using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBolt : MonoBehaviour
{
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject collectedItems;

    private Player player;
    private string objectName;
    private float distanceFromPlayer;
    private bool openning;
    private bool canOpen;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        objectName = "";
        distanceFromPlayer = 0.0f;
        openning = false;
        canOpen = false;
    }

    private void Update()
    {
        string childName = gameObject.transform.GetChild(0).name;
        objectName = player.GetSelectingObject();
        distanceFromPlayer = player.GetDistanceToObject();

        if (Input.GetKeyDown(KeyCode.F) && objectName.Equals(childName) && (distanceFromPlayer < 2.2f))
        {
            openning = true;
        }

        OpenChestWing();
    }

    private void OpenChestWing()
    {
        if (canOpen && openning)
        {
            Quaternion openDoor = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, openDoor, 6 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 10) && collectedItems.transform.Find("WreckingBar"))
        {
            informationText.text = "Use Wrecking Bar to open door";
            canOpen = true;
        }
        else
        {
            informationText.text = "You don't have Wrecking Bar";
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
