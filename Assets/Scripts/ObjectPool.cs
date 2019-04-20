using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private static Dictionary<GameObject, ObjectPool> poolDirectory;
    static ObjectPool()
    {
        poolDirectory = new Dictionary<GameObject, ObjectPool>();
    }

    public GameObject Prefab;
    public int Max;

    public Stack<GameObject> pool;

    // Use this for initialization
    void Awake()
    {
        pool = new Stack<GameObject>();


        for (int i = 0; i < Max; i++)
        {
            pool.Push(Instantiate(Prefab));
            pool.Peek().transform.SetParent(transform);
            pool.Peek().SetActive(false);
        }
        poolDirectory[Prefab] = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameObject GetObj(GameObject prefab)
    {
        ObjectPool pool = poolDirectory[prefab];
        if (pool.pool.Count == 0)
        {
            return null;
        }
        return poolDirectory[prefab].pool.Pop();
    }

    public static void Release(GameObject obj)
    {
        obj.SetActive(false);
        ObjectPool pool = obj.GetComponentInParent<ObjectPool>();
        if (pool)
        {
            pool.pool.Push(obj);
        }
    }
}
