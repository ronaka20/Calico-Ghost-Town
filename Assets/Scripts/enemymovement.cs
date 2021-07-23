using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public float fov = 120f;
    public Transform target; 
    public bool isVisible;
    public bool playerinVision;
    public float awakedistance = 200f; 
    private Vector3 wanderPoint;
    public bool aware ; 
    public float wanderRadius=7f;
    public NavMeshAgent navigation;
    private Collider[] ragdollColliders;
    private Rigidbody[] ragdollRigidbodies;

    /*public void Start()
    {
        ragdollColliders=GetComponentsInChildrens<Collider>();
        ragdollRigidbodies=GetComponentsInChildrens<Rigidbody>();
        foreach (Collider col in ragdollColliders)
        {
            col.enabled=false;
        }
        foreach(Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic=true;
        }
    }*/

    private void Update()
    {
        drawRay();
        float playerDistance = Vector3.Distance(target.position, transform.position );

        Vector3 playerDirection = target.position - transform.position ;  

        float playerAngle = Vector3.Angle(transform.forward,playerDirection);

        if(playerAngle <= fov/2f){
            isVisible = true ; 
           // Debug.Log("isVisible");
        }
        else 
        {
            isVisible = false; 
        }
        if(isVisible == true && playerDistance <= awakedistance && playerinVision==true){
            OnAware() ; 
        }
        if(aware==true){
            navigation.SetDestination(target.position);
        }
        else
        {
            Wander();
        }
    }

    public void OnAware()
    {
        aware=true;
    }

    void drawRay()
    {
        Vector3 playerDirection = target.position - transform.position ;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,playerDirection, out hit))
        {
            if(hit.transform.tag=="Player")
            {
                playerinVision=true;
            }
            else
            {
                playerinVision=false;
            }
        }
    }
    public void Wander()
        {
            if(Vector3.Distance(transform.position,wanderPoint)<2f)
            {
                wanderPoint=RandomWanderPoint();
            }
            else
            {
                navigation.SetDestination(wanderPoint);
            }
        }

        public Vector3 RandomWanderPoint()
        {
            Vector3 randomPoint= (Random.insideUnitSphere * wanderRadius)+ transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randomPoint,out navHit,wanderRadius,-1);
            return new Vector3(navHit.position.x,transform.position.y,navHit.position.z);
        }
}