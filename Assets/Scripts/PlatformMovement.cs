using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDirectionLeft = true;
    private float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDirectionLeft)
        {
            transform.position += new Vector3(velocity * -1 * Time.deltaTime,0,0);
        }else
        {
            transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        }
        if (transform.position.x < startPosition.x - 1 || transform.position.x > startPosition.x + 1)
        {
            isDirectionLeft = !isDirectionLeft;
        }
    }
}
