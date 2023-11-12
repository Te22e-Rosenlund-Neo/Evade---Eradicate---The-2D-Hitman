
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] Transform Gun;
    [SerializeField] SpriteRenderer SR;
    Vector2 Direction;
    public bool ShowBullet;
    void Start()
    {
        



    }

    void Update()
    {
       

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = MousePosition - Gun.transform.position;
        transform.right = Direction;


         transform.position = (Gun.position + MousePosition)/2;
         transform.localScale = new Vector3(Vector2.Distance(Gun.position, MousePosition)*9,1.5f, 1);
 
         if(ShowBullet == true){
             SR.enabled = true;
         }else{
             SR.enabled = false;
         }

    }
}
