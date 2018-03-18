using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBoundaries : MonoBehaviour {
    public GameObject ObjectToSetBoundaries;
    Rigidbody2D rb;
    private float minX, maxX, minY, maxY;
    // Use this for initialization
    void Start () {
        rb = ObjectToSetBoundaries.GetComponent<Rigidbody2D>();
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }
	
	// Update is called once per frame
	void Update () {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = maxX;
        if (pos.x > maxX) pos.x = minX;

        // vertical contraint
        if (pos.y < minY) pos.y = maxY;
        if (pos.y > maxY) pos.y = minY;

        // Update position
        transform.position = pos;
    }
}
