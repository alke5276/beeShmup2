using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartScript : MonoBehaviour 
{
    public float speed = 2f;
    public int direction;
    private Rigidbody2D rb;
    static public bool beeHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }
    
    private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        rb.AddForce(transform.up * speed * direction);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bee") // if another bee
        { 
            return;
        }

        if (other.gameObject.tag == "Player") // if we hit the character, destroy the projectile
        { 
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // when darts hit the bee
        if (other.gameObject.tag == "Bee") 
        {
            Destroy(this.gameObject); // destroy dart
            beeHit = true; // agro the bees
        }

        // when darts hit the wall
        if (other.gameObject.tag == "wall") // if we shoot a dart at a wall
        {
            Destroy(this.gameObject); // destroy dart
        }
        
        // when darts hit the wasp
        if (other.gameObject.tag == "Wasp")
        {
            Destroy(other.gameObject); // remove wasp
            Destroy(this.gameObject); // destroy dart
        }
        
        // when darts hit the wasp
        if (other.gameObject.tag == "Hive")
        {
            Destroy(this.gameObject); // destroy dart
        }
        
        // dart hits another dart
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject); 
            Destroy(this.gameObject); // destroy dart
        }
    }
}
