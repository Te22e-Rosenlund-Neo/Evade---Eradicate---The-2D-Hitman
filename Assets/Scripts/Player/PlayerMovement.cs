using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    GameObject WallChecker;
    
    [SerializeField] 
    LayerMask GroundLayer;

    [SerializeField] 
    LayerMask WallLayer;


    bool MayJump = true;

    public bool IsGrounded;
    public bool OnWall;

    Vector2 GroundCheckerSize = new(0.3f,0.1f);
    Vector2 WallCheckerSize = new(0.1f, 0.3f);

    public float JumpForce = 1000f;

    float WallSlideSpeed = -1;
    bool WallSliding;

    bool WallJumping;
    float WallJumpingTime = 0.005f;
    public float WallJumpForceX = 8f;
    public float WallJumpForceY = 16f;
    
    public bool sliding;

    float slidingDelay = 0.5f;

    void Update()   
        {   
            
            
            //rotates the player
            if(Input.GetAxisRaw("Horizontal") != 0){
            GetComponent<Transform>().rotation = Quaternion.LookRotation(Vector3.forward * Input.GetAxisRaw("Horizontal"), Vector3.up);
            }

             IsGrounded = Physics2D.OverlapBox(GroundChecker.transform.position, GroundCheckerSize, 0, GroundLayer);
             OnWall = Physics2D.OverlapBox(WallChecker.transform.position, WallCheckerSize, 0, WallLayer);
            


            //moves player on Y axis (jump)
           if(Input.GetAxisRaw("Jump") > 0 && IsGrounded == true  && MayJump == true){
                Vector2 Jump = Vector2.up * JumpForce;
                rb.AddForce(Jump);

                MayJump = false;
           }

            if(Input.GetAxisRaw("Jump") == 0){
                MayJump = true;
            }

          
                //allows player to slide on the wall
                 if(IsGrounded == false && OnWall == true){
                    WallAbilities();
                 } 
            
                //Controls the wall jumping 
            if(WallJumping == true){

                 rb.velocity = new Vector2(WallJumpForceX * -Input.GetAxisRaw("Horizontal"), WallJumpForceY);

                 
            }

                // player slide invoker
            if(IsGrounded == true && Input.GetKeyDown(KeyCode.LeftShift) == true){
                Slide();
            }else{
                sliding = false;
            }
        slidingDelay -= Time.deltaTime;

    }
        //player slider function
         private void Slide(){
            if(slidingDelay < 0){
            sliding = true;
            rb.AddForce(new Vector2(500*Input.GetAxisRaw("Horizontal"), 0));
            slidingDelay = 0.5f;
            }

         }

        private void WallAbilities(){

            //WallSlide
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0){
                
                rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, WallSlideSpeed, float.MaxValue));
                //wallJump
                if(Input.GetAxisRaw("Jump") > 0){
                    WallJumping = true;
                    Invoke("SetWallJumpingFalse", WallJumpingTime);
                }
            }




        }

        void SetWallJumpingFalse(){
            WallJumping = false;
        }


   
         private void FixedUpdate() {
            
            //moves player on X axis
            float PlayerMove = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
            PlayerVelocity(PlayerMove,0);
        }
      


    //controlls the player movement when needing translate
    void PlayerVelocity(float X, float Y){
        Vector2 Move = new(X,Y);
        transform.Translate(Move, Space.World);
    }
        //draws lines where the hitboxes are for the checkers to the dev
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GroundChecker.transform.position, GroundCheckerSize);
        Gizmos.DrawWireCube(WallChecker.transform.position, WallCheckerSize);
    }
}
