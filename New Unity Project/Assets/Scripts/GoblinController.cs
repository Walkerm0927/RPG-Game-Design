using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public float speed;
    public float turntime;
    public int hor = 0;
    public int ver = 0;
    public float h;
    public float v;
    private int oldhor;
    private int oldver;
    public float time_since_turn;
    private bool seen = false;
    public Transform player;
    public float playerlocx;
    public float playerlocy;
    public float playerdist;
    public Vector2 direction;

    Rigidbody2D rigidbody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ver = -1;
        hor = 0;
        animator = this.GetComponent<Animator>();
        animator.SetInteger("horizontal", hor);
        animator.SetInteger("vertical", ver);
    }

    // Update is called once per frame
    void Update()
    {
        if (seen == false)
        {
            time_since_turn += Time.deltaTime;
            if (time_since_turn >= turntime)
            {
                if (hor == 0 && ver == 0)
                {
                    int h = Turnlefth(oldhor, oldver);
                    int v = Turnleftv(oldhor, oldver);
                    hor = h;
                    ver = v;
                    time_since_turn = 0;
                }
                else
                {
                    oldhor = hor;
                    oldver = ver;
                    hor = 0;
                    ver = 0;
                    time_since_turn = 0;
                }
            }

        } else
        {
            playerlocx = player.position.x - transform.position.x;
            playerlocy = player.position.y - transform.position.y;
            if (playerlocx > 0.1) { hor = 1; }
            else if (playerlocx < -0.1) { hor = -1; } else { hor = 0; }
            if (playerlocy > 0) { ver = 1; }
            else if (playerlocy < 0) { ver = -1; } else { ver = 0; }
        }
        animator.SetInteger("horizontal", hor);
        animator.SetInteger("vertical", ver);

        direction = new Vector2(hor, ver).normalized;
        
        float newx = transform.position.x + speed * Time.deltaTime * hor;
        float newy = transform.position.y + speed * Time.deltaTime * ver;
        transform.position = new Vector2(transform.position.x,transform.position.y) + speed*Time.deltaTime*direction;
    }

    int Turnlefth(int h,int v)
    {
        int ret;
        if (h != 0)
        {
            ret = 0;
        } else
        {
            if (v<0) { ret = 1; } else { ret = -1; }
        }
        return ret;
    }

    int Turnleftv(int h, int v)
    {
        int ret;
        if (v != 0)
        {
            ret = 0;
        }
        else
        {
            if (h < 0) { ret = -1; } else { ret = 1; }
        }
        return ret;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            seen = true;
            hor = 0;
            ver = 0;
        }
    }
}
