using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private bool platIsActive;
    public GameObject Platform;
    public GameObject col;


    private void Update()
    {
        Platform.SetActive(platIsActive);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == col)
            platIsActive= true;
            Debug.Log("Hij raakt mij!!!!!!!");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == col)
            platIsActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.gameObject == col)
            platIsActive = false;
    }
}
