using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject collectedItems;

    private Animator iceCubeAnimation;
    private Microwave microwave;
    private int timeToDefrost;

    private void Start()
    {
        iceCubeAnimation = GetComponent<Animator>();
        iceCubeAnimation.enabled = false;
        microwave = FindObjectOfType<Microwave>();
        timeToDefrost = 0;
    }

    private void Update()
    {
        timeToDefrost = microwave.GetCurrentTime();

        if (timeToDefrost == 58 && timeToDefrost > 2)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).parent = null;
            }
            iceCubeAnimation.enabled = true;
            
        }

        if (transform.localScale.x < 0.021)
        {
            iceCubeAnimation.enabled = false;
        }
    }
}
