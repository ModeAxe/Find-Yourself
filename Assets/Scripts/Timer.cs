using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] private TextMeshPro countdownText;

    private int seconds;
    private int minutes;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime += -1 * Time.deltaTime;
        minutes = (int) currentTime / 60;
        seconds = (int)currentTime % 60;
        countdownText.text = minutes.ToString("00") +":"+ seconds.ToString("00");

        if (currentTime <= startingTime/2)
        {
            //half time mark
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            //call function to end game or something
        }
    }
}

