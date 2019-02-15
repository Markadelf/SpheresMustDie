using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public List<Transform> Muzzles;
    public GameObject bulletPrefab;
    public float CoolDown;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void TryShoot()
    {
        if (timer <= 0)
        {
            for (int i = 0; i < Muzzles.Count; i++)
            {
                if (Muzzles[i] == null)
                {
                    continue;
                }
                GameObject bullet = ObjectPool.GetObj(bulletPrefab);
                if (bullet != null)
                {
                    bullet.transform.position = Muzzles[i].position;
                    bullet.transform.forward = Muzzles[i].forward;
                    bullet.SetActive(true);
                }
            }
            timer = CoolDown;
        }
    }
}
