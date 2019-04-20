using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyChicken : MonoBehaviour {
    public ChickenCore core;
    public bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDisable()
    {
        if (active)
        {
            core.Health--;
        }
    }

}
