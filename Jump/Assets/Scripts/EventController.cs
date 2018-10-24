using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController
{
    #region events

    public static event Action jump;
    public static event Action freezeMoving;
    public static event Action unFreezeMoving;
    public static event Action trampolineJump;


    #endregion


    #region eventsEnum

    public enum Events
    {
        jump,
        freezeMoving,
        unFreezeMoving,
        trampolineJump
    }

    #endregion




    #region Public methods

    public static void InvokeEvent(Events value)
    {
        if(value == Events.jump)
        {
            if (jump != null)
                jump();

        }
        
        if (value == Events.freezeMoving)
        {
            if (freezeMoving != null)
                freezeMoving();

        }

        if (value == Events.unFreezeMoving)
        {
            if (unFreezeMoving != null)
                unFreezeMoving();

        }


        if (value == Events.trampolineJump)
        {
            if (trampolineJump != null)
                trampolineJump();

        }

    }




    #endregion





}
