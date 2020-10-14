using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = .05f;
    public float leftWall, rightWall, bottomWall, topWall; 
    public static float health = 1f;
    
    //public GameObject projectile;
    //public GameObject smoke;
    //public KeyCode fireKey;
    //public KeyCode smokeKey;
    
    public static Image healthBar;
    
    private float yPos; // move character in up and down directions
    private float xPos; // moving character in left and right directions

    private Rigidbody2D rb;

    public Animator animator; // to animate character - https://www.youtube.com/watch?v=hkaysu1Z-N8

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>(); // https://support.unity3d.com/hc/en-us/articles/206369473-NullReferenceException
        healthBar.fillAmount = health; // set health bar to match health level
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (healthBar.fillAmount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    void Update()
    {
        // animate character
        animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.SetFloat("Speed",Mathf.Abs(speed));

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
        //if (Input.GetKeyDown(fireKey))
        //{
            //animator.SetBool("isShooting", true);
            //animator.SetBool("isSmoking", false); // can't use smoke gun while shooting
            //Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        //}
        
        // shooting smoke here
        //if (Input.GetKeyDown(smokeKey))
        //{
            //animator.SetBool("isSmoking", true);
            //animator.SetBool("isShooting", false); // can't use dart gun while smoking
            //Instantiate(smoke, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        //}
        
        // update location of character
        transform.localPosition = new Vector3(xPos, yPos, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // running into bees
        if (other.gameObject.tag == "Bee")
        {
            // only delete bees when they are aggressive and sting you
            if (DartScript.beeHit == true)
            {
                Destroy(other.gameObject);
                health -= .1f;
                healthBar.fillAmount = health;
            }
        }
        
        // pick up daisies to add health
        if (other.gameObject.tag == "Daisy") 
        {
            Destroy(other.gameObject);
            health += .1f;
            healthBar.fillAmount = health;
        }
        
        // don't run into wasps
        if (other.gameObject.tag == "Wasp")
        {
            health -= .1f;
            healthBar.fillAmount = health;
        }
        
        // if hitting darts
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("Hit player");
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}








