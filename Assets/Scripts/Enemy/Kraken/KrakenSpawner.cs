using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject headPrefab;

    [SerializeField]
    private float headDistance;

    [SerializeField]
    private GameObject tentaclePrefab;

    [SerializeField]
    private float tentacleDistance;

    [SerializeField]
    Vector2 depthOverTime;

    [SerializeField]
    private Vector2 headDepthOverTime;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private float headSpawnRate;

    private bool isSpawning = false;

	// Use this for initialization
	void Start () {

        StartCoroutine(Loop());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartSpawning() {
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }

    private IEnumerator Loop() {

        float timer = spawnRate;
        float headTimer = 0;
        while (true) {

            if (isSpawning) {

                timer += Time.deltaTime;
                if (timer > spawnRate) {
                    Spawn(tentaclePrefab, tentacleDistance, depthOverTime);
                    timer = 0;
                }

                headTimer += Time.deltaTime;
                if (headTimer > headSpawnRate) {
                    Spawn(headPrefab, headDistance, headDepthOverTime);
                    headTimer = 0;
                }

            }

            yield return null;

        }

    }

    private void Spawn(GameObject prefab, float distance, Vector2 dot) {

        GameObject obj = Instantiate(prefab, this.transform);
        Transform xform = obj.transform;

        xform.eulerAngles = Vector3.up * Random.Range(0f, 360f);
        xform.localPosition = xform.forward * distance;

        StartCoroutine(SpawnCR(obj, dot));

    }

    private IEnumerator SpawnCR(GameObject obj, Vector2 dot) {

        float currSpawnTime = 0;
        while (currSpawnTime < spawnTime) {

            currSpawnTime += Time.deltaTime;
            float progress = currSpawnTime / spawnTime;

            Vector3 pos = obj.transform.localPosition;
            pos.y = Mathf.Lerp(dot.x, dot.y, progress);
            obj.transform.localPosition = pos;

            yield return null;

        }

    }

}
