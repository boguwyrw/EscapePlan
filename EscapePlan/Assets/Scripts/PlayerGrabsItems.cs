using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabsItems : MonoBehaviour
{
    [SerializeField]
    private GameObject grabPoint;

    private Player player;
    private GameObject indicatedObject;
    private bool objectGrabbed;

    private void Start()
    {
        player = GetComponent<Player>();
        indicatedObject = null;
        objectGrabbed = false;
    }

    private void Update()
    {
        indicatedObject = player.GetSelectingGameObject();

        GrabbingPuttingObject();
    }

    private void GrabbingPuttingObject()
    {
        if (Input.GetKeyDown(KeyCode.G) && indicatedObject.layer == 14)
        {
            if (!objectGrabbed)
            {
                indicatedObject.transform.parent = grabPoint.transform;
                indicatedObject.transform.position = grabPoint.transform.position;
                indicatedObject.GetComponent<Rigidbody>().useGravity = false;
                indicatedObject.GetComponent<Rigidbody>().isKinematic = true;
                objectGrabbed = true;
            }
            else if (objectGrabbed)
            {
                indicatedObject.transform.parent = null;
                indicatedObject.GetComponent<Rigidbody>().useGravity = true;
                indicatedObject.GetComponent<Rigidbody>().isKinematic = false;
                objectGrabbed = false;
            }
        }
    }
}
