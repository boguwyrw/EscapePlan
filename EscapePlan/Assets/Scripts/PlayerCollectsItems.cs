using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectsItems : MonoBehaviour
{
    [SerializeField]
    private GameObject collectedItems;

    private Player player;
    private GameObject selectedGameObject;
    private string selectedObjectName;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        selectedGameObject = player.GetSelectingGameObject();
        selectedObjectName = player.GetSelectingObject();

        if (Input.GetKeyDown(KeyCode.E) && selectedGameObject.layer == 9)
        {
            selectedGameObject.SetActive(false);
            selectedGameObject.transform.parent = collectedItems.transform;
        }

        if (selectedObjectName.Equals("MicrowavePlate") && transform.childCount > 0)
        {
            
            for (int i = 0; i < collectedItems.transform.childCount; i++)
            {
                if (collectedItems.transform.GetChild(i).name.Equals("IceCube") && Input.GetKeyDown(KeyCode.E))
                {
                    collectedItems.transform.GetChild(i).gameObject.SetActive(true);
                    collectedItems.transform.GetChild(i).transform.position = selectedGameObject.transform.GetChild(0).transform.position;
                }
            }
            
        }
    }
}
