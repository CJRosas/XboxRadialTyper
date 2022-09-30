using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class KeyBehavior : MonoBehaviour
{
    public GameObject key;
    public GameObject cursor;
    private float key_x;
    private float key_y;
    private SpriteRenderer sprite;
    public AudioClip HighClick;
    public AudioClip LowClick;
    private AudioSource audioPlayer;
    private bool played = false;
    public InputAction Select;

    // Start is called before the first frame update
    void Start()
    {
        key_x = key.transform.position.x;
        key_y = key.transform.position.y;
        sprite = key.GetComponent<SpriteRenderer>();
        audioPlayer = cursor.GetComponent<AudioSource>();
        Select.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float cursor_x = cursor.transform.position.x;
        float cursor_y = cursor.transform.position.y;
        
        if (key_x <= (cursor_x + 0.5) && key_x >= (cursor_x - 0.5) && key_y <= (cursor_y + 0.5) && key_y >= (cursor_y - 0.5)) 
        {
            sprite.color = Color.cyan;
            if (!played) 
            {
                audioPlayer.PlayOneShot(HighClick); 
                played = true;
            }
            if(Select.IsPressed())
            {
                if(Select.WasPressedThisFrame())
                {
                    audioPlayer.PlayOneShot(LowClick);
                    TextFieldBehavior.AddLetter(key.name);
                }
                sprite.color = Color.blue;
            }
        }
        else 
        {
            sprite.color = Color.white;
            played = false;
            
        }        
    }
}
