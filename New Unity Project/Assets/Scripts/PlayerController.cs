using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float reload_time_shortrange;
    public float reload_time_longrange;
    public float reload_time_dash;
    public float footstep_speed = 2;
    public float time_since_footstep = 0;
    public float time_since_fire;
    public Text score_reg;
    private int score;
    public int keys;
    public ParticleSystem dust;
    public ParticleSystem spatter;

    private Rigidbody2D rigidbody;
    private AudioSource footstep;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
        score = 0;
        keys = 0;
        reload_time_longrange = 1;
        time_since_fire = reload_time_longrange+1;
    }

    // Update is called once per frame
    void Update()
    {
        int h = (int)Input.GetAxis("Horizontal");
        int v = (int)Input.GetAxis("Vertical");
        bool fire = Input.GetKey("space");

        if (fire && time_since_fire > reload_time_longrange)
        {
            time_since_fire = 0;
            animator.SetBool("fire", true);
        } else {
            time_since_fire += Time.deltaTime;
            if (time_since_fire > 0.3) { 
                animator.SetBool("fire", false); }
        }

        animator.SetInteger("horizontal", (int)h);
        animator.SetInteger("vertical", (int)v);

        if (h == 0 && v == 0)
        {
            time_since_footstep = 0;

            dust.Play();

        } else {
            transform.position = (Vector2)transform.position + (speed * Time.deltaTime * new Vector2(h, v).normalized);
            if (time_since_footstep==0) { footstep.Play(); }
            time_since_footstep += Time.deltaTime;
            if (time_since_footstep>=footstep_speed) { footstep.Play(); time_since_footstep = 0; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
            spatter.transform.position = other.gameObject.transform.position;
            spatter.Play();
            other.gameObject.SetActive(false);
            score += 1;
            print(score);
            SetScore();
        } else if (other.gameObject.CompareTag("key")) {
            keys += 1;
            other.gameObject.SetActive(false);
        }
    }

    private void SetScore()
    {
        score_reg.text = score.ToString();
    }

}
