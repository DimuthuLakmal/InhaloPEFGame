using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemainingTimeCalculator : MonoBehaviour {

    public Text remainingTimeText;
    float timePausedRemaining;
    public Canvas pausedCanvas;
    private int remainingPef;

    // Use this for initialization
    void Start()
    {
        timePausedRemaining = 5f;
        remainingPef = PlayerPrefs.GetInt("remaining_pef");
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingPef > 0)
        {
            timePausedRemaining -= Time.deltaTime;
            if (timePausedRemaining > 0)
            {
                remainingTimeText.text = "Wait " + Mathf.Floor(timePausedRemaining % 60).ToString() + " Seconds For the Next Round";
            }
            else
            {
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in objects)
                {
                    go.SendMessage("StopPauseGame", SendMessageOptions.DontRequireReceiver);
                }
                Destroy(pausedCanvas);
            }
        }
        else
        {
            remainingTimeText.text = "You completed 3 rounds for today";
        }

    }
}
