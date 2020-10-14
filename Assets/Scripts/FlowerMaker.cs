using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMaker : MonoBehaviour
{
    public GameObject Daisy;
    public float spawnTime = 5f;
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(makeFlowers());
    }

    private void spawnFlowers()
    {
        // add bee to scene
        GameObject f = Instantiate(Daisy) as GameObject;
        f.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), Random.Range(-screenbounds.y, screenbounds.y));
    }

    IEnumerator makeFlowers()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnFlowers();
        }
    }
}
