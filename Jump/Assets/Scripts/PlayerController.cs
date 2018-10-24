using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region private fields

    private Rigidbody rb;

    #endregion


    #region Serializable fields

    [SerializeField]
    private float speed;

    #endregion


    #region Properties 

    private bool isCanWalk { get; set; }
    private bool isTurnedLeft { get; set; }

    #endregion

    #region UnityLifeCycle

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        EventController.jump += Jump;
        EventController.freezeMoving += FreezeMovement;
        EventController.unFreezeMoving += UnFreezeMovement;
        EventController.trampolineJump += TrampolineJump;
        isCanWalk = true;
        isTurnedLeft = false;

    }
	
	void Update ()
    {
        
        PlayerMovement();
	}

    #endregion
    
    
    #region Private Methods

    private void PlayerMovement()
    {
        if (isCanWalk)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.MovePosition(transform.position + Vector3.left * speed);
                isTurnedLeft = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.MovePosition(transform.position + Vector3.right * speed);
                isTurnedLeft = false;
            }
        }
    }
    #endregion



    #region Event Handlers 

    private void Jump()
    {
        // Vector3 velocity = rb.velocity.magnitude;

        if(isTurnedLeft)
        rb.AddForce(new Vector3(-5, 10, 0), ForceMode.Impulse); // 2 variable is need to convert in the field!!

        if(!isTurnedLeft)
            rb.AddForce(new Vector3(5, 10, 0), ForceMode.Impulse); // 2 variable is need to convert in the field!!


        isCanWalk = false;       
    }


    private void TrampolineJump()
    {
        isCanWalk = false;
        rb.velocity = new Vector3(0, 0, 0);


        if(isTurnedLeft)
            rb.AddForce(new Vector3(-1.5f,10, 0), ForceMode.VelocityChange);

        if (!isTurnedLeft)
            rb.AddForce(new Vector3(1.5f, 10, 0), ForceMode.VelocityChange);


        
    }


    private void FreezeMovement()
    {

        isCanWalk = false;
    }


    private void UnFreezeMovement()
    {

        isCanWalk = true;
    }


    #endregion

}
