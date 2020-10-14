using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour // https://www.youtube.com/watch?v=7-8nE9_FwWs
{
    private Vector3 target; // player follow mouse
    public GameObject crosshairs; // target of where shooting
    public GameObject player;
    public GameObject dart;
    public GameObject smoke;
    
    public GameObject aim;
    public Transform muzzle;
    
    void Start()
    {
        Cursor.visible = false; // hide mouse
    }
    
    void LateUpdate() // making player not glitch when turning - https://answers.unity.com/questions/1688948/camera-rotation-very-choppy-and-jittery.html
    {
        // code for making player follow mouse and shoot
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)); 
        crosshairs.transform.position = new Vector2(target.x, target.y);
        Vector3 difference = target - muzzle.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float rotationZ2 = rotationZ + 90;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ2);
        
        if (Input.GetMouseButtonDown(0)) // left click to shoot darts
        {
            PlayerScript.animator.SetBool("isShooting", true);
            PlayerScript.animator.SetBool("isSmoking", false); // can't use smoke gun while shooting
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            rotationZ += 270;
            fireDart(direction, rotationZ);
        }
        
        // https://forum.unity.com/threads/onmousedown-for-right-click.7131/
        
        if (Input.GetMouseButtonDown(1)) // right click to shoot smoke
        {
            PlayerScript.animator.SetBool("isSmoking", true);
            PlayerScript.animator.SetBool("isShooting", false); // can't use dart gun while smoking
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            rotationZ += 270;
            fireSmoke(direction, rotationZ);
        }
    }
    
    public void fireDart(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(dart) as GameObject;
        b.transform.position = muzzle.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * DartScript.speed;
    }
    
    public void fireSmoke(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(smoke) as GameObject;
        b.transform.position = muzzle.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * DartScript.speed;
    }
    
}
