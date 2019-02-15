using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementResponse : MonoBehaviour {

    public Transform a;
    public Transform b;
    public float Period;
    public bool Loop;

    public bool state;
    private float lerp;


    // Use this for initialization
    void Start () {
        transform.position = a.position;
        lerp = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float delta = Time.deltaTime / Period * (state ? 1 : -1);
        lerp += delta;
        if(lerp > 1)
        {
            lerp = 1;
            enabled = Loop;
            state = !state;
        }
        if(lerp < 0)
        {
            lerp = 0;
            enabled = Loop;
            state = !state;
        }
        transform.position = Vector3.Lerp(a.position, b.position, lerp);
    }

    public void Set(bool state)
    {
        enabled = state;
        if (!Loop)
        {
            this.state = state;
            enabled = true;
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if((collision.collider.gameObject.layer == 9 || collision.collider.gameObject.layer == 10) && collision.contacts[0].point.y > transform.position.y)
    //    {
    //        collision.transform.parent = transform;
    //    }
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    if(collision.transform.parent == transform)
    //    {
    //        collision.transform.parent = null;
    //    }
    //}
}
