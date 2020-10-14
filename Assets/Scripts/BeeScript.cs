using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour 
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    
    // public float speed = 2f;
    // public float amplitude = 0.5f;
    
    public Animator animator; // to animate bee - https://www.youtube.com/watch?v=hkaysu1Z-N8
    
    // Start is called before the first frame update
    void Start() 
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (DartScript.beeHit == true) // if character has hit bee with dart
        {
            // moving bee direction to follow player
            Vector3 direction = player.transform.position - transform.position;
            // Debug.Log(direction);

            // make bee face player?
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 165; // make bees face better
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

        // move side to side
        // float offset = Mathf.Sin(Time.time * speed) * amplitude / 2;
        // transform.position = new Vector2(offset, transform.position.y);
    }

    // update bee movement
    private void FixedUpdate()
    {
        if (DartScript.beeHit == true) // if the bees are agro
        {
            moveBee(movement); // follow the character
            animator.SetBool("isHit", true);
        }

        if (DartScript.beeHit == false) // if bees are not agro
        {
            busyBee(); // buzz around
            animator.SetBool("isHit", false);
        }
    }

    // making the bee move 
    void moveBee(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
    // bee just moving around hanging out, coming and going
    void busyBee() 
    {
        Vector2 Movement = new Vector2 (Random.Range(-5, 5), Random.Range(-4, 4));
        rb.AddForce(Movement);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // when bee gets to player
        if (other.gameObject.tag == "Player") 
        {
            if (DartScript.beeHit == true)
            {
                Destroy(this.gameObject); // destroy bee only when agro
            }
        }
        
        // when bee gets to flower
        if (other.gameObject.tag == "Daisy")
        {
            Destroy(other.gameObject); // remove daisy
        }
    }
}
