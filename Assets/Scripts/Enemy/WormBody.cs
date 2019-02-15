using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBody : MonoBehaviour {

    public WeakPoint Weak;
    public Transform Connect;
    public WormBody Next;
    public Vector3 delta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void WormMove (Vector3 pos, float dist) {
        Vector3 delta = pos - transform.position;
        transform.forward = delta;
        transform.position = pos - (delta.normalized * dist);
        if(Next)
            Next.WormMove(transform.position, dist);
    }
}
