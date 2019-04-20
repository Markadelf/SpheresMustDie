using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallLaser : MonoBehaviour {
    public float Agility;
    public float SightDistance = -1;
    public LayerMask BlockSight = 1;
    public float MaxTilt;

    private Gun blaster;
    private bool alert;
    public bool Alert { get { return alert; } }

	// Use this for initialization
	void Start () {
        blaster = GetComponent<Gun>();
        alert = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (FirstPerson.PLAYER)
        {
            Vector3 toPlayer = FirstPerson.PLAYER.transform.position - transform.position;
            if (alert)
            {
                transform.forward = Vector3.RotateTowards(Vector3.forward, Vector3.RotateTowards(transform.forward, toPlayer, Agility * Time.deltaTime, 10000), MaxTilt, 100000);
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
