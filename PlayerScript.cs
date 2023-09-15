using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    const float speed = 0.5f;
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    GameObject cam;

    public float TimerDelay = 10;
    float Timer = 10;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        rb = this.GetComponentInParent<Rigidbody2D>();
        cc = this.GetComponentInParent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //cam.transform.position = transform.position;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 PlayerPosition = this.transform.position;
        this.transform.rotation = Quaternion.Euler(0,0, math.degrees((float)Math.Atan2(mousePos.y - PlayerPosition.y, mousePos.x - PlayerPosition.x)));
        Vector2 oldVel = rb.velocity;

        if (Timer > 0)
        {
            Timer--;
        }
        if (Input.GetKey(KeyCode.W))
            rb.velocity += new Vector2(0,speed);
        if (Input.GetKey(KeyCode.D))
            rb.velocity += new Vector2(speed, 0);
        if (Input.GetKey(KeyCode.A))
            rb.velocity += new Vector2(-speed, 0);
        if (Input.GetKey(KeyCode.S))
            rb.velocity += new Vector2(0, -speed);

        if (Input.GetKey(KeyCode.Space) && Timer <= 0)
        {
            Timer = TimerDelay;
            Debug.Log("shot");
            var bullet = Instantiate(GameObject.Find("bullet"), transform);
            bullet.transform.position = transform.position + (transform.right);
            //bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.transform.right * 60;
            bullet.transform.SetParent(null, true);
            bullet.name = "bClone";
        }
        if (rb.velocity.magnitude > 40)
        {
            rb.velocity = oldVel;
        }
    }
}
