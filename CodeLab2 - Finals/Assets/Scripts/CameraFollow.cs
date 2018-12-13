using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform targetObject;
    public float followSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (targetObject == null)
        {
            targetObject = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = Vector3.Lerp(transform.position, targetObject.position, Time.fixedDeltaTime * followSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

    }
}

