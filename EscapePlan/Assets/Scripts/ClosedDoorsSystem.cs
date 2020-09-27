using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoorsSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject collectedItems;

    private Player player;
    private bool doorAction;
    private bool openning;
    private string objectName;
    private float distanceFromPlayer;
    private GameObject selectedGameObject;
    private Renderer doorRenderer;

    private PlayerCollectsItems playerCollects;
    private List<Renderer> renderersList = new List<Renderer>();

    private void Start()
    {
        doorAction = false;
        openning = false;
        player = FindObjectOfType<Player>();
        objectName = "";
        distanceFromPlayer = 0.0f;
        selectedGameObject = null;
        doorRenderer = gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();

        playerCollects = FindObjectOfType<PlayerCollectsItems>();
    }

    private void Update()
    {
        string childName = gameObject.transform.GetChild(0).name;
        objectName = player.GetSelectingObject();
        distanceFromPlayer = player.GetDistanceToObject();
        selectedGameObject = player.GetSelectingGameObject();

        renderersList = playerCollects.GetItemsRendererList();

        if (objectName.Equals(childName) && Input.GetKeyDown(KeyCode.F))
        {
            doorAction = true;
        }
        /*
        if (renderersList.Count > 0)
        {
            for (int i = 0; i < renderersList.Count; i++)
            {
                if (doorRenderer.material.color.Equals(renderersList[i].material.color) && (distanceFromPlayer < 2.2f))
                {
                    OpenCloseDoorSystem();
                }
            }
        }
        */
        for (int i = 0; i < renderersList.Count; i++)
        {
            if (doorRenderer.material.color.Equals(renderersList[i].material.color) && (distanceFromPlayer < 2.2f))
            {
                OpenCloseDoorSystem();
            }
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
