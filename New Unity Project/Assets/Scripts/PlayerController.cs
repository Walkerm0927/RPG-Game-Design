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
    public float time_between_footstep = 0;
    public float time_since_fire;
    public Text score_reg;
    private int score;
    public int keys;
    public float regen_time;
    public float regen_amount;

    public float time_with_goblin = 0;
    public float goblin_attack_start;
    public float goblin_attack_end;
    public float goblin_attack_strength;
    public float health = 1;

    public float attack_timer = 0;
    public float attack_time_execute;
    public bool attack = false;

    public ParticleSystem dust;
    public ParticleSystem spatter;
    public AudioSource splat;

    Rigidbody2D rigidbody;
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
            time_between_footstep += Time.deltaTime;
            if (time_between_footstep > regen_time && health < 1) { health += regen_amount; time_between_footstep = 0; }
            dust.Play();

        } else {
            time_between_footstep = 0;
            transform.position = (Vector2)transform.position + (speed * Time.deltaTime * new Vector2(h, v).normalized);
            if (time_since_footstep==0) { footstep.Play(); }
            time_since_footstep += Time.deltaTime;
            if (time_since_footstep>=footstep_speed) { footstep.Play(); time_since_footstep = 0; }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
            time_with_goblin += Time.deltaTime;
            if (time_with_goblin >= goblin_attack_end)
            {
                health -= goblin_attack_strength;
                time_with_goblin = 0;
            }
            if (Input.GetKey("space"))
            {
                attack = true;
            }
            if (attack == true)
            {
                attack_timer += Time.deltaTime;
                if (attack_timer >= attack_time_execute)
                {
                    spatter.transform.position = other.gameObject.transform.position;
                    spatter.Play();
                    splat.Play();
                    other.gameObject.SetActive(false);
                    score += 1;
                    print(score);
                    SetScore();
                    attack = false;
                    attack_timer = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
            attack = false;
            attack_timer = 0;
            time_with_goblin = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            keys += 1;
            other.gameObject.SetActive(false);
        }
    }

    private void SetScore()
    {
        score_reg.text = score.ToString();
    }

}
