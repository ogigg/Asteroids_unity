using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : MonoBehaviour {
    public GameObject asteroid_big;
    public GameObject asteroid_small;
    public GameObject Bullet;
    public Rigidbody2D rb;
    
    void Generate_Small_Asteroid(float posx, float posy, float velx, float vely)
    {
        System.Random rnd = new System.Random(asteroid_big.GetInstanceID());
        asteroid_small = Instantiate(asteroid_small, asteroid_big.transform.position + transform.TransformVector(posx, posy, 0), asteroid_big.transform.rotation) as GameObject;
        Rigidbody2D Temporary_RigidBody;
        Temporary_RigidBody = asteroid_small.GetComponent<Rigidbody2D>();
        Vector2 v2v = new Vector2(velx, vely);
        Temporary_RigidBody.velocity =rb.velocity + v2v;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            Generate_Small_Asteroid(-0.2f, -0.2f,-1,1);
            Generate_Small_Asteroid(0.2f, -0.2f,1,-1);
            Generate_Small_Asteroid(-0.2f, 0.2f,-1,1);
            Generate_Small_Asteroid(0.2f, 0.2f,1,1);
            Destroy(asteroid_big);
        }
        else
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
    // Use this for initialization
    void Start () {
        System.Random rnd = new System.Random(asteroid_big.GetInstanceID());
        rb = asteroid_big.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rnd.Next(-3, 3), rnd.Next(-3, 3));
        Physics2D.IgnoreCollision(asteroid_big.GetComponent<Collider2D>(), asteroid_big.GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {

    }
}
