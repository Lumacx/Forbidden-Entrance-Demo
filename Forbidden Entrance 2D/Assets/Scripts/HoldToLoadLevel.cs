using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldToLoadLevel : MonoBehaviour
{
    public float holdDuration = 1.0f; //How long you have to hold down for action
    public Image fillCircle;

    private float holdTimer = 0;
    private bool isHolding = false;

    public static event Action OnHoldComplete;

        // Update is called once per frame
    void Update()
    {
     if (isHolding)
        {
            holdTimer += Time.deltaTime;
            fillCircle.fillAmount = holdTimer / holdDuration;
            if(holdTimer >= holdDuration )
            {
                //Load Next Level
                OnHoldComplete.Invoke();
                ResetHold();
            }
        }
    }

    public void OnHold (InputAction.CallbackContext context) 
    {
    
        if(context.started)
        {
            isHolding = true;
            SFX_Manager.Play("Teleport_in");
        }
        else if (context.canceled)
        {
            //Reset Holding
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0; 
        fillCircle.fillAmount = 0;
    }


}
