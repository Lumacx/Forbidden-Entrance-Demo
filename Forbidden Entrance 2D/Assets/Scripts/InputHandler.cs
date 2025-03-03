using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake ()

    {
        _mainCamera = Camera.main;

    }

    public void Onclick(InputAction.CallbackContext context)

    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;
     
        Debug.Log(rayHit.collider.gameObject.name);

     }

}
