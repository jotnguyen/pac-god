﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            GameObject score_board = GameObject.FindWithTag("Score");
            score_board.GetComponent<ScoreManager>().Increase_score(1);
            score_board.GetComponent<ScoreManager>().pellet_hit();
            Destroy(gameObject);
        }
    }
}
