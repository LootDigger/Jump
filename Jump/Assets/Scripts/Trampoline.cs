using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    #region Properties

    private bool isReadyToShoot { get; set; }

    #endregion


    #region UnityLifeCycle

    void Start()
    {
        isReadyToShoot = true;
    }


    void OnTriggerStay(Collider other)
    {
       if(isReadyToShoot)
        if(other.tag == "Player")
        {
            EventController.InvokeEvent(EventController.Events.trampolineJump);
                isReadyToShoot = false;
                StartCoroutine(Timer());
        }

    }

    #endregion


    #region private methods

    private IEnumerator Timer()
    {

        yield return new WaitForSeconds(5f);
        isReadyToShoot = true;
    }

    #endregion

}
