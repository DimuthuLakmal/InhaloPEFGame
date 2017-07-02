﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    //movement variables
    public float maxSpeed;

    //jumping Variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D playerRB;
    Animator playerAnim;
    bool facingRight;

    //touch Detection
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;

    public Text messageText;

    bool isActed = false;
    double maxBreathTime = 0;
    int timerMessage = 0;
    float startInterval;
    bool inhaleNowShown = false;
    double forceApplyTime;

    //public Text loudText;

    private string _device;
    private double micAmplitude = 0.0f;
    private double maxAmplitude = 0f;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        isActed = false;

        inhaleNowShown = false;
        messageText.text = "";

        startInterval = 5;
        maxBreathTime = 5;
        forceApplyTime = 1;
    }
	
	// Update is called once per frame
	void Update () {
       
        if (grounded && Input.GetKey(KeyCode.RightArrow))
        {
            playerRB.AddForce(new Vector2(maxSpeed, 0));
            playerAnim.SetBool("force", true);
        } else
        {
            playerAnim.SetBool("force", false);
        }


        startInterval -= Time.deltaTime;

        //When Starting show the count
        if (Mathf.Floor(startInterval) > 0)
        {
            float seconds = Mathf.Floor(startInterval % 60);
            messageText.text = "Start Inhale after " + seconds.ToString() + " secs"+micAmplitude.ToString();
        }
        else if (startInterval < 1 && !inhaleNowShown)
        {
            messageText.text = "Inhale Now!!!";
        }

        if(Mathf.Floor(startInterval) <= 0)
        {
            if(maxBreathTime < 4)
            {
                messageText.text = "";
            }

            maxBreathTime -= Time.deltaTime;
            if (maxAmplitude < micAmplitude && maxBreathTime > 0)
            {
                maxAmplitude = micAmplitude;
            }
        }
        
        if(maxBreathTime < 0 && !isActed)
        {
            forceApplyTime -= Time.deltaTime;
            if(forceApplyTime < 0)
            {
                isActed = true;
            }
            if(maxAmplitude > 20000)
            {
                playerRB.AddForce(new Vector2((float)(maxAmplitude / 780), 0));
            } else if (maxAmplitude > 15000 && maxAmplitude < 20000)
            {
                playerRB.AddForce(new Vector2((float)(maxAmplitude / 750), 0));
            } else if (maxAmplitude > 13000 && maxAmplitude < 15000)
            {
                playerRB.AddForce(new Vector2((float)(maxAmplitude / 700), 0));
            } else if (maxAmplitude > 10000 && maxAmplitude < 13000)
            {
                playerRB.AddForce(new Vector2((float)(maxAmplitude / 650), 0));
            }
            playerAnim.SetBool("force", true);
        }

        if(isActed)
        {
            messageText.text = maxAmplitude.ToString();
        }

    }

    void FixedUpdate()
    {
        //check is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    //This method will be call in android plugin
    public void setAmplitude(string dataReceived)
    {
        micAmplitude = double.Parse(dataReceived);
        messageText.text = micAmplitude.ToString();
    }

}
