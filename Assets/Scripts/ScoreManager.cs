using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public int num_pellets_collected = 0;

    public int bombs = 3;

    public string textScore = "Score: ";

    public string textBombs = "Bombs: ";

    public string textAfter = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Text()
    {
        GameObject score_board = GameObject.FindWithTag("Score");
        if (score_board != null) score_board.GetComponent<Text>().text = textScore + score.ToString() + "\n" + textBombs + bombs.ToString() + textAfter;
    }

    public bool Decrement_bombs()
    {
        if (bombs > 0)
        {
            bombs -= 1;
            Set_Text();
            return true;
        }
        return false;
    }

    public void Increase_score(int score_inc)
    {
        score += score_inc;

        Set_Text();
    }

    public void pellet_hit()
    {
        num_pellets_collected += 1;
    }

    public void SetTextBefore(string newtxt)
    {
        textScore = newtxt;
        Set_Text();
    }

    public void SetTextAfter(string newtxt)
    {
        textAfter = newtxt;
        Set_Text();
    }
}
