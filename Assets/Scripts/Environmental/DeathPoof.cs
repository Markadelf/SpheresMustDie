using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoof : MonoBehaviour {

    private ParticleSystem particle;

	// Use this for initialization
	void Awake () {
        particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!particle.isEmitting)
        {
            ObjectPool.Release(gameObject);
        }
	}

    private void OnEnable()
    {
        particle.Play();
    }
}
