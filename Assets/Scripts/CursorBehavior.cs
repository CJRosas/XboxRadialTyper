using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CursorBehavior : MonoBehaviour
{

    public InputAction LeftStickHorizontal;
    public InputAction rightBumper;
    public InputAction rightTrigger;
    public GameObject cursor;
    public InputAction space;
    public InputAction backspace;

    // Start is called before the first frame update
    void Start()
    {
        LeftStickHorizontal.Enable();
        rightBumper.Enable();
        rightTrigger.Enable();
        space.Enable();
        backspace.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var xValue = LeftStickHorizontal.ReadValue<float>();
        var yValue = cursor.transform.position.y;

        // HORIZONTAL MOVEMENT CODE
        if (yValue == 1.5f) 
        {
            cursor.transform.position = new Vector3(xValue * 4.7f, yValue, -1.0f);
        }
        else if (yValue == 0.3f) 
        {
            cursor.transform.position = new Vector3(xValue * 3.8f, yValue, -1.0f); //Varied values may be hard to deal with, make standard
        }
        else 
        {
            cursor.transform.position = new Vector3(xValue * 2.8f, yValue, -1.0f);
        }
        

        // CHANGING LEVEL CODE
        if(rightBumper.IsPressed())
        {
            if (rightBumper.WasPressedThisFrame())
            {
                if (yValue == 0.3f) 
                {
                    cursor.transform.position = new Vector3(xValue, 1.5f, -1.0f);
                } 
                else if (yValue == -1.0f) 
                {
                    cursor.transform.position = new Vector3(xValue, 0.3f, -1.0f);
                }
            }
        }
        if (rightTrigger.IsPressed()) 
        {
            if (rightTrigger.WasPressedThisFrame()) 
            {
                if (yValue == 1.5f) 
                {
                    cursor.transform.position = new Vector3(xValue, 0.3f, -1.0f);
                } 
                else if (yValue == 0.3f) 
                {
                    cursor.transform.position = new Vector3(xValue, -1.0f, -1.0f);
                }
            }
        }

        // Add spaces
        if (space.IsPressed()) {
            if (space.WasPressedThisFrame()) {
                TextFieldBehavior.AddSpace();
            }
        }

        // Backspace character
        if (backspace.IsPressed()) {
            if (backspace.WasPressedThisFrame()) {
                TextFieldBehavior.Backspace();
            }
        }
    }
}
