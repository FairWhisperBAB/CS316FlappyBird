using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Awake()
    {
        //get reference
        groundCollider = GetComponent<BoxCollider2D>();
        //store reference of collider along the x axis
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        //how far to the right the background will move (2 times the length
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
        //this will move the object offscreen, behind the player, to the new position infront of the player
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
