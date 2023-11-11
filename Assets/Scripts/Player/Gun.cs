using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    
    Vector3 Direction;
    [SerializeField] LayerMask Enemy;
    [SerializeField] LayerMask Player;
    void Update()
    {
       //makes our gun point towards the mouse position
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePosition - gun.transform.position;
        gun.transform.up = Direction;


        if(Input.GetButtonDown("Fire1")){
           
           fire(gun.transform.position, Direction);

           
        }

        


    }

    public void fire(Vector3 OriginPos, Vector3 ShootDir){
        
        RaycastHit2D HitInfo = Physics2D.Raycast(OriginPos, ShootDir, ~Player);
       
        
        if(HitInfo.collider != null){
            if(HitInfo){
                    Debug.Log(HitInfo.transform.name);
                    if(HitInfo.collider.gameObject.layer == Enemy){
                        HitInfo.collider.GetComponent<Enemy>().Health -= 3;
                    }
            }
        }

    }
   

  
    


}
