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

    private Rigidbody2D rigidbody;
    private AudioSource footstep;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float xpos = transform.position.x + h * speed * Time.deltaTime;
        float ypos = transform.position.y + v * speed * Time.deltaTime;
        transform.position = new Vector2(xpos, ypos);
        if (Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            if (time_since_footstep==0) { footstep.Play(); }
            time_since_footstep += Time.deltaTime;
            if (time_since_footstep>=footstep_speed) { footstep.Play(); time_since_footstep = 0; }
        } else { time_since_footstep = 0; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            print(score);
            setScore();
        }
    }

    private void setScore()
    {
        score_reg.text = score.ToString();
    }
}
