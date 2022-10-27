using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject EndGamePanel;
    public GameObject ScreenShaking;
    public GameObject CameraSmoothShake;
    public bool InTheWall = false;
    public Animator anim;
    public GameObject Etoile1;
    public GameObject Etoile2;
    public GameObject Etoile3;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            print("end");
            EndGamePanel.SetActive(true);
            InTheWall = true;
            CameraSmoothShake.SetActive(false);
            ScreenShaking.SetActive(true);
            Camera.main.orthographicSize = 20;
            anim.SetTrigger("HitWall");

            Etoile1.SetActive(true);
            Etoile2.SetActive(true);
            Etoile3.SetActive(true);
        }
    }
}