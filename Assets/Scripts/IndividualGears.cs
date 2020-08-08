using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGears : MonoBehaviour
{
    public GameObject[] allGears;
    private bool selected = false;


    void Update()
    {
        int counter = 0;
        for (int i = 0; i < allGears.Length; i++)
        {          
            if(allGears[i].GetComponent<RotationMouse>().isTouchingObject == false) 
            {
                counter++; 
                allGears[i].GetComponent<RotationMouse>().enabled = false;

                if (counter == allGears.Length)
                {
                    selected = false;
                    for (int j = 0; j < allGears.Length; j++)
                    {
                        allGears[j].GetComponent<RotationMouse>().enabled = true;
                    }
                }
            }
            else if (allGears[i].GetComponent<RotationMouse>().isTouchingObject == true && selected == false)
            {
                selected = true; 
                allGears[i].GetComponent<RotationMouse>().enabled = true;
            }


        }
    }
}
