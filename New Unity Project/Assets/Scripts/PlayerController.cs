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
    public Text score_reg;
    private int score;
    public int keys;

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
    }

    // Update is called once per frame
    void Update()
    {
        int h = (int)Input.GetAxis("Horizontal");
        int v = (int)Input.GetAxis("Vertical");

        animator.SetInteger("horizontal", (int)h);
        animator.SetInteger("vertical", (int)v);

        transform.position = (Vector2)transform.position + (speed * Time.deltaTime * new Vector2(h, v).normalized);
        if (h == 0 && v == 0)
        {
            time_since_footstep = 0;
        } else {
            if (time_since_footstep==0) { footstep.Play(); }
            time_since_footstep += Time.deltaTime;
            if (time_since_footstep>=footstep_speed) { footstep.Play(); time_since_footstep = 0; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
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
