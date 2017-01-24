﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CameraTargetBehaviour : MonoBehaviour
{
    public VirtualRightJoystick rightJoystick;
    private float verticalInput;
    private float horizontalInput;
    private Transform initialPos;
    private Vector3 astridPos;

    // Use this for initialization
    void Start()
    {

        //initialPos.localPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        verticalInput = rightJoystick.RightVertical();
        horizontalInput = rightJoystick.RightHorizontal();

        //Y Axis
        if (verticalInput > 0.5 && transform.localPosition.y <= 5.5)
        {
            transform.Translate(Vector3.up * (2 * Time.deltaTime));
        }
        if (verticalInput < -0.5 && transform.localPosition.y >= 1.5)
        {
            transform.Translate(Vector3.down * (2 * Time.deltaTime));
        }
        //X Axis
        astridPos = GameObject.Find("AstridPlayer").transform.position;
        if (horizontalInput > 0.5)
        {
            transform.RotateAround(astridPos, Vector3.up, 30 * Time.deltaTime);
        }
        if (horizontalInput < -0.5)
        {
            transform.RotateAround(astridPos, Vector3.down, 30 * Time.deltaTime);
        }
    }
}
