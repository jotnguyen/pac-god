using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase_score(int score_inc)
    {
        score += score_inc;

        GameObject score_board = GameObject.FindWithTag("Score");
        score_board.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
