using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    int objectNo;
    public float maxPos = 2.3f;
    Vector3 objectPos;
    float delayTimer = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if( timer <= 0)
        {
            objectPos = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
            objectNo = Random.Range(0, objects.Length);
            Instantiate(objects[objectNo], objectPos, transform.rotation);

            timer = delayTimer;
        }
    }
}
