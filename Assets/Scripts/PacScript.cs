using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class PacScript : MonoBehaviour
{
    private Rigidbody2D rb;

    //private BoxCollider2D bc;

    public Vector2 worldSize;

    private Animator anim;

    public Vector2 moveDir;

    public float speed;

    public GameObject BombPrefab;

    public int num_pellets;
    public bool portalIsCreated;
    public GameObject portal;
    public Vector3 portal_pos;
    public int start_npc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDir = new Vector2(0f, 0f);
        speed = 0.05f;
        worldSize = transform.lossyScale * 2f;
        Screen.SetResolution(1280, 720, false);
        
        num_pellets = GetNumPellets();
        portalIsCreated = false;
        //GameObject pm = GameObject.FindWithTag("Player");
        GameObject score_board = GameObject.FindWithTag("Score");
        if (score_board)
        {
            start_npc = score_board.GetComponent<ScoreManager>().num_pellets_collected;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(BombPrefab, transform.position, Quaternion.identity);
        }
        CollectedAll();
    }

    private void FixedUpdate()
    {


        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        //Vector2 newPos = rb.position;
        if (horiz > 0 && valid(new Vector2(1f, 0f)))
        {
            moveDir = new Vector2(1f, 0f);
            anim.SetFloat("DirX", horiz);
            anim.SetFloat("DirY", 0f);
        }
        else if (horiz < 0 && valid(new Vector2(-1f, 0f)))
        {
            moveDir = new Vector2(-1f, 0f);
            anim.SetFloat("DirX", horiz);
            anim.SetFloat("DirY", 0f);
        }
        else if (vert > 0 && valid(new Vector2(0f, 1f)))
        {
            moveDir = new Vector2(0f, 1f);
            anim.SetFloat("DirY", vert);
            anim.SetFloat("DirX", 0f);
        }
        else if (vert < 0 && valid(new Vector2(0f, -1f)))
        {
            moveDir = new Vector2(0f, -1f);
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
        //RaycastHit2D[] rh = Physics2D.BoxCastAll(rb.position, new Vector2(0.4f, 0.4f), 0f, dir, speed);
        RaycastHit2D[] rh = Physics2D.BoxCastAll(rb.position, worldSize, 0f, dir, speed);

        return (rh.Length == 1 && rh[0].collider == GetComponent<Collider2D>()) || (rh[1].collider.transform.tag == "Ghost");
    }

    public int GetNumPellets()
    {
        foreach (var g in GameObject.FindGameObjectsWithTag("Pellet"))
        {
            num_pellets += 1;
        }

        return num_pellets;
    }
    
    public void CollectedAll()
    {
        GameObject score_board = GameObject.FindWithTag("Score");
        if (score_board)
        {
            int num_pc = score_board.GetComponent<ScoreManager>().num_pellets_collected;
            if (num_pc >= start_npc + num_pellets && !portalIsCreated)
            {
                Instantiate(portal, portal_pos, Quaternion.identity);
                portalIsCreated = true;
            }
        }
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {

    }*/
}
