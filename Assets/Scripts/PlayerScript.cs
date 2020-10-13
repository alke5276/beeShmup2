using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = .05f;
    public float leftWall, rightWall, bottomWall, topWall; // walls of game area
    public float health = 1f;
    
    public GameObject projectile;
    public GameObject smoke;
    public Image healthBar;
    public KeyCode fireKey;
    public KeyCode smokeKey;
    
    private float yPos; // move character in up and down directions
    private float xPos; // moving character in left and right directions

    private Rigidbody2D rb;
    //private float angle;

    public Animator animator; // to animate character
    
    // Start is called before the first frame update
    void Start() {
        healthBar.fillAmount = health; // set health bar to match health level
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
        animator.SetFloat("Speed",Mathf.Abs(speed));
        
        //angle += 10;
        //rb.rotation = 165;

        // moving character left
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                //transform.rotation = new Quaternion(-180, 0, 0, 0);
                xPos -= speed;
            }
        }

        // moving character right
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                //transform.rotation = new Quaternion(180, 0, 0, 0);
                xPos += speed;
            }
        }
        
        // moving character up
        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                //transform.rotation = new Quaternion(0, 180, 0, 0);
                yPos += speed;
            }
        }
        
        // moving character down
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                //transform.rotation = new Quaternion(0, -180, 0, 0);
                yPos -= speed;
            }
        }

        // shooting darts here
        if (Input.GetKeyDown(fireKey))
        {
            animator.SetBool("isShooting", true);
            animator.SetBool("isSmoking", false); // can't use smoke gun while shooting
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        
        // shooting smoke here
        if (Input.GetKeyDown(smokeKey))
        {
            animator.SetBool("isSmoking", true);
            animator.SetBool("isShooting", false); // can't use dart gun while smoking
            Instantiate(smoke, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        
        // update location of character
        transform.localPosition = new Vector3(xPos, yPos, 0);
        //transform.LookAt(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bee")
        {
            Destroy(other.gameObject);
            health -= .1f;
            healthBar.fillAmount = health;
        }
    }
}








