using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour {

    public bool active = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        active = true;
    }

    private void OnDisable()
    {
        if (active)
        {
            ObjectPool.Release(gameObject);
            active = false;
        }
    }

    private void OnApplicationQuit()
    {
        active = false;
    }
}
