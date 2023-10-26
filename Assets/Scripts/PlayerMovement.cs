using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float MoveSpeed = 7f;
    [SerializeField]
    Rigidbody2D rb;

    float JumpForce = 100;

    void Update()   
        {   
            //moves player on X axis
            PlayerVelocity(Input.GetAxisRaw("Horizontal") * MoveSpeed, 0);

            //moves player on Y axis (jump)
           if(Input.GetAxisRaw("Jump") > 0){
                Vector2 Jump = Vector2.up * JumpForce;
                rb.AddForce(Jump);

           }

    }
   
        



    void PlayerVelocity(float X, float Y){
        rb.velocity = new Vector2(X,Y);
    }


    
}
