using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    public GameObject respawnPoint;
    private GameObject lightOrb;


    private void Start()
    {
        lightOrb = GameObject.Find("LightOrb");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LightOrb")
        {
            lightOrb.transform.position = respawnPoint.transform.position;
        }
    }


}
