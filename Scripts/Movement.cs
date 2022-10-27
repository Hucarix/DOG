using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform SegmentsPrefab;
    public Collision CollisionToCall1;
    public Collision CollisionToCall2;
    public Collision CollisionToCall3;
    public Collision CollisionToCall4;
    public Animator animator;
    public AudioSource SoundTop;
    public AudioSource SoundDown;
    public AudioSource SoundRight;
    public AudioSource SoundLeft;
    

    private TrailRenderer tr;

    private bool up;
    private bool down;
    private bool left;
    private bool right;

    public void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        tr = GetComponent<TrailRenderer>();
    }

    public void Update()
    {
        if ((CollisionToCall1.InTheWall == false) & (CollisionToCall2.InTheWall == false) & (CollisionToCall3.InTheWall == false) & (CollisionToCall4.InTheWall == false))
        {
            if (Input.GetKeyDown(KeyCode.Z) & (down == false))
            {
                up = true;
                left = false;
                right = false;
                direction = Vector2.up;
                var rotationVector = transform.rotation.eulerAngles;   //rotation de la tête en fonction direction
                rotationVector.z = 0;
                transform.rotation = Quaternion.Euler(rotationVector);

                SoundTop.Play();
            }
            else if (Input.GetKeyDown(KeyCode.S) & (up == false))
            {
                down = true;
                left = false;
                right = false;
                direction = Vector2.down;
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = 180;
                transform.rotation = Quaternion.Euler(rotationVector);

                SoundDown.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Q) & (right == false))
            {
                left = true;
                up = false;
                down = false;
                direction = Vector2.left;
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = 90;
                transform.rotation = Quaternion.Euler(rotationVector);

                SoundRight.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D) & (left == false))
            {
                right = true;
                up = false;
                down = false;
                direction = Vector2.right;
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = -90;
                transform.rotation = Quaternion.Euler(rotationVector);

                SoundLeft.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        this.transform.position = new Vector3
            (
            Mathf.Round(this.transform.position.x) + direction.x,  // Mathf.Round() pour arondir à la valeur entière proche 
            Mathf.Round(this.transform.position.y) + direction.y   // pour tjrs être aligner sur la grille
            );
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "food")
        {
            Grow();
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.SegmentsPrefab);
        segment.position = segments[segments.Count - 1].position;
        tr.time += 0.08f;
        segments.Add(segment);
        animator.Play("ChangeSegment");
    }
   
}