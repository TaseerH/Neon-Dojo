using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Rotatable : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis;
    [SerializeField] private float speed;

    private Vector2 rotation;
    private bool rotateAllowed;

    private void OnEnable()
    {
        pressed.Enable();
        axis.Enable();
        pressed.performed += _ => { StartCoroutine(Rotate()); };
        pressed.canceled += _ => { rotateAllowed = false; };
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };

        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        pressed.Disable();
        axis.Disable();
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator Rotate()
    {
        rotateAllowed = true;

        while (rotateAllowed)
        {
            // Applying rotation
            rotation *= speed;

            if (Mouse.current != null)
            {
                // Perform a raycast from the mouse position into the scene
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RotateWallWithRaycast(ray);
            }
            else if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
            {
                // For touch input, consider the first touch
                Touch touch = Touch.activeTouches[0];
                Ray ray = Camera.main.ScreenPointToRay(touch.screenPosition);
                RotateWallWithRaycast(ray);
            }

            yield return null;
        }
    }

    private void RotateWallWithRaycast(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is a wall (you can modify the condition based on your wall objects)
            if (hit.transform.CompareTag("Wall"))
            {
                // Rotate only the intersected wall
                hit.transform.Rotate(-Vector3.up, rotation.x, Space.World);
            }
        }
    }



}
