using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    float lifeTime = 50;
    public GameObject parent;
    //CapsuleCollider2D cc;
    bool run = false;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Player");
       // cc = this.GetComponent<CapsuleCollider2D>();
        if (this.gameObject.name != "bullet")
            run = true;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (run == true)
            if (lifeTime > 0)
                lifeTime--;
        //if (Vector3.Distance(transform.position, parent.transform.position) > transform.localScale.x)
        //    cc.enabled = true;
        else
        {
            Destroy(this.gameObject);
            Debug.Log("dys");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
