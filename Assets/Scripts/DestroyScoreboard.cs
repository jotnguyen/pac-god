using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScoreboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var score_board = GameObject.FindWithTag("Canvas");
        if (score_board)
        {
            Destroy(score_board);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
