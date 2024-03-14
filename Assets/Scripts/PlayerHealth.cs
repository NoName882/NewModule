using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 243;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            DestroyObject(gameObject);
        }
    }

   
}
