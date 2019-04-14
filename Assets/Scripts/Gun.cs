using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public List<Transform> Muzzles;
    public GameObject bulletPrefab;
    public float CoolDown;
    public bool AutoFire;
    public bool ApplyVelocity;

    private Vector3 lastPos;
    private float timer;

    private void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(AutoFire)
        {
            TryShoot();
        }
    }

    private void LateUpdate()
    {
        lastPos = transform.position;
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
                    Bullet bull = bullet.GetComponent<Bullet>();
                    if (bull)
                    {
                        if (ApplyVelocity)
                        {
                            bull.Fire((transform.position - lastPos) / Time.deltaTime);
                        }
                        else
                        {
                            bull.Fire(Vector3.zero);
                        }
                    }
                }
            }
            timer = CoolDown;
        }
    }
}
