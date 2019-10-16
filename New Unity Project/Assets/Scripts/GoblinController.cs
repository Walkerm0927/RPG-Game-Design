using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public float speed;
    public float turntime;
    public int hor;
    public int ver;
    private int oldhor;
    private int oldver;
    public float time_since_turn;

    private Rigidbody2D rigidbody;
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
                animator.SetInteger("horizontal", hor);
                animator.SetInteger("vertical", ver);
            } else
            {
                oldhor = hor;
                oldver = ver;
                hor = 0;
                ver = 0;
                time_since_turn = 0;
                animator.SetInteger("horizontal", hor);
                animator.SetInteger("vertical", ver);
            }
        }
        float newx = transform.position.x + speed * Time.deltaTime * hor;
        float newy = transform.position.y + speed * Time.deltaTime * ver;

        transform.position = new Vector2(newx, newy);
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
}
