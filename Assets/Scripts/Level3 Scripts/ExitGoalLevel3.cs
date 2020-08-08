using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitGoalLevel3 : MonoBehaviour
{
    public GameObject closedPortal;
    public GameObject EndScreen;
    public GameObject Player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LightOrb")
        {
            closedPortal.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LightOrb")
        {
            closedPortal.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        EndScreen.gameObject.SetActive(true);
        
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
