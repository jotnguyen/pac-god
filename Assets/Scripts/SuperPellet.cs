using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPellet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            foreach (GameObject ghost in GameObject.FindGameObjectsWithTag("Ghost"))
            {
                var moveGhost = ghost.GetComponent<MoveGhost>();
                if (moveGhost) moveGhost.TurnEdible();
            }
            GameObject score_board = GameObject.FindWithTag("Score");
            if (score_board)
            {
                score_board.GetComponent<ScoreManager>().Increase_score(10);
            }

            Destroy(gameObject);
        }
    }
}
