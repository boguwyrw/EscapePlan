using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoorsSystem : MonoBehaviour
{

    private Player player;
    private string objectName;
    private float distanceFromPlayer;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        objectName = "";
        distanceFromPlayer = 0.0f;
    }

    private void Update()
    {
        string childName = gameObject.transform.GetChild(0).name;
        objectName = player.GetSelectingObject();
        distanceFromPlayer = player.GetDistanceToObject();

        if (Input.GetKey(KeyCode.F) && objectName.Equals(childName) && (distanceFromPlayer < 2.2f))
        {
            Quaternion openDoor = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, openDoor, 2 * Time.deltaTime);
        }
    }
}
