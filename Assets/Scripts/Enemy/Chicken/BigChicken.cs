using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChicken : MonoBehaviour {
    private bool gameEnd = false;

    public ChickenCore core;
    public float healthScale;
    public EyeBallLaser eye;
    public float baseSpeed;
    public float baseAgility;
    public float chaseTime;
    public float preChargeTime;
    public float chargeTime;
    public float restTime;

    private LandAi ai;
    private int phase;
    private float timer;
    private Animator anim;

	// Use this for initialization
	void Start () {
        core.gameObject.SetActive(false);
        core.Connect(this);
        ai = GetComponent<LandAi>();
        phase = 0;
        ai.Speed = baseSpeed;
        ai.Agility = baseAgility;
        timer = chaseTime;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
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

    }

    private void OnDisable()
    {
        if(gameEnd)
        {
            return;
        }
        core.ActivateCore();
    }

    private void OnApplicationQuit()
    {
        gameEnd = true;
    }
}
