using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeployWalls : MonoBehaviour
{
    public TMP_Text pinkWallText, yellowWallText;
    public Button pinkWallButton, yellowWallButton;
    public int noOfPinkWalls, noOfYellowWalls;
    public bool pinkWallSelected=false, yellowWallSelected=false;
    public GameObject PinkWall,YellowWall; // Assign the prefab in the Inspector

    private void Start()
    {
        
        updateWallText();
    }

    void Update()
    {
        //for (int i = 0; i < Input.touchCount; i++)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Create a moveTarget if hit
        //        Instantiate(PinkWall, hit.point, transform.rotation);
        //    }
        //}
        
        deployWall();

      
    }


    void deployWall()
    {
        if (pinkWallSelected && noOfPinkWalls>0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                // Create a moveTarget if hit
                Instantiate(PinkWall, new Vector3(hit.point.x, 3.392193f, hit.point.z), transform.rotation);
                togglePinkWallSelection();
                noOfPinkWalls--;
                updateWallText();
            }   

        }

        else if (yellowWallSelected && noOfYellowWalls > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                // Create a moveTarget if hit
                Instantiate(YellowWall, new Vector3(hit.point.x, 3.392193f, hit.point.z), transform.rotation);
                toggleYellowWallSelection();
                noOfYellowWalls--;
                updateWallText();
            }
           
        }

    }


    public void togglePinkWallSelection()
    {
        if (!pinkWallSelected)
        {
            pinkWallSelected = true;
            pinkWallButton.image.color = new Color32(255, 141, 73,255);
            if (yellowWallSelected)
            {
                yellowWallSelected = false;
                yellowWallButton.image.color = new Color32(244, 255, 73, 255);
            }
        }
        else
        {
            pinkWallSelected = false;
            pinkWallButton.image.color = new Color32(255, 73, 232, 255);

        }
    }
    public void toggleYellowWallSelection()
    {
        if (!yellowWallSelected)
        {
            yellowWallSelected = true;
            yellowWallButton.image.color = new Color32(255, 141, 73, 255);
            if (pinkWallSelected)
            {
                pinkWallSelected = false;
                pinkWallButton.image.color = new Color32(255, 73, 232, 255);
            }
        }
        else
        {
            yellowWallSelected = false;
            yellowWallButton.image.color = new Color32(244, 255, 73, 255);
        }
    }

    void updateWallText()
    {
        pinkWallText.text = noOfPinkWalls.ToString();
        yellowWallText.text = noOfYellowWalls.ToString();
    }

}

