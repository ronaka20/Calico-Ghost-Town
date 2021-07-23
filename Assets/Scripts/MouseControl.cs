using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour

{    public float mouse_sensitivity =10f;
     public Transform player ;
     float rotateinx=0f;

   void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouse_sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouse_sensitivity*Time.deltaTime;
        player.Rotate(Vector3.up*mouseX);
        rotateinx -= mouseY;
        rotateinx= Mathf.Clamp(rotateinx,-90f,90f);
        transform.localRotation = Quaternion.Euler(rotateinx,0f,0f);
        player.Rotate(Vector3.up*mouseX);
    }
}
