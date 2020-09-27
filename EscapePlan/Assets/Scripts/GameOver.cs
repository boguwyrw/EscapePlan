using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text congratulationText;
    [SerializeField]
    private Button quitButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            congratulationText.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
