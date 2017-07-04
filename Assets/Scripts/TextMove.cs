using UnityEngine;
using System.Collections;

public class TextMove : MonoBehaviour
{

    public float maxSpeed;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, maxSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
