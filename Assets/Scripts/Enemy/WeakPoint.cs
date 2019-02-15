using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

    ComplexEnemyHealth parent;

    public GameObject Dependant = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Claim(ComplexEnemyHealth parent)
    {
        this.parent = parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 && !Dependant)
        {
            Destroy(gameObject);
            if(parent != null)
                parent.NotifyDeath();
        }
    }
}
