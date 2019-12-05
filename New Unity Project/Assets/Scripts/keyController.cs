using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class keyController : MonoBehaviour
{
    public float rotationspeed;
    public float z;
    public GameObject player;
    public GameObject key;
    public bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        z = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("goblin").Length==0 && !active)
        {
            key.SetActive(true);
            active = true;
        }

        if (active) { transform.Rotate(0, 0, rotationspeed * Time.deltaTime); }

    }
}
