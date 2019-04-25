using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlierAI : MonoBehaviour {
    public float Speed;
    public float Agility;
    public float SightDistance = -1;
    public LayerMask BlockSight = 1;
    public float YWeight = 1;
    public float angleLimit = 90; // between 0 and 90

    private Rigidbody rigid;
    private Gun blaster;
    private bool alert;
    public bool Alert { get { return alert; } }

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        blaster = GetComponent<Gun>();
        alert = false;
    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = Vector3.zero;
        if (FirstPerson.PLAYER)
        {
            Vector3 toPlayer = FirstPerson.PLAYER.transform.position - transform.position;
            toPlayer.y *= YWeight;
            if (alert)
            {
                transform.forward = Vector3.RotateTowards(Vector3.down, Vector3.RotateTowards(Vector3.up, Vector3.RotateTowards(transform.forward, toPlayer, Agility * Time.deltaTime, 10000), (angleLimit + 90) * Mathf.Deg2Rad, 1000), (angleLimit + 90) * Mathf.Deg2Rad, 1000);
                rigid.velocity = transform.forward * Speed;
                if (blaster)
                {
                    blaster.TryShoot();
                }
            }
            else
            {
                alert = CanSeePlayer(toPlayer);
            }
        }
	}

    bool CanSeePlayer(Vector3 toPlayer)
    {
        float mag = toPlayer.magnitude;
        if(mag > SightDistance && SightDistance != -1)
        {
            return false;
        }
        Ray ray = new Ray(this.transform.position, toPlayer);
        if(!Physics.Raycast(ray, toPlayer.magnitude, BlockSight))
        {
            return true;
        }
        return false;
    }

}
