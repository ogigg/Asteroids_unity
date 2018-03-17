using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : MonoBehaviour {
    public GameObject asteroid_big;
    public GameObject asteroid_small;
    public GameObject Bullet;
    public Rigidbody2D rb;
    
    void Generate_Small_Asteroid(float posx, float posy)
    {
        System.Random rnd = new System.Random();
        asteroid_small = Instantiate(asteroid_small, asteroid_big.transform.position + transform.TransformVector(posx, posy, 0), asteroid_big.transform.rotation) as GameObject;
        Rigidbody2D Temporary_RigidBody;
        Temporary_RigidBody = asteroid_small.GetComponent<Rigidbody2D>();
        Vector2 v2v = new Vector2((rnd.Next(-10, 10) / 10), (rnd.Next(-10, 10) / 10));
        Temporary_RigidBody.velocity =rb.velocity + v2v;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
        

            Generate_Small_Asteroid(-0.2f,-0.2f);
            Generate_Small_Asteroid(0.2f, -0.2f);
            Generate_Small_Asteroid(-0.2f, 0.2f);
            Generate_Small_Asteroid(0.2f, 0.2f);
            Destroy(asteroid_big);
        }
    }
    // Use this for initialization
    void Start () {
        System.Random rnd = new System.Random();
        rb = asteroid_big.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rnd.Next(-3, 3), rnd.Next(-3, 3));
    }
	
	// Update is called once per frame
	void Update () {
        if(asteroid_big.transform.position.y > 5.0f )
        {
            rb.MovePosition(transform.TransformVector(asteroid_big.transform.position.x, -4.90f, 0));
        }
        if (asteroid_big.transform.position.y < -5.0f)
        {
            rb.MovePosition(transform.TransformVector(asteroid_big.transform.position.x, 4.9f, 0));
        }
        if (asteroid_big.transform.position.x > 11.5f)
        {
            rb.MovePosition(transform.TransformVector(-11.2f,asteroid_big.transform.position.y, 0));
        }
        if (asteroid_big.transform.position.x < -11.5f)
        {
            rb.MovePosition(transform.TransformVector(11.2f, asteroid_big.transform.position.y, 0));
        }
    }
}
