using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public GameUiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Mark Box Collider as "is trigger" to make objects pass through it
    {
        if (collision.gameObject.tag == "Enemy")
        {
            uiManager.ScoreUpdate();
        }
    }
    
}
