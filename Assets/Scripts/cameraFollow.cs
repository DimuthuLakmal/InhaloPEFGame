using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{

    public Transform target; //what camera is following

    Vector3 intialPosition;

    float lowY;

    // Use this for initialization
    void Start()
    {
        intialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + 5f, 0f, intialPosition.z);
        }

    }
}
