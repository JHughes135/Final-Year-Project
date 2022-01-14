﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotSpeed = 180.0f;
    public Rigidbody human;
    public float jumpForce = 7;
    public CapsuleCollider col;
    public float spinspeed;
    public float spincount;
    public float degree;
    public float jumpcount;



    // Start is called before the first frame update
    void Start()
    {
        human = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        jumpcount = 0;
        spincount = 1;
        degree = 180;
        spinspeed = 6;
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            human.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpcount += 1;
        }

        if(jumpcount == 1 && spincount < degree / spinspeed)
        {
            transform.Rotate(Vector3.down * spinspeed);
            spincount += 1;
        }
        else
        {
            jumpcount = 0;
            spincount = 0;
        }

    }
}