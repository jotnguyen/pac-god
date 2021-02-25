using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGhost : MonoBehaviour
{
    public Transform[] waypoints;

    public int cur = 0;

    public bool edible = false;

    public Sprite EdibleSprite;
    public Sprite EnemySprite;

    public float speed = 0.06f;
    public float edibleSpeed = 0.04f;
    public float enemySpeed = 0.06f;
    void FixedUpdate()
    {
        // Move closer to waypoint until touching waypoint
        //transform.position != waypoints[cur].position
        if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.1f)
        {
            //Debug.Log(cur + "if");
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Select next waypoint after reaching first waypoint
        else
        {
            GetComponent<Rigidbody2D>().MovePosition(waypoints[cur].position);
            //cur = cur + 1;
            cur = (cur + 1) % waypoints.Length;
            //Debug.Log(cur);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!edible)
            {
                Destroy(FindObjectOfType<TimeController>());
                Destroy(collider.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                GameObject score_board = GameObject.FindWithTag("Score");
                score_board.GetComponent<ScoreManager>().Increase_score(10);
                Destroy(gameObject);
            }
        }
    }

    public void TurnInedible()
    {
        if (edible)
        {
            edible = false;
            GetComponent<SpriteRenderer>().sprite = EnemySprite;
            speed = enemySpeed;
        }
    }

    public void TurnEdible()
    {
        if (!edible)
        {
            edible = true;
            GetComponent<SpriteRenderer>().sprite = EdibleSprite;
            Invoke("TurnInedible", 5);
            speed = edibleSpeed;
        }
    }
}
