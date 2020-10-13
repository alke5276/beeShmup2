using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaspScript : MonoBehaviour
{
    private GameObject hive;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2f;
    
    //public Image healthBar;

    // Start is called before the first frame update
    void Start() 
    {
        hive = GameObject.Find("Hive");
        // healthBar = Image.Find("HealthBar");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        // moving wasp direction to face hive
        Vector3 direction = hive.transform.position - transform.position;

        // make wasp face hive
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 160; // make wasps face better
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    // update wasp movement
    private void FixedUpdate()
    {
        moveWasp(movement); 
    }

    // making the wasp move 
    void moveWasp(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // when wasp gets to hive
        if (other.gameObject.tag == "Hive") 
        {
            Destroy(this.gameObject); // destroy wasp
            // PlayerScript.health -= .1f;
            // healthBar.fillAmount = PlayerScript.health;
        }

        // when wasp hits bee
        if (other.gameObject.tag == "Bee")
        {
            Destroy(other.gameObject); // remove bee
        }
    }
}
