using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpspeed = 5f;
    //setting values
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodycollider;
    BoxCollider2D myFeet;
    //Announce Components
  
    void Start()
    { //Inform  the component included
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodycollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }
     void Update()
    { 
        Run();
        FlipSprite();
        Jump();
    }

    private void Run()
    {
        //Input the Assest horizontal type
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //Speed Code - create  new vector 2 which increases gradually 
        Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidBody.velocity.y);
        //rigid boy = velocity to prevent animation glitch
        myRigidBody.velocity = playerVelocity;
        // [TRANSITION STATE ]its true if we're moving false if we stand still
        bool Playerhashorizontalspeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", Playerhashorizontalspeed);


    }
    private void FlipSprite()
    {
        //its true if we go positive axis false if negative axis
        bool Playerhashorizontalspeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (Playerhashorizontalspeed)
        {
            //flip - turn x=1 to x=-1
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    private void Jump()
    {   
        //if my feet doesn't touch the tile layer , fall off
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        //if press space
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            //then new vetor y keep being added
            Vector2 jumpvelocity = new Vector2(0f, jumpspeed);
            myRigidBody.velocity += jumpvelocity;
        }
    }
}
  