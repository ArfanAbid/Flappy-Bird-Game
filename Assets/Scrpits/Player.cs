using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int spriteIndex;


    private Vector3 direction;
    public float gravity = -15f;// -9.8
    public float strength = 7f; // 5

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Script is running");
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }



    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        { 
            // Either press spacebar or left click mouse
            direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0)
        { 
            // if there is at least one touch on the screen (mobile)
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
        
    }    
}
