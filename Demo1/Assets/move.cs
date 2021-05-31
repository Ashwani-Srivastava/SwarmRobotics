using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    double i=0;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per timeunit
    void FixedUpdate()
    {
        i++;
        tr.Rotate(new Vector3(0.0f, 1.0f, 0.0f),10);
    }
}
