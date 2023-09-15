using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{

    public Transform Follow;
    public float avgFrameRate;
    public float Max_Distance = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (Follow == null)
        {
            Follow = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 unitedVector = mousePos;
        //if (Vector3.Distance(unitedVector, Follow.position) > Max_Distance)
        //{
        //    unitedVector = (mousePos.normalized * Max_Distance) + Follow.position;
        //}
        Vector3 mixed = Vector3.Lerp(Follow.position, unitedVector, 0.25f);
        transform.position = new Vector3(mixed.x, mixed.y, this.transform.position.z);
        avgFrameRate = Time.frameCount / Time.time;
    }
}
