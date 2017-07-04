using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginChecker : MonoBehaviour {

    void Start()
    {
        GameObject userNameTextObject = GameObject.FindGameObjectsWithTag("UsernameText")[0];
        Text userNameText = userNameTextObject.GetComponent<Text>();

        string passwordText = GameObject.Find("passwordText").GetComponent<InputField>().text;

        string url = "http://ec2-13-126-1-95.ap-south-1.compute.amazonaws.com:3000/users/gamepef/login";

        Debug.Log(passwordText);

        WWWForm form = new WWWForm();
        form.AddField("username", GameObject.Find("UsernameText").GetComponent<Text>().text);
        form.AddField("password", passwordText);
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
            Processjson(www.data);
        }
        else {
            Debug.Log("WWW Error: " + www.error);
            Processjson(www.error);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Processjson(string jsonString)
    {
        User loggedUser = JsonUtility.FromJson<User>(jsonString);
        if (loggedUser.userId != null)
        {
            PlayerPrefs.SetString("userId", loggedUser.userId);
            PlayerPrefs.SetString("best_pef", loggedUser.best_pef);
            Application.LoadLevel("Menu");
        }
    }
}

[System.Serializable]
public class User
{
    public string userId;
    public string best_pef;
}

