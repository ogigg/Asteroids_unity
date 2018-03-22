using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UFO_script : MonoBehaviour {
    public LoadLevel lvl;
    public GameObject ufo;
    public GameObject Bullet;
    public GameObject ship;
    private Rigidbody2D rb;
    private void UfoShoot()
    {
        System.Random rnd = new System.Random();
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, ufo.transform.position, ufo.transform.rotation) as GameObject;
        Rigidbody2D Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
        Vector3 randomv3 = new Vector3(rnd.Next(-200, 200) / 100, rnd.Next(-200, 200) / 100, 0);
        Temporary_RigidBody.velocity = (ship.transform.position - transform.position + randomv3).normalized * 6;

        Destroy(Temporary_Bullet_Handler, 7.0f);
        Invoke("UfoShoot", 1);
    }
    private void GenerateRandomForce()
    {
        System.Random rnd = new System.Random();
        rb.velocity = new Vector2(rnd.Next(-3, 3), rnd.Next(-2, 2));
        Invoke("GenerateRandomForce", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            lvl.SetUFOGeneratedFalse();
            Destroy(ufo);
        }
    }
    
    // Use this for initialization
    void Start () {
        rb = ufo.GetComponent<Rigidbody2D>();
        GenerateRandomForce();
        UfoShoot();
        lvl =  new LoadLevel();
    }
	
	// Update is called once per frame
	void Update () {

    }
}
