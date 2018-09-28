﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed;

    private Rigidbody2D characterBody;

    float VerticalInput;

    // Use this for initialization
    void Start () {
        speed = 1f;
        characterBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LUPTouch()
    {
        Debug.Log("LUP");
        transform.Translate(0, speed, 0);

    }
    public void LDownTouch()
    {
        Debug.Log("LDown");
        transform.Translate(0, -speed, 0);
    }
    /*public void RUPTouch()
    {
        Debug.Log("RUP");
    }
    public void RDownTouch()
    {
        Debug.Log("RDown");
    }*/


}
