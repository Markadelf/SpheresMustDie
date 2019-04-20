using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWeakPoint : MonoBehaviour {

    ChickenEnemyHealth parent;

    public GameObject Dependant = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Claim(ChickenEnemyHealth parent)
    {
        this.parent = parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12 && (!Dependant || !Dependant.activeInHierarchy))
        {
            gameObject.SetActive(false);
            if(parent != null)
                parent.NotifyDeath();
        }
    }
}
