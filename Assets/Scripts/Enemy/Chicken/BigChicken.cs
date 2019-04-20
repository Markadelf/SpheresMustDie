using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChicken : MonoBehaviour {

    public ChickenCore core;
    public float healthScale;
    public EyeBallLaser eye;

    private LandAi ai;

	// Use this for initialization
	void Start () {
        core.gameObject.SetActive(false);
        core.Connect(this);
        ai = GetComponent<LandAi>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ReactivateChicken(int health)
    {

    }

    private void OnDisable()
    {
        core.ActivateCore();
    }
}
