using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackPlayerMove : MonoBehaviour
{
    //private Transform Player;
    float MoveSpeed = 0.55f;
    public bool edible = false;

    public Sprite EdibleSprite;
    public Sprite EnemySprite;

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
        //if (collider.gameObject.tag == "Player")
        if (collision.gameObject.tag == "Player")
        {
            if (!edible)
            {
                Destroy(FindObjectOfType<TimeController>());
                //Destroy(collider.gameObject);
                Destroy(collision.gameObject);
                if (SceneManager.GetActiveScene().name.Contains("Level1"))
                {
                    GameObject old_score_board = GameObject.FindWithTag("Canvas");
                    if (old_score_board != null)
                    {
                        Destroy(old_score_board);
                    }
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                GameObject score_board = GameObject.FindWithTag("Score");
                if (score_board != null) score_board.GetComponent<ScoreManager>().Reset_score();
            }
            else
            {
                GameObject score_board = GameObject.FindWithTag("Score");
                if (score_board)
                {
                    score_board.GetComponent<ScoreManager>().Increase_score(10);
                }
                Destroy(gameObject);
            }
        } else if (collision.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    /*void OnTriggerEnter2D(Collider2D collider)
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
    }*/
    /*void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!edible)
            {
                Destroy(FindObjectOfType<TimeController>());
                Destroy(collider.gameObject);
                if (SceneManager.GetActiveScene().name.Contains("Sample"))
                {
                    GameObject old_score_board = GameObject.FindWithTag("Canvas");
                    if (old_score_board != null)
                    {
                        Destroy(old_score_board);
                    }
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                GameObject score_board = GameObject.FindWithTag("Score");
                if (score_board != null) score_board.GetComponent<ScoreManager>().Reset_score();
            }
            else
            {
                GameObject score_board = GameObject.FindWithTag("Score");
                if (score_board)
                {
                    score_board.GetComponent<ScoreManager>().Increase_score(10);
                }
                Destroy(gameObject);
            }
        }
    }*/

    public void TurnInedible()
    {
        if (edible)
        {
            edible = false;
            GetComponent<SpriteRenderer>().sprite = EnemySprite;
        }
    }

    public void TurnEdible()
    {
        if (!edible)
        {
            edible = true;
            GetComponent<SpriteRenderer>().sprite = EdibleSprite;
            Invoke("TurnInedible", 5);
        }
        else
        {
            CancelInvoke("TurnInedible");
            Invoke("TurnInedible", 5);
        }
    }

    /*public void GameOver()
    {
        gameOver = true;
    }*/
}
