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
    public float time_between_footstep2 = 0;
    public float time_since_fire;
    public Text score_reg;
    private int score;
    public int keys;
    public Text keys_reg;
    public float regen_time;
    public float regen_amount;

    public float time_with_goblin = 0;
    public float goblin_attack_start;
    public float goblin_attack_end;
    public float goblin_attack_strength;
    public float health = 1;
    bool with_goblin = false;

    public float attack_timer = 0;
    public float attack_time_execute;
    public bool attack = false;
    public Animator healthtext;
    public Animator healthbarcolor;
    public Transform healthbar;

    public ParticleSystem dust;
    public ParticleSystem spatter;
    public AudioSource splat;

    Rigidbody2D rigidbody;
    private AudioSource footstep;
    private Animator animator;
    public bool regen;

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
        regen = true;
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
            if (!with_goblin)
            {
                regen = true;
                time_since_footstep = 0;
                time_between_footstep += Time.deltaTime;
                time_between_footstep2 += Time.deltaTime;
                if (time_between_footstep > regen_time && health < 1 && regen)
                {
                    if (health < 1 - regen_amount)
                    {
                        health += regen_amount;
                    }
                    else { health = 1; }
                }
            }
            dust.Play();

        } else {
            regen = false;
            time_between_footstep = 0;
            time_between_footstep2 = 0;
            transform.position = (Vector2)transform.position + (speed * Time.deltaTime * new Vector2(h, v).normalized);
            if (time_since_footstep==0) { footstep.Play(); }
            time_since_footstep += Time.deltaTime;
            if (time_since_footstep>=footstep_speed) { footstep.Play(); time_since_footstep = 0; }
        }
        healthtext.SetFloat("health", health);
        healthbarcolor.SetFloat("health", health);
        healthbar.transform.localScale = new Vector3(15000 * health, 1200);

        if (health <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
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
                    with_goblin = false;
                }
            }
        }
        else if (other.gameObject.CompareTag("npc1"))
        {
            if (Input.GetKey("e") && !with_goblin)
            {
                FindObjectOfType<DialogueManager>().StartDialogue();
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
            with_goblin = false;
        } else if (other.gameObject.CompareTag("npc1"))
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            keys += 1;
            other.gameObject.SetActive(false);
            SetKeys();
        } else if (other.gameObject.CompareTag("goblin"))
        {
            regen = false;
            with_goblin = true;
        }
    }

    private void SetScore()
    {
        score_reg.text = score.ToString();
    }

    private void SetKeys()
    {
        keys_reg.text = keys.ToString();
    }

}
