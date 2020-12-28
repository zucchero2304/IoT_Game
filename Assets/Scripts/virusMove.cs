using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusMove : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime); //to move it down
    }
}
