using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D Area;
    public TMP_Text TextScore;      // TextMeshPro
    public int score;
    public Animator animator1;
    public Animator animator2;
    public GameObject MiamParticules;
    public Sprite newSprite;
    AudioSource audioSource;
    public AudioClip OsSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void RandomizePosition()  // pas d'instatiate, seulement déplacer l'objet après la collision
    {
        Bounds bounds = this.Area.bounds;
        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);                          // valeurs minimales et maximales de la zone de spawn
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);                          // bounds.min et bounds.max pour ne pas les rentrer a la main
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (OsSound != null)
            {
                audioSource.PlayOneShot(OsSound, 0.5f);
            }
            
            transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-90, 90)));
            
            RandomizePosition();
            
            Score();

            animator2.SetTrigger("Change1");
        }
    }
    

    void Score()
    {
        score++;
        TextScore.text = score.ToString();
        animator1.SetTrigger("Change");
    }
}

   