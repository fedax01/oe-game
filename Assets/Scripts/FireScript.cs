using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireScript : MonoBehaviour
{
    public GameObject wizard;
    private Wizardbehaviour wizardbehaviour;
    public float velocity;
    private Vector3 startPoint;
    private bool isMoving = false;
    private Renderer renderer;
    private bool fireHeadingLeft = false;
    private Vector3 fireSprite;
    // Start is called before the first frame update
    void Start()
    {
        wizardbehaviour = wizard.GetComponent<Wizardbehaviour>();
        renderer = this.GetComponent<Renderer>();
        fireSprite = transform.localScale;
        renderer.sortingOrder = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            fireHeadingLeft = wizardbehaviour.isHeadingLeft;
            gameObject.transform.position = new Vector3(wizard.transform.position.x, wizard.transform.position.y - 0.2f, wizard.transform.position.z);
            renderer.sortingOrder = 2;
            isMoving = true;
           startPoint = new Vector3(wizard.transform.position.x, wizard.transform.position.y, wizard.transform.position.z);
        }
        if (isMoving)
        {
            if (fireHeadingLeft)
            {
                Vector3 newScale = fireSprite;
                newScale.x *= -1;
                transform.localScale = newScale;
                transform.position -= new Vector3(Time.deltaTime * velocity, 0, 0);
            }
            else
            {
                transform.localScale = fireSprite;
                transform.position += new Vector3(Time.deltaTime * velocity, 0, 0);
            }
            if (Math.Abs(startPoint.x - transform.position.x) > 3) 
            {
                FireballMoveout();
            }
        }
    }
    private void FireballMoveout()
    {
        gameObject.transform.position = new Vector3 (11,0,0);
        isMoving = false;
        renderer.sortingOrder = -2;

    }
}
