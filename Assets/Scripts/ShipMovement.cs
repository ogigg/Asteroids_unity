using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public JoystickControl joystick;
    public float Bullet_Forward_Force;

    public void Shoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.tag = "Bullet";
        Rigidbody2D Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
        Temporary_RigidBody.AddForce(transform.forward + transform.TransformVector(0, 300, 0));
        Destroy(Temporary_Bullet_Handler, 7.0f);
    }
    public void ShipPush()
    {
        rb.AddForce(transform.TransformVector(0, 70, 0));
    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    int n = 0;
    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(joystick.JoystickAngle()*-1);

        if (Input.GetKey("a"))
        {
            rb.MoveRotation(rb.rotation + 5);
        }
        if (Input.GetKey("d"))
        {
            rb.MoveRotation(rb.rotation - 5);
        }
        if (Input.GetKey("w"))
        {
            ShipPush();
        }
        if (Input.GetKey("space"))
        {
            if (n > 3) {
                Shoot();
                n = 0;
                    }
            n++;
        }
    }
}
