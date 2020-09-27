using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microwave : MonoBehaviour
{
    [SerializeField]
    private Text microwaveTimerText;

    private Player player;
    private string objectName;
    private List<char> charDigitsList = new List<char>();
    private GameObject selectedGameObject;
    private string strDigits;
    private int currentTime;
    private float delayTime = 1.0f;
    private MicrowaveStartButton microwaveStart;
    private bool canStart;
    private int layerNumber;

    private void Start()
    {
        microwaveTimerText.text = "EMPTY";
        player = FindObjectOfType<Player>();
        objectName = "";
        selectedGameObject = null;
        strDigits = "";
        microwaveStart = FindObjectOfType<MicrowaveStartButton>();
        canStart = false;
        layerNumber = 0;
    }

    private void Update()
    {
        selectedGameObject = player.GetSelectingGameObject();
        objectName = player.GetSelectingObject();
        canStart = microwaveStart.GetCorrectTime();

        if (selectedGameObject != null)
        {
            layerNumber = selectedGameObject.layer;
        }

        if (layerNumber == 11)
        {
            if (Input.GetMouseButtonDown(0) && charDigitsList.Count < 4)
            {
                charDigitsList.Add(objectName[objectName.Length - 1]);
                strDigits = new string(charDigitsList.ToArray());
                currentTime = int.Parse(strDigits);
                microwaveTimerText.text = currentTime.ToString();
            }
        }

        if (canStart)
        {
            CountdownTimer();
        }
    }

    private void CountdownTimer()
    {
        if (strDigits.Equals("60"))
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0.0f)
            {
                microwaveTimerText.text = currentTime.ToString();
                if (currentTime > 0)
                {
                    currentTime--;
                }
                delayTime = 1.0f;
            }
        }
    }

    public string GetStrDigits()
    {
        return strDigits;
    }

    public int GetCurrentTime()
    {
        return currentTime;
    }
}
