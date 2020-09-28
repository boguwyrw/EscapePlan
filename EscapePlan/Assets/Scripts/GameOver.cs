using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text congratulationText;
    [SerializeField]
    private Text quitInfoText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            congratulationText.gameObject.SetActive(true);
            quitInfoText.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
