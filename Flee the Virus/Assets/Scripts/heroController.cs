using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour
{

    public float heroSpeed;
    float maxPos = 2.3f; //f signifies float
    Vector3 position; //temporary position of the car
    public GameUiManager ui;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; //assign the current position of the car
    }

    // Update is called once per frame
    void Update()
    {
        //get input from left and right arrow keys
        position.x += Input.GetAxis("Horizontal") * heroSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos); //limits val of variable to min and max

        transform.position = position;


    }

    void OnCollisionEnter2D(Collision2D col) //called when this game object collides with a different one
    {
        //check if we're colliding with enemy cars
        if(col.gameObject.tag == "Enemy")
        {
            audioManager.gameOverScream.Play();
            Destroy(gameObject);
            ui.GameOverActivated();
        }
    }
}
