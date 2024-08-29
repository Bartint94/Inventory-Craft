using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool forward;
    public bool backward;
    public bool pickup;
    public float left;
    public float right;
    [SerializeField] float turnMultipiler;
    public event Action isHud;
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        else
        {
            forward = false;
        }

        if(Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        else
        {
            backward = false;
        }


        if(Input.GetKey(KeyCode.A))
        {
            left = -1 * turnMultipiler;
        }
        else
        {
            left = 0;
        }

        if(Input.GetKey(KeyCode.D))
        {
            right = 1 * turnMultipiler;
        }
        else
        {
            right = 0;
        }



        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isHud?.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            pickup = true;
        }
        else
        {
            pickup = false;
        }
    }
}
