﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{

    public int Speed = 1;
    public Transform point_1;
    public Transform point_2;
    Rigidbody2D rgb;
    bool OnRight;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.transform.position.x <= point_2.position.x)
        {
            OnRight = true;
        }
        if (gameObject.transform.position.x >= point_1.position.x)
        {
            OnRight = false;
        }

        MakePosition();
    }

    void MakePosition()
    {
        if (OnRight)
        {
            rgb.velocity = new Vector2(Speed, rgb.velocity.y);
        }
        else
        {
            rgb.velocity = new Vector2(-Speed, rgb.velocity.y);
        }
    }

}