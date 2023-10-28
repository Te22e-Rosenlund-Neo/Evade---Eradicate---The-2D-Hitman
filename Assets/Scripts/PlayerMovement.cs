using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float MoveSpeed = 6f;
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    GameObject GroundChecker;

    [SerializeField] 
    LayerMask GroundLayer;



    bool MayJump = true;

    public bool IsGrounded;

    Vector2 Size = new(0.3f,0.1f);

    public float JumpForce = 1000f;
   

    void Update()   
        {   
            //moves player on X axis
            float PlayerMove = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
            PlayerVelocity(PlayerMove,0);

            if(Input.GetAxisRaw("Horizontal") != 0){
            GetComponent<Transform>().rotation = Quaternion.LookRotation(Vector3.forward * Input.GetAxisRaw("Horizontal"), Vector3.up);
            }





             IsGrounded = Physics2D.OverlapBox(GroundChecker.transform.position, Size, 0, GroundLayer);

            //moves player on Y axis (jump)
           if(Input.GetAxisRaw("Jump") > 0 && IsGrounded == true && MayJump == true){
                Vector2 Jump = Vector2.up * JumpForce;
                rb.AddForce(Jump);

                MayJump = false;
           }

            if(Input.GetAxisRaw("Jump") == 0){
                MayJump = true;
            }
    }
   
        



    void PlayerVelocity(float X, float Y){
        Vector2 Move = new(X,Y);
        transform.Translate(Move, Space.World);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GroundChecker.transform.position, Size);


    }
}
