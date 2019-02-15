using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int MaxHealth = 1000;
    public float WeakPointRadius;
    public Transform weakPoint;

    //private int health;

    // Use this for initialization
    void Start()
    {
        //health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.gameObject.layer == 12)
        //{
        //    health--;
        //    if(health <= 0 || (weakPoint != null && Vector3.Distance(collision.contacts[0].point, weakPoint.position) < WeakPointRadius))
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }
}
