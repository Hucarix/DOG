using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    public GameObject EndGamePanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;  //D�truire ou afficher l'�cran avec le score
            print("end");

            EndGamePanel.SetActive(true);

        }
    }

}
