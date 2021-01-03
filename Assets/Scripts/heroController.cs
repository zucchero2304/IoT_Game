using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour
{

    public float heroSpeed;
    float maxPos = 2.3f; 
    Vector3 position; 
    public GameUiManager ui;
    public AudioManager audioManager;

    bool currentPlatformAndroid = false;

    string steeringMethod;

    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
            currentPlatformAndroid = false;
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        steeringMethod = PlayerPrefs.GetString("SteeringMethod");

        position = transform.position; 

        if (currentPlatformAndroid)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Windows");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid) 
        { //android 

            if (steeringMethod == "touch")
            {
                TouchMove();
            }
            else if (steeringMethod == "tilt")
            {
                AccelerometerMove();
            }
        }
        else
        { //windows 
            // input from left and right arrow keys
            position.x += Input.GetAxis("Horizontal") * heroSpeed * Time.deltaTime;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos); //limits val of variable to min and max
        transform.position = position;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            audioManager.screamSound.Play();
            gameObject.SetActive(false);
            ui.GameOverActivated();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Pill")
        {
            ui.AddPillBonus();
            Destroy(collision.gameObject);
            audioManager.collectSound.Play();
        }
        else if (collision.gameObject.tag == "Vaccine")
        {
            ui.AddVaccineBonus();
            Destroy(collision.gameObject);
            audioManager.collectSound.Play();
        }
    }

    void TouchMove()
    {
        if (Input.touchCount > 0) //touchCount stores current touches on the screen
        {
            Touch touch = Input.GetTouch(0); //returns first touch
            float screenVerticalMiddle = Screen.width / 2;
            float screenBottomThreeQuarters = Screen.height * 3 / 4; //prevent movement when clicking button on top

            if (touch.position.x < screenVerticalMiddle && touch.position.y < screenBottomThreeQuarters && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > screenVerticalMiddle && touch.position.y < screenBottomThreeQuarters && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
        }
        else SetVelocityZero();
    }

    void AccelerometerMove()
    {
        float x = Input.acceleration.x;
        Debug.Log("Tilt X =" + x);
        if (x < -0.1f)
        {
            MoveLeft();
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }

    public void MoveLeft()
    {
        rigidBody.velocity = new Vector2(-heroSpeed, 0);
    }

    public void MoveRight()
    {
        rigidBody.velocity = new Vector2(heroSpeed, 0);
    }
    public void SetVelocityZero()
    {
        rigidBody.velocity = Vector2.zero;
    }

}
