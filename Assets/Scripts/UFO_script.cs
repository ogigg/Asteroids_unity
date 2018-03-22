using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UFO_script : MonoBehaviour {
    public GameObject ufo;
    public ShipMovement ShipMov;
    private Rigidbody2D rb;


    private void GenerateRandomForce()
    {
        System.Random rnd = new System.Random();
        //rb.AddForce(new Vector2(rnd.Next(-100,100), rnd.Next(-80, 80)));
        rb.velocity = new Vector2(rnd.Next(-3, 3), rnd.Next(-2, 2));
    }
    private void Recursion()
    {
        GenerateRandomForce();
        Invoke("Recursion", 1);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            Destroy(ufo);
        }
    }
    
    // Use this for initialization
    void Start () {
        rb = ufo.GetComponent<Rigidbody2D>();
        GenerateRandomForce();
        Recursion();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
