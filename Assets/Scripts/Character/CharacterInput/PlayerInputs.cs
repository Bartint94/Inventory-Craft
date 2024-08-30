using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool forward;
    public bool backward;
    public bool pickup;
    public float left;
    public float right;


    
    [SerializeField] float turnMultipiler;
    public event Action onInventory;
    public event Action onCraft;

    public event Action onDrop;
    public event Action onTryCraft;


    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        else
        {
            forward = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        else
        {
            backward = false;
        }


        if (Input.GetKey(KeyCode.A))
        {
            left = -1 * turnMultipiler;
        }
        else
        {
            left = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = 1 * turnMultipiler;
        }
        else
        {
            right = 0;
        }
    }


    public void InventoryInput()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            onDrop?.Invoke();
        }

    }

    public void CraftInput()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            onTryCraft?.Invoke();
        }
    }
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            onInventory?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            onCraft?.Invoke();  
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
