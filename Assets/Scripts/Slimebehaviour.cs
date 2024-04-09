using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slimebehaviour : MonoBehaviour
{
    public GameObject wizard;
    private float velocity = 1f;
    private bool isMoving = true;
    private bool isBounceBack = false;
    private float bounceBackVelocity = 3.5f;
    public GameObject killedSlimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 slimePosition = new Vector3(0, 0, 0);
        if (transform.position.x < wizard.transform.position.x)
        {
            
            if (isMoving)
            {
                slimePosition = new Vector3(velocity * Time.deltaTime, 0, 0);
            }
            else if(isBounceBack) 
            {
                slimePosition = new Vector3(bounceBackVelocity * -1 * Time.deltaTime, bounceBackVelocity * Time.deltaTime, 0);

            }
        }else
        {
            if (isMoving)
            {
                slimePosition = new Vector3(velocity * Time.deltaTime * -1, 0, 0);
            }
            else if (isBounceBack)
            {
                slimePosition = new Vector3(bounceBackVelocity * Time.deltaTime, bounceBackVelocity * Time.deltaTime, 0);
            }
        }
        transform.position += slimePosition;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            KilledSlimeCounter killedSlimeCounterScript = killedSlimeCounter.GetComponent<KilledSlimeCounter>();
            killedSlimeCounterScript.CountSlimes();
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.CompareTag("Ground")) 
        {
            isMoving = true;
            isBounceBack = false;
        }
       else if (collision.gameObject.CompareTag("Wizard"))
        {
            isMoving = false;
            isBounceBack = true;
        }
    }
}
