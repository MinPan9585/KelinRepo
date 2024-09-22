using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    float timeLeft = 99.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        GetComponent<UnityEngine.UI.Text>().text = "Time: " + timeLeft.ToString("F2");
    }
}
