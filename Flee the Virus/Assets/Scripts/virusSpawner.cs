using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusSpawner : MonoBehaviour
{
    public GameObject[] viruses;
    int virusNo;
    public float maxPos = 2.3f;
    Vector3 virusPos;
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
            virusPos = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
            virusNo = Random.Range(0, viruses.Length);
            Instantiate(viruses[virusNo], virusPos, transform.rotation);

            timer = delayTimer;
        }
    }
}
