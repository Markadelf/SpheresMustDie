using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChicken : MonoBehaviour {
    private bool gameEnd = false;

    public GameObject core;
    private ChickenCore _core;
    public EyeBallLaser eye;
    public float baseSpeed;
    public float baseAgility;
    public float chaseTime;
    public float preChargeTime;
    public float chargeTime;
    public float restTime;

    public int MaxHealth;
    public float MinSize;
    public float MaxSize;

    private LandAi ai;
    private int phase;
    private float timer;
    private Animator anim;

	// Use this for initialization
	void Start () {
        core = Instantiate(core);
        core.SetActive(false);
        _core = core.GetComponent<ChickenCore>();
        _core.Connect(this);

        ai = GetComponent<LandAi>();
        phase = 0;
        ai.Speed = baseSpeed;
        ai.Agility = baseAgility;
        timer = chaseTime;

        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && ai != null)
        {
            phase = (phase + 1) % 4;
            switch (phase)
            {
                case 0:
                    ai.Speed = baseSpeed;
                    ai.Agility = baseAgility;
                    timer = chaseTime;
                    anim.Play("ChickenWalk");
                    break;
                case 1:
                    ai.Speed = 0;
                    ai.Agility = baseAgility * 1.5f;
                    timer = preChargeTime;
                    break;
                case 2:
                    ai.Speed = baseSpeed * 1.5f;
                    ai.Agility = 0;
                    timer = chargeTime;
                    break;
                case 3:
                    ai.Speed = 0;
                    ai.Agility = 0;
                    timer = restTime;
                    anim.Play("Idle");
                    break;
                default:
                    break;
            }
        }


    }

    public void ReactivateChicken(int health)
    {
        Vector3 pos = _core.transform.position;
        pos.y = transform.position.y;
        transform.position = pos;

        transform.localScale = Vector3.Lerp(new Vector3(MinSize, MinSize, MinSize), new Vector3(MaxSize, MaxSize, MaxSize), (health * 1f) / MaxHealth);
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if(gameEnd)
        {
            return;
        }
        _core.ActivateCore();
    }

    private void OnApplicationQuit()
    {
        gameEnd = true;
    }
}
