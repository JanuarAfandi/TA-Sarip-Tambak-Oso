using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class MovePlayer : MonoBehaviour
{
    public new Animator animation;
    private Rigidbody2D rb;
    private float dirX;
    private float movespeed = 5f;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * movespeed;
        rb.velocity = new Vector2(dirX, 0f);
        
    }
      private void Flip(float flip)
    {
        if (flip < 0) transform.localScale = new Vector3(-1f, 1, 1);
        else if (flip > 0) transform.localScale = new Vector3(1f, 1f, 1f);
    }
   
       private void Jump()
    {
        if (isGround)
        {
            rb.AddForce(new Vector2(0f, 3000f));
        }
    }

}
