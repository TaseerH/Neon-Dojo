using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragAndRotate : MonoBehaviour
{
    public bool isActive = false;
    Color activeColor = new Color();

    private Touch touch;
    private float rotationSpeed = 0.1f;
    private float boxcastSize = 15f; // Adjust this value as per your requirement
    private float rotationDamping = 50f; // Adjust the damping effect as per your requirement

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            activeColor = Color.red;
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0); // Assign the current touch to the touch variable
                if (touch.phase == TouchPhase.Moved)
                {
                    BoxcastAroundTouchPosition();
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    isActive = false;
                }
            }
        }
        else
        {
            activeColor = Color.white;
        }
        GetComponent<MeshRenderer>().material.color = activeColor;
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
            if (hit.transform.CompareTag("Wall"))
            {
                Debug.Log("Wall hit!");

                // Adjust the rotation calculation for continuous rotation
                float rotationAmount = -touch.deltaPosition.x * rotationSpeed * rotationDamping * Time.deltaTime;
                transform.Rotate(0f, rotationAmount, 0f);

            }
        }
    }

}
