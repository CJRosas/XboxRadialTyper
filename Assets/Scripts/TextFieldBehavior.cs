using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextFieldBehavior : MonoBehaviour
{
    public TextMeshProUGUI textfield;
    public static ArrayList outputText = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outputText.Count == 0) 
        {
            textfield.text = "[begin typing]";
        }
        else 
        {
            string displayText = String.Join("", outputText.ToArray());  
            textfield.text = displayText;
        }
        
    }

    public static void AddLetter(string key)
    {
        outputText.Add(key);
    }

    public static void Backspace() 
    {
        if (outputText.Count > 0) 
        {
            outputText.RemoveAt(outputText.Count - 1);
        }
        
    }

    public static void AddSpace() {
        outputText.Add(" ");
    }

    public static void Clear() 
    {
        outputText = new ArrayList();
    }
}
