using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public float speed = 5f;
    public int direction;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("Launch");
    }
    
    //private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        //rb.AddForce(transform.up * speed * direction);
        //yield return null;
    //}
    
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
        // when smoke hits the bee
        if (other.gameObject.tag == "Bee") 
        {
            Destroy(this.gameObject); // destroy smoke
            DartScript.beeHit = false; // de-agro the bees
        }

        // when smoke hits the wall
        if (other.gameObject.tag == "wall") // if we shoot smoke at a wall
        {
            Destroy(this.gameObject); // destroy smoke
        }
        
        // when smoke hits the wasp
        if (other.gameObject.tag == "Wasp")
        {
            Destroy(this.gameObject); // destroy smoke
        }
        
        // when smoke hits the hive
        if (other.gameObject.tag == "Hive")
        {
            Destroy(this.gameObject); // destroy smoke
        }
        
        // smoke hits more smoke
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject); 
            Destroy(this.gameObject); // destroy smoke
        }
        
        // if smoke hits daisy
        if (other.gameObject.tag == "Daisy")
        {
            Destroy(this.gameObject); // destroy smoke
        }
    }
}

