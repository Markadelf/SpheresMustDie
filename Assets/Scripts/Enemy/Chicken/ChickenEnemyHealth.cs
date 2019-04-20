using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEnemyHealth : MonoBehaviour
{
    public List<ChickenWeakPoint> WeakPoints;
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
            gameObject.SetActive(false);
            BossDeathTracker track = GetComponent<BossDeathTracker>();
            if (track)
            {
                track.MarkDead();
            }
        }
    }

    void OnEnable()
    {
        for (int i = 0; i < WeakPoints.Count; i++)
        {
            WeakPoints[i].gameObject.SetActive(true);
        }
    }


}
