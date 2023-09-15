using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter()
    {
        Debug.Log("touched");
        //Some script to close the game
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touched");
        if (collision.collider.name == "Player")
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
