using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
     public float health=20f;
    
    public void Damage(float amount)
    {
        health-=amount;
        if(health==0)
        {
            destroy();
        }
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
