using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_small_collision : MonoBehaviour {
    public GameObject asteroid_small;
    public Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            Destroy(asteroid_small);
        }
    }
    // Use this for initialization
    void Start () {
        rb = asteroid_small.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
    
    }
}
