using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalDeathBehavior : MonoBehaviour {

    public GameObject addPrefab;

    private void OnDestroy()
    {
        GameObject add = ObjectPool.GetObj(addPrefab);

        if (add != null)
        {
            add.transform.position = this.transform.position;
            add.SetActive(true);
        }
    }
}
