using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() 
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // when flower is grabbed by player
        if (other.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject); // remove daisy
        }
        
        // when bee gets to flower
        if (other.gameObject.tag == "Bee")
        {
            Destroy(this.gameObject); // remove daisy
        }
    }
}
