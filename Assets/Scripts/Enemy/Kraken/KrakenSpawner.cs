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
    private List<AngleRange> blockedRanges = new List<AngleRange>();

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

            if (isSpawning && FirstPerson.GUN_AQUIRED) {

                timer += Time.deltaTime;
                if (timer > spawnRate) {
                    AngleRange ar = GetSpawnLocation(30f);
                    if (ar != null) {
                        Spawn(tentaclePrefab, tentacleDistance, depthOverTime, ar, 10f);
                    }
                    timer = 0;
                }

                headTimer += Time.deltaTime;
                if (headTimer > headSpawnRate) {
                    AngleRange ar = GetSpawnLocation(45f);
                    if (ar != null) {
                        Spawn(headPrefab, headDistance, headDepthOverTime, ar, 20f);
                    }
                    headTimer = 0;
                }

            }

            yield return null;

        }

    }

    private AngleRange GetSpawnLocation(float width) {

        for (int i = 0; i < 100; i++) {

            float center = Random.Range(0f, 360f);
            AngleRange potentialAR = new AngleRange(center, width);

            bool valid = true;
            foreach (AngleRange ar in blockedRanges) {
                if (potentialAR.Intersects(ar)) {
                    valid = false;
                    break;
                }
            }

            if (valid) {
                return potentialAR;
            }

        }

        return null;

    }

    private void Spawn(GameObject prefab, float distance, Vector2 dot, AngleRange angleRange, float angleRangeLifespan) {

        GameObject obj = Instantiate(prefab, this.transform);
        Transform xform = obj.transform;

        xform.eulerAngles = Vector3.up * Random.Range(0f, 360f);
        xform.localPosition = xform.forward * distance;

        if (angleRange != null) {
            blockedRanges.Add(angleRange);
        }

        StartCoroutine(SpawnCR(obj, dot, angleRange, angleRangeLifespan));

    }

    private IEnumerator SpawnCR(GameObject obj, Vector2 dot, AngleRange angleRange, float angleRangeLifespan) {

        float currSpawnTime = 0;
        while (currSpawnTime < spawnTime) {

            currSpawnTime += Time.deltaTime;
            float progress = currSpawnTime / spawnTime;

            Vector3 pos = obj.transform.localPosition;
            pos.y = Mathf.Lerp(dot.x, dot.y, progress);
            obj.transform.localPosition = pos;

            yield return null;

        }
        
        if (angleRange != null) {
            yield return new WaitForSeconds(angleRangeLifespan);
            blockedRanges.Remove(angleRange);
        }

    }

    private class AngleRange {
        public float start;
        public float end;
        public AngleRange(float center, float width) {
            start = center - width / 2f;
            end = center + width / 2f;
        }
        public bool Intersects(AngleRange other) {
            // Normal check
            if (end > other.start && start < other.end) {
                return true;
            }
            return false;
        }
    }

}
