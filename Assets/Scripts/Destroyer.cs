using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) //col is a variable which holds the object with which the collision happens
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Pill" || collision.gameObject.tag == "Vaccine")
        {
            Destroy(collision.gameObject);
        }
    }
}
