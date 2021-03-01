using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public int num_pellets_collected = 0;

    public int bombs = 3;

    public int energy = 0;

    public int energy_cap = 200;

    public string textScore = "Score: ";

    public string textBombs = "Bombs: ";

    public string textEnergy = "Energy: ";

    public string textAfter = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Set_Text();
    }

    void FixedUpdate()
    {
        if (energy < energy_cap) energy += 1;
    }

    public void Set_Text()
    {
        GameObject score_board = GameObject.FindWithTag("Score");
        if (score_board != null)
        {
            string SceneName = SceneManager.GetActiveScene().name;
            if (SceneName.StartsWith("Tutorial"))
            {
                if (SceneName.Contains("Tutorial 3"))
                {
                    score_board.GetComponent<Text>().text = textBombs + bombs.ToString() + textAfter;
                } else if (SceneName.Contains("Tutorial 4"))
                {
                    score_board.GetComponent<Text>().text = textEnergy + energy.ToString() + textAfter;
                }
                else { score_board.GetComponent<Text>().text = textScore + score.ToString() + "\n" + textBombs + bombs.ToString() + "\n" + textEnergy + energy.ToString() + textAfter; }
            } else
                score_board.GetComponent<Text>().text = textScore + score.ToString() + "\n" + textBombs + bombs.ToString() + "\n" + textEnergy + energy.ToString() + textAfter;
        }
    }

    public void Reset_score()
    {
        score = 0;
        num_pellets_collected = 0;
        bombs = 3;
        energy = 0;
        Set_Text();
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

    public void Increment_bombs()
    {
        bombs += 1;
        Set_Text();
    }

    public bool Decrease_energy(int amount)
    {
        if (energy < amount)
        {
            return false;
        }

        energy -= amount;
        return true;
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

    public void SetTextAfter(string newtxt)
    {
        textAfter = newtxt;
        Set_Text();
    }
}
