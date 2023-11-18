
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] Transform Gun;
    [SerializeField] SpriteRenderer Sr;
    Vector2 Direction;
    public bool ShowBullet;

    void Update()
    {
       //Bullet faces mousepos from player
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePosition - Gun.transform.position;
        transform.right = Direction;

        //Puts the bullet inbetween the player and the mousepos
         transform.position = (Gun.position + MousePosition)/2;

        // makes the bullet stretch from player to mousepos
         transform.localScale = new Vector3(Vector2.Distance(Gun.position, MousePosition)*9,1.5f, 1);
 
        //code that is referenced in gun.cs (shows/hides bullet trail)
         if(ShowBullet == true){
             Sr.enabled = true;
         }else{
             Sr.enabled = false;
         }

    }
}
