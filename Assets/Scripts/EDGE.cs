using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDGE : MonoBehaviour

{
    public string direction = "right";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "right")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(direction == "left")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Edge"))
        {
            if (direction == "right")
            {
                direction = "left";
                transform.Rotate(0, 180,0);
            }
            else 
            {
                direction = "right";
                transform.Rotate(0, 180,0);
            }
        }
    }
}
