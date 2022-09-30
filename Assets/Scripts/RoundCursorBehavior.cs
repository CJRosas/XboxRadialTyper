using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class RoundCursorBehavior : MonoBehaviour
{

    public InputAction LeftStickHorizontal;
    public InputAction LeftStickVertical;
    public GameObject cursor;
    public InputAction space;
    public InputAction backspace;
    public InputAction clear;
    public InputAction tapLeft;
    public InputAction tapRight;
    private bool tapMode;

    // Start is called before the first frame update
    void Start()
    {
        LeftStickHorizontal.Enable();
        LeftStickVertical.Enable();
        space.Enable();
        backspace.Enable();
        clear.Enable();
        tapLeft.Enable();
        tapRight.Enable();
        tapMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        var xValue = LeftStickHorizontal.ReadValue<float>();
        var yValue = LeftStickVertical.ReadValue<float>();

        // MiddleRow
        if (yValue == 0.0f) 
        {
            if(tapLeft.IsPressed()) {
                tapMode = true;
                if(tapLeft.WasPressedThisFrame()) {
                    cursor.transform.position = new Vector3(cursor.transform.position.x - 1.0f, -1.26f, -1.0f);
                }
            }

            if(tapRight.IsPressed()) {
                tapMode = true;
                if(tapRight.WasPressedThisFrame()) {
                    cursor.transform.position = new Vector3(cursor.transform.position.x + 1.0f, -1.26f, -1.0f);
                }
            }

            if (!tapMode) {
                /// xValue^3 is a little chaotic
                cursor.transform.position = new Vector3(( xValue) * 3.8f, -1.26f, -1.0f); 
            }

            if (xValue != 0) {
                tapMode = false;
            }
        }
        // TopRow
        else if (yValue > 0.1f)
        {
            cursor.transform.position = new Vector3(xValue * 4.35f, 0.0f + yValue, -1.0f);
        }
        // BottomRow
        else if (yValue < -0.1f) 
        {
            cursor.transform.position = new Vector3(xValue * 3.2f, -3.08f, -1.0f);
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

        if (clear.IsPressed()) {
            if (clear.WasPressedThisFrame()) {
                TextFieldBehavior.Clear();
            }
        }

    }
}
