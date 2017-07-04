using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreRetriever : MonoBehaviour
{

    void Start()
    {
        string url = "http://ec2-13-126-1-95.ap-south-1.compute.amazonaws.com:3000/userscore/all";

        WWWForm form = new WWWForm();
        form.AddField("userId", PlayerPrefs.GetString("userId"));
        form.AddField("date", System.DateTime.Now.ToString("yyyy-MM-dd"));
        form.AddField("game", "pefgame1");
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
            processingJSon(www.data);
        }
        else {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    public void processingJSon(string jsonString)
    {
        string[] scores = JsonUtility.FromJson<Scores>(jsonString).scores;
        if (scores[0] != null)
        {
            GameObject.Find("HighestScore").GetComponent<Text>().text = scores[1];
            GameObject.Find("HighestScoreName").GetComponent<Text>().text = scores[0];
        }
        if (scores[2] != null)
        {
            GameObject.Find("PersonalHighestScore").GetComponent<Text>().text = scores[2];
        }
        if (scores[3] != null)
        {
            GameObject.Find("TodayPlayer1Name").GetComponent<Text>().text = scores[3];
            GameObject.Find("TodayPlayer1Score").GetComponent<Text>().text = scores[4];
        }
        if (scores[5] != null)
        {
            GameObject.Find("TodayPlayer2Name").GetComponent<Text>().text = scores[5];
            GameObject.Find("TodayPlayer2Score").GetComponent<Text>().text = scores[6];
        }
        if (scores[7] != null)
        {
            GameObject.Find("TodayPlayer3Name").GetComponent<Text>().text = scores[7];
            GameObject.Find("TodayPlayer3Score").GetComponent<Text>().text = scores[8];
        }
        if (scores[9] != null)
        {
            GameObject.Find("PersonalTodayHighScore").GetComponent<Text>().text = scores[9];
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class Scores
{
    public string[] scores;
}