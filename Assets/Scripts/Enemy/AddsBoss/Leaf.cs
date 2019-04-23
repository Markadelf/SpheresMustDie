using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {

    public float XMag;
    public float YMag;
    public float ZMag;
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float XDelay;
    public float YDelay;
    public float ZDelay;
    private Vector3 startPos;
    private FlierAI ai;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        ai = GetComponent<FlierAI>();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = startPos + new Vector3(XMag * Mathf.Sin(XSpeed * Time.time + XDelay), YMag * Mathf.Sin(YSpeed * Time.time + YDelay), ZMag * Mathf.Sin(ZSpeed * Time.time + ZDelay));
        ai.enabled = FirstPerson.GUN_AQUIRED;
    }
}
