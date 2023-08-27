using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.touches[0].position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            float boxCastDistance = 10000.0f; // Adjust this distance as needed
            Vector3 boxCastDirection = ray.direction; // Use ray direction as the box cast direction

            RaycastHit hit;
            if (Physics.BoxCast(ray.origin, Vector3.zero, boxCastDirection, out hit, Quaternion.identity, boxCastDistance))
            {
                if (hit.transform.tag == "MirrorWall" || hit.transform.tag == "MetalWall")
                {
                    var objectScript = hit.collider.GetComponent<DragAndRotate>();
                    if (objectScript != null)
                    {
                        objectScript.isActive = !objectScript.isActive;
                    }
                }
            }
        }
    }
}
