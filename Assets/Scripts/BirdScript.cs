using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;

    private Animator anim;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //Get references to Animator and RB
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow control if the bird has died
        if (isDead == false)
        {
            //look for input to trigger a "flap".
            if (Input.GetMouseButton(0))
            {
                //tell animator to do sprite thing
                anim.SetTrigger("Flap");

                //zero out to velocity
                rb2d.velocity = Vector2.zero;

                //give the bird force upward
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;

        //if bird collides with pillers set it to dead
        isDead = true;

        //tell animator to do sprite thing
        anim.SetTrigger("Die");

        //tell game manager to 
        //GameManager.instance.BirdDied();
    }
}
