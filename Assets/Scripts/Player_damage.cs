using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_damage : MonoBehaviour
{
   public float maxHealth = 100f ;
    public float currentHealth ; 

    public slider_health healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    public void takedamage(float power){
        currentHealth-= power;
        healthbar.setHealth(currentHealth);
    }
     private void OnControllerColliderHit(ControllerColliderHit hit)
     {
         
        if(hit.gameObject.tag =="Enemy"){
           takedamage(1f);
            Debug.Log("hit by zombie");
            

        }
       if(currentHealth<=0){
            Destroy(gameObject);
        
     }


        
    }
}
