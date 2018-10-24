using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    #region private fields

    private Rigidbody rb;

    #endregion

    #region Serializable fields

    [SerializeField]
    private float jumpPower;

    #endregion
    

    #region Properties

    private bool isCanJump { get; set; }

    #endregion

    
    #region UnityLifeCycle
    
  


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Platform>())
        {

            EventController.InvokeEvent(EventController.Events.unFreezeMoving);
            isCanJump = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Platform>())
        {
            isCanJump = false;
        }
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        EventController.trampolineJump += TrampolineJump;
    }


    void Update()
    {

        if (isCanJump)
        {
           
            if(Input.GetKeyDown(KeyCode.Space))
            {
                
                EventController.InvokeEvent(EventController.Events.jump);
                EventController.InvokeEvent(EventController.Events.freezeMoving);

            }
        }       
    }

    #endregion


    #region Event Handlers
   
    private void TrampolineJump()
    {
        isCanJump = false;

    }


    #endregion


}
