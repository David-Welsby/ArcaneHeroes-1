﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;



    

    public class AI : gameEntity
    {

    private static AI _instance;

    public static AI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AI();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public enum AIState
        {
            idle,
            chase,
            fire
        }

        public int currentState;
        public GameObject player;
        public GameObject attack;
        public Transform attackSpawn;
        public GameObject spawn;
        float timer = 2.0f;

    public AIStateMachine<AI> stateMachine { get; set; }

        new private void Start()
        {
            stateMachine = new AIStateMachine<AI>(this);
            stateMachine.ChangeState(idleState.Instance);
            rigid = gameObject.GetComponent<Rigidbody2D>();
            whatIsGround = LayerMask.GetMask("Default");

            
            spawn.transform.position = transform.position;

        }

        private void Update()
        {
        if (player)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

            if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) <= 10 && grounded == true)
            {
                currentState = (int)AIState.chase;

                moveLeft(movementSpeed);

                facingRight = false;



                if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) <= 5)
                {
                    currentState = (int)AIState.fire;

                    if (timer <= 0)
                    {
                        attack.SetActive(true);
                        fire(attack, attackSpawn, attackSpawn);
                        timer = 2.0f;
                    }


                }

            }
            else
            {
                currentState = (int)AIState.idle;
            }
            stateMachine.Update();
        }

        timer -= Time.deltaTime;
        }
    }
