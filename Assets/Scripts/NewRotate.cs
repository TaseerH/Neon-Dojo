using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRotate : MonoBehaviour
{
    private Touch touch;
    private float rotationSpeed = 0.2f;
    private float boxcastSize = 5f; // Adjust this value as per your requirement
    private float rotationDamping = 50f; // Adjust the damping effect as per your requirement

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                BoxcastAroundTouchPosition();
            }
        }
    }

    private void BoxcastAroundTouchPosition()
    {
        Vector3 touchPosition = touch.position;
        Vector3 boxcastExtents = new Vector3(boxcastSize, boxcastSize, boxcastSize);
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);

        RaycastHit[] hits = Physics.BoxCastAll(ray.origin, boxcastExtents, ray.direction, Quaternion.identity, Mathf.Infinity);

        foreach (RaycastHit hit in hits)
        {
            // Check if the hit object is a wall (you can modify the condition based on your wall objects)
            if (hit.transform.CompareTag("MetalWall") || hit.transform.CompareTag("MirrorWall"))
            {
                RotateWall(hit.transform);
            }
        }
    }

    private void RotateWall(Transform wallTransform)
    {
        // Calculate the rotation based on the touch movement
        Quaternion rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotationSpeed, 0f);

        // Gradually rotate the wall towards the calculated rotation using Slerp
        wallTransform.rotation = Quaternion.Slerp(wallTransform.rotation, rotationY * wallTransform.rotation, Time.deltaTime * rotationDamping);
    }
}
