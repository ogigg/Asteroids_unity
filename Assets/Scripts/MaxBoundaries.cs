using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBoundaries : MonoBehaviour {
    public GameObject ObjectToSetBoundaries;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = ObjectToSetBoundaries.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (ObjectToSetBoundaries.transform.position.y > 5)
        {
            rb.MovePosition(transform.TransformVector(ObjectToSetBoundaries.transform.position.x, -5, 0));
        }
        if (ObjectToSetBoundaries.transform.position.y < -5)
        {
            rb.MovePosition(transform.TransformVector(ObjectToSetBoundaries.transform.position.x, 5, 0));
        }
        if (ObjectToSetBoundaries.transform.position.x > 11.5f)
        {
            rb.MovePosition(transform.TransformVector(-11, ObjectToSetBoundaries.transform.position.y, 0));
        }
        if (ObjectToSetBoundaries.transform.position.x < -11.5f)
        {
            rb.MovePosition(transform.TransformVector(11, ObjectToSetBoundaries.transform.position.y, 0));
        }
    }
}
