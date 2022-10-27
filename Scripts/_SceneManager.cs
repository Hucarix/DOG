using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class _SceneManager : MonoBehaviour
{
    public GameObject StartPanel;
    public Collision CollisionToCall1;
    public Collision CollisionToCall2;
    public Collision CollisionToCall3;
    public Collision CollisionToCall4;
    public GameObject EndPanel;
    public GameObject PausePanel;
    public Animator anim;
    public AudioSource audiosource;
    void Start()
    {
        Time.timeScale = 0;
        anim.SetTrigger("Apparition");

        audiosource.Play();
    }

    void Update()
    {
        Restart();
        Beginning();

        if (CollisionToCall1.InTheWall == true)
        {
            EndPanel.SetActive(true);
        }

        Exit();
    }

    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }

    public void Beginning()
    {
        if ((CollisionToCall1.InTheWall == false) & (CollisionToCall2.InTheWall == false) & (CollisionToCall3.InTheWall == false) & (CollisionToCall4.InTheWall == false))
        {
            if ((Input.GetKeyDown(KeyCode.Z)) || (Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.D)))
            {
                Time.timeScale = 1;
                StartPanel.SetActive(false);
            }
        }
    }

    public void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}