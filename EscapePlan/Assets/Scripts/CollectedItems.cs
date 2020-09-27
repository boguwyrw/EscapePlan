using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItems : MonoBehaviour
{
    private List<Renderer> itemsRendererList = new List<Renderer>();

    private void Start()
    {
        
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < itemsRendererList.Count; i++)
            {
                itemsRendererList.Add(transform.GetChild(i).gameObject.GetComponent<Renderer>());
            }
        }

        if(itemsRendererList.Count > 0)
            Debug.Log(itemsRendererList[0].material.color);
        */
    }
}
