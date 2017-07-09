using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject scoreTextObject = GameObject.FindGameObjectsWithTag("scoreText")[0];
        Text t = scoreTextObject.GetComponent<Text>();
        
        string url = "http://ec2-13-126-1-95.ap-south-1.compute.amazonaws.com:3000/userscore/add";

        WWWForm form = new WWWForm();
        form.AddField("score", t.text);
        form.AddField("game", "pefgame1");
        form.AddField("userId", PlayerPrefs.GetString("userId"));
        form.AddField("date", System.DateTime.Now.ToString("yyyy-MM-dd"));
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
            Application.LoadLevel("Menu");
        }
        else {
            Debug.Log("WWW Error: " + www.error);
            Application.LoadLevel("Menu");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
