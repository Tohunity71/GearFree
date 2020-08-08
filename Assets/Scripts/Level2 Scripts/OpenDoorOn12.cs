using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOn12 : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Door.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    { 
        Door.SetActive(false);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Door.SetActive(true);
    }

}
