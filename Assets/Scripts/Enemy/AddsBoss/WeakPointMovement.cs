using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointMovement : MonoBehaviour {

    public float speed;
    public GameObject centerObj;
	// Use this for initialization
	void Start () {
        if (!FirstPerson.EASY_MODO)
        {
            this.transform.position = this.transform.parent.position + new Vector3(0, 3, 1);
        }
        else if (FirstPerson.EASY_MODO) {
            this.transform.position = this.transform.parent.position + new Vector3(0, 0.2f, 2);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!FirstPerson.EASY_MODO)
        {
            this.transform.RotateAround(centerObj.transform.position, centerObj.transform.forward, speed * Time.deltaTime);
        }      
	}
}
