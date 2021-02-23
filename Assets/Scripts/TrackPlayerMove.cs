using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerMove : MonoBehaviour
{
    //private Transform Player;
    int MoveSpeed = 2;
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
            Transform Player = GameObject.FindWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
        //}
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
