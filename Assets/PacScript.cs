using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PacScript : MonoBehaviour
{
    private Rigidbody2D rb;

    //private BoxCollider2D bc;

    public Vector2 worldSize;

    private Animator anim;

    public Vector2 moveDir;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDir = new Vector2(0f, 0f);
        speed = 0.05f;
        worldSize = transform.lossyScale * 2f;
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        //Vector2 newPos = rb.position;
        if (horiz > 0 && valid(new Vector2(1f, 0f)))
        {
            moveDir = new Vector2(1f, 0f);
            //newPos.x += speed;
            anim.SetFloat("DirX", horiz);
            anim.SetFloat("DirY", 0f);
        }
        else if (horiz < 0 && valid(new Vector2(-1f, 0f)))
        {
            moveDir = new Vector2(-1f, 0f);
            //newPos.x -= speed;
            anim.SetFloat("DirX", horiz);
            anim.SetFloat("DirY", 0f);
        }
        else if (vert > 0 && valid(new Vector2(0f, 1f)))
        {
            moveDir = new Vector2(0f, 1f);
            //newPos.y += speed;
            anim.SetFloat("DirY", vert);
            anim.SetFloat("DirX", 0f);
        }
        else if (vert < 0 && valid(new Vector2(0f, -1f)))
        {
            moveDir = new Vector2(0f, -1f);
            //newPos.y -= speed;
            anim.SetFloat("DirY", vert);
            anim.SetFloat("DirX", 0f);
        }

        if (valid(moveDir))
        {
            //rb.velocity = moveDir * 30f;
            rb.MovePosition(rb.position + moveDir * speed);
        }
    }



    bool valid(Vector2 dir)
    {
        RaycastHit2D[] rh = Physics2D.BoxCastAll(rb.position, new Vector2(0.4f, 0.4f), 0f, dir, speed);

        return rh.Length == 1 &&
               rh[0].collider == GetComponent<Collider2D>();
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {

    }*/
}
