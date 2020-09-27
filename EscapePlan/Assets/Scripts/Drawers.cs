using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawers : MonoBehaviour
{

    private float drawerMovingLenght;
    private float drawerOpenningSpeed;
    private bool drawerIsClosed;

    private Player player;
    private string objectName;
    private float distanceFromPlayer;

    private void Start()
    {
        drawerMovingLenght = 1.3f;
        drawerOpenningSpeed = 0.25f;
        drawerIsClosed = true;

        player = FindObjectOfType<Player>();
        objectName = "";
        distanceFromPlayer = 0.0f;
    }

    private void Update()
    {
        objectName = player.GetSelectingObject();
        distanceFromPlayer = player.GetDistanceToObject();

        if (Input.GetKey(KeyCode.F) && objectName.Equals(gameObject.name) && (distanceFromPlayer < 2.2f))
        {
            if (drawerIsClosed)
            {
                transform.Translate(Vector3.forward * drawerOpenningSpeed * Time.deltaTime);
            }
            if (transform.localPosition.z >= drawerMovingLenght)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, drawerMovingLenght);
                drawerIsClosed = false;
            }

            if (!drawerIsClosed)
            {
                transform.Translate(Vector3.back * drawerOpenningSpeed * Time.deltaTime);
            }
            if (transform.localPosition.z <= 0.0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.0f);
                drawerIsClosed = true;
            }
        }
    }

}
