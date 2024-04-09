using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Wizardbehaviour : MonoBehaviour
{
    private float velocity = 6;
    private Rigidbody2D rigidBody;
    private bool jumping = false;
    private float velocitySide = 2;
    public bool isHeadingLeft = false;
    private Vector3 wizardSprite;
    public GameObject lifeheader;
    private LifeScript lifeScript;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        wizardSprite = transform.localScale;
        lifeScript = lifeheader.GetComponent<LifeScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumping == false )
        {
            jumping = true;
            rigidBody.velocity = Vector2.up * velocity;
        }
        if (Keyboard.current.aKey.IsPressed())
        {
            transform.position += Vector3.left * Time.deltaTime * velocitySide;
            isHeadingLeft = true;
            
        }
        if (Keyboard.current.dKey.IsPressed())
        {
            transform.position += Vector3.right * Time.deltaTime * velocitySide;
            isHeadingLeft = false;
           
        }

        //Sprite tükrözése
        if (Keyboard.current.aKey.wasPressedThisFrame) 
        {
            Vector3 scale = transform.localScale;

            // Invert the scale on the X-axis to mirror the sprite horizontally
            scale.x  = wizardSprite.x * -1;

            // Apply the new scale to the GameObject
            transform.localScale = scale;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Vector3 scale = transform.localScale;

            // Invert the scale on the X-axis to mirror the sprite horizontally
            scale.x = wizardSprite.x;

            // Apply the new scale to the GameObject
            transform.localScale = scale;
        }

    }
     public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && jumping == true && IsBelow(collision.gameObject) == false)
        {
            jumping = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeScript.DecreaseLife();
        }
        
        print("Entered collision with " + collision.gameObject.name);
    }
    public bool IsBelow(GameObject other)
    {
        Vector3 wizardPosition = transform.position;
        Vector3 otherPosition = other.transform.position;
        return wizardPosition.y < otherPosition.y;
    }
   
}
