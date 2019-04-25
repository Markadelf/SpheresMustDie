using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

    ComplexEnemyHealth parent;

    public GameObject Dependant = null;
    public Material Cover;
    private Material normal;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = null;
		if(Cover != null)
        {
            rend = GetComponent<Renderer>();
            normal = rend.material;
            rend.material = Cover;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!Dependant && rend)
        {
            rend.material = normal;
        }
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
