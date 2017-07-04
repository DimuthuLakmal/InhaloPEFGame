using UnityEngine;
using System.Collections;

public class LoginEvent : MonoBehaviour
{

    public GameObject loginCheckerOb;
    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.GetString("userId") != "")
        {
            Application.LoadLevel("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loginChecker()
    {
        Instantiate(loginCheckerOb, transform.position, transform.rotation);
    }
}
