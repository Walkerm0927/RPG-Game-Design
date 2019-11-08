using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    public float rotationspeed;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationspeed* Time.deltaTime);
    }
}
