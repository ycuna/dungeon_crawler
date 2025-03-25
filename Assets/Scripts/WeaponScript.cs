using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponScript : MonoBehaviour
{
    private bool swing = false;
    int degree = 0;
    private float weaponY = -0.4f;
    private float weaponX = 0.3f;

    UnityEngine.Vector3 pos;
    public GameObject player;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (swing)
        {
            degree  -= 7;
            if(degree  < -65)
            {
                degree = 0;
                swing = false;
                GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.eulerAngles = UnityEngine.Vector3.forward * degree;
        }
    }

    void Attack()
    {
        if(player.GetComponent<PlayerScript>().turnedLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = -0.3f;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            weaponX = 0.3f;
        }
        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;
        swing = true;
    }
}
