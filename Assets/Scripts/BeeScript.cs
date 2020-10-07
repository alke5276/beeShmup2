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
    
    // Start is called before the first frame update
    void Start() 
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        // moving bee direction to follow player
        Vector3 direction = player.transform.position - transform.position;
        // Debug.Log(direction);
        
        // make bee face player?
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
        // move side to side
        // float offset = Mathf.Sin(Time.time * speed) * amplitude / 2;
        // transform.position = new Vector2(offset, transform.position.y);
    }

    // update bee movement
    private void FixedUpdate()
    {
        if (DartScript.beeHit == true)
        {
            moveBee(movement);
        }
    }

    // making the bee move 
    void moveBee(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
