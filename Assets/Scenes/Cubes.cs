﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y==0.5f)
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}