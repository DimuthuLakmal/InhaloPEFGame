using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CoinPicker : MonoBehaviour {

    public Text coinScoreEffect;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered");

            GameObject[] objects = GameObject.FindGameObjectsWithTag("scoreText");

            foreach (GameObject scoreTextObject in objects)
            {
                Text scoreText = scoreTextObject.GetComponent<Text>();
                int currentScore = Int32.Parse(scoreText.text);
                currentScore += 5;
                scoreText.text = currentScore.ToString();
            }

            GameObject newCanvas = new GameObject("Canvas");
            Canvas c = newCanvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.ScreenSpaceOverlay;
            newCanvas.AddComponent<CanvasScaler>();
            newCanvas.AddComponent<GraphicRaycaster>();

            Text tempTextBox = Instantiate(coinScoreEffect, new Vector3(transform.position.x + 350f, transform.position.y + 200f, 0), transform.rotation) as Text;
            tempTextBox.transform.SetParent(newCanvas.transform, true);
            Destroy(gameObject);
        }
    }
}
