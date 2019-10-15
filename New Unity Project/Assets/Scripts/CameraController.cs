using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    private Vector3 offset;
    public GameObject player;


    // Start is called before the first frame update
    void Start () {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + offset;
    }

}