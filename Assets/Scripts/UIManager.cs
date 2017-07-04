using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    private string logged_user_id;

    public GameObject scoreUpdater;

    // Use this for initialization
    void Start()
    {
        logged_user_id = PlayerPrefs.GetString("userId");
    }

    public void Play()
    {
        if(PlayerPrefs.GetString("date") != "")
        {
            if(PlayerPrefs.GetString("date") != System.DateTime.Now.ToString("yyyy-MM-dd"))
            {
                PlayerPrefs.SetString("date", System.DateTime.Now.ToString("yyyy-MM-dd"));
                PlayerPrefs.SetInt("remaining_pef", 3);
                Application.LoadLevel("level1");
            } else
            {
                Application.LoadLevel("level1");
            }
        } else
        {
            PlayerPrefs.SetString("date", System.DateTime.Now.ToString("yyyy-MM-dd"));
            PlayerPrefs.SetInt("remaining_pef", 3);
            Application.LoadLevel("level1");
        }
        
    }

    public void HighScores()
    {
        Application.LoadLevel("HighScores");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void HighScoresBackButton()
    {
        Application.LoadLevel("Menu");
    }

    public void LevelBackButton()
    {
        Instantiate(scoreUpdater, transform.position, transform.rotation);
        Application.LoadLevel("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
