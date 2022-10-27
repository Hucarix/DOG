using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed;
    public float ScoreToRotate;
    public Food ScoreScriptCall;
    public GameObject CameraSmoothShake;
    public Animator animator;

    void Update()
    {
        if (ScoreScriptCall.score >= ScoreToRotate)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
            CameraSmoothShake.SetActive(true);
            animator.SetTrigger("CameraChange");
        }
    }
}