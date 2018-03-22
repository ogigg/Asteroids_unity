using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public GameObject asteroid_big;
    public GameObject ufo;
    private bool UFO_generated;
    

    void Generate_Big_Asteroid(int seed)
    {
        System.Random rnd = new System.Random(seed);
        Vector3 Position_vector3 = new Vector3(rnd.Next(-110, 110)/10, rnd.Next(-45, 45)/10,0);
        Instantiate(asteroid_big, Position_vector3, Quaternion.identity);
    }
    void Generate_UFO()
    {
        System.Random rnd = new System.Random();
        Vector3 Position_vector3 = new Vector3(rnd.Next(-110, 110) / 10, rnd.Next(-45, 45) / 10, 0);
        Instantiate(ufo, Position_vector3, Quaternion.identity);
    }
    // Use this for initialization
    void Start () {	
        for (int i=0;i<10;i++)
        {
            Generate_Big_Asteroid(i);
        }
        UFO_generated = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Asteroid_big").Length==0 &&
            GameObject.FindGameObjectsWithTag("Asteroid_small").Length == 0) //Checking if there is any asteroid left  !WORKING!
        {
            SceneManager.LoadScene(2); //WinScene

        }
        if (GameObject.FindGameObjectsWithTag("Asteroid_big").Length == 10 && UFO_generated == false) //Checking if there is 5 asteroid left !WORKING!
        {
            Generate_UFO();
            UFO_generated = true;
        }

    }
}
