using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject score_board = GameObject.FindWithTag("Score");
            if (score_board != null)
            {
                score_board.GetComponent<ScoreManager>().Increment_bombs();
            }

            Destroy(this.gameObject);
        }
    }
}
