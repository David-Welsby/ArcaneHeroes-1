﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEntity : MonoBehaviour {

    public float movementSpeed = 50;
    public float jumpForce = 50;

    public GameObject[] Spells;
    public GameObject staff;
    public GameObject staff1;

    public static int spellSelect;
    public int showSpell;

    public bool grounded = false;

    public Transform groundCheck;
    protected float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    protected float animationTime = 0.4f;
    protected Rigidbody2D rigid;

    public bool facingRight;

    public Animator anim;

    protected float coolDown;

    public GameObject collision;


    // Use this for initialization
    protected void Start ()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

   public IEnumerator ExecuteSpellAfterTime(GameObject projectile, float time, Transform transform1, Transform transform2)
    {
        yield return new WaitForSeconds(time);

        fire(projectile, transform1.transform, transform2.transform);
    }
    protected void moveLeft(float moveSpeed)
    {
        rigid.AddForce(new Vector2(-moveSpeed, 0));
    }
    protected void moveRight(float moveSpeed)
    {
        rigid.AddForce(new Vector2(moveSpeed, 0));
    }
    protected void jump(float jumpingForce)
    {
        rigid.AddForce(new Vector2(0, jumpingForce));
    }

    public void fire(GameObject spell, Transform pos, Transform pos1)
    {
        if (facingRight == true)
        {
            Instantiate(spell, pos.position, pos.rotation);
        }
        else
        {
            Instantiate(spell, pos1.position, pos.rotation);
        }
    }

    protected void flip(float xOffset)
    {
        if (facingRight == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            collision.transform.localPosition = new Vector3(xOffset, 0, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            collision.transform.localPosition = new Vector3(0, 0, 0);

        }
    }

   

}
