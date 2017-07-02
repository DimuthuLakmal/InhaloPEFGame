using UnityEngine;
using System.Collections;

public class buttonClicks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Replay()
    {
        Application.LoadLevel("level1");
    }
}
