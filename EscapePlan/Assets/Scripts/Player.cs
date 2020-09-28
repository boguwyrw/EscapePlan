using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float playerNormalSpeed;
    private float playerCrouchSpeed;
    private float playerSpeed;
    private Camera playerCamera;
    private string selectingObject;
    private GameObject selectingGameObject;
    private float distanceToObject;
    private CapsuleCollider playerCapsuleCollider;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerNormalSpeed = 4.0f;
        playerCrouchSpeed = 2.0f;
        playerSpeed = playerNormalSpeed;
        playerCamera = GetComponentInChildren<Camera>();
        selectingObject = "";
        selectingGameObject = null;
        distanceToObject = 0.0f;
        playerCapsuleCollider = GetComponent<CapsuleCollider>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float movementVertical = Input.GetAxis("Vertical");
        movementVertical *= Time.deltaTime;
        transform.Translate(Vector3.forward * movementVertical * playerSpeed);
        
        float movementHorizontal = Input.GetAxis("Horizontal");
        movementHorizontal *= Time.deltaTime;
        transform.Translate(new Vector3(movementHorizontal * playerSpeed, 0.0f, 0.0f));
        
        // Raycast
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selectingObject = hit.collider.gameObject.name.ToString();
            selectingGameObject = hit.collider.gameObject;
            distanceToObject = hit.distance;
        }

        PlayerCrouch();

    }

    private void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            playerCapsuleCollider.height = 1.0f;
            playerSpeed = playerCrouchSpeed;
        }
        else
        {
            playerCapsuleCollider.height = 2.0f;
            playerSpeed = playerNormalSpeed;
        }
    }

    public string GetSelectingObject()
    {
        return selectingObject;
    }

    public GameObject GetSelectingGameObject()
    {
        return selectingGameObject;
    }

    public float GetDistanceToObject()
    {
        return distanceToObject;
    }

}
