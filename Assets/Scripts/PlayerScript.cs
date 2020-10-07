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
    public Image healthBar;
    public KeyCode fireKey;
    
    private float yPos; // move character in up and down directions
    private float xPos; // moving character in left and right directions
    
    // Start is called before the first frame update
    void Start() {
        healthBar.fillAmount = health; // set health bar to match health level
    }

    // Update is called once per frame
    void Update() {
        
        // moving character left
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed;
            }
        }

        // moving character right
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }
        
        // moving character up
        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += speed;
            }
        }
        
        // moving character down
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= speed;
            }
        }

        // shooting darts here
        if (Input.GetKeyDown(fireKey))
        {
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        
        // update location of character
        transform.localPosition = new Vector3(xPos, yPos, 0);
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








