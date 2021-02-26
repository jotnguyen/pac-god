using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerMove : MonoBehaviour
{
    //private Transform Player;
    float MoveSpeed = 0.55f;
    public bool edible = false;

    //public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //if (!gameOver)
        //{
        GameObject PlayerGO = GameObject.FindWithTag("Player");
        if (PlayerGO != null)
        {
            Transform Player = GameObject.FindWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
        }

        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!edible) Destroy(collider.gameObject);
            else
            {
                GameObject score_board = GameObject.FindWithTag("Score");
                score_board.GetComponent<ScoreManager>().Increase_score(10);
                Destroy(gameObject);
            }
        }
    }

    /*public void GameOver()
    {
        gameOver = true;
    }*/
}
