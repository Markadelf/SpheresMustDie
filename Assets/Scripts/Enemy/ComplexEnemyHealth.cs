using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexEnemyHealth : MonoBehaviour
{
    public List<WeakPoint> WeakPoints;
    private int count;

    // Use this for initialization
    void Start()
    {
        count = WeakPoints.Count;
        for (int i = 0; i < WeakPoints.Count; i++)
        {
            WeakPoints[i].Claim(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NotifyDeath()
    {
        count--;
        if(count <= 0)
        {
            Destroy(gameObject);
        }
    }


}
