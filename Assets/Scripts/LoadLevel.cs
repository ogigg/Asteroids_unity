using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    public GameObject asteroid_big;


    void Generate_Big_Asteroid(int seed)
    {
        System.Random rnd = new System.Random(seed);
        Vector3 Position_vector3 = new Vector3(rnd.Next(-110, 110)/10, rnd.Next(-45, 45)/10,0);
        Instantiate(asteroid_big, Position_vector3, Quaternion.identity);
    }
    // Use this for initialization
    void Start () {	
        for (int i=0;i<8;i++)
        {
            Generate_Big_Asteroid(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
