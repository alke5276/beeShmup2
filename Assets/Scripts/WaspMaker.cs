using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspMaker : MonoBehaviour
{
    public GameObject Wasp;
    public float spawnTime = 5f;
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(makeWasps());
    }

    private void spawnWasp()
    {
        // add bee to scene
        GameObject w = Instantiate(Wasp) as GameObject;
        w.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), Random.Range(-screenbounds.y, screenbounds.y));
    }

    IEnumerator makeWasps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnWasp();
        }
    }
}
