using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMaker : MonoBehaviour
{
    public GameObject Bee;
    public float spawnTime = 1f;
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(makeBees());
    }

    private void spawnBee()
    {
        // add bee to scene
        GameObject b = Instantiate(Bee) as GameObject;
        b.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), Random.Range(-screenbounds.y, screenbounds.y));
    }

    IEnumerator makeBees()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnBee();
        }
    }
}
