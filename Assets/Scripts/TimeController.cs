using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //public GameObject player;
    private Vector3 newCurrentPosition;
    private Vector3 setPosition;
    public bool isReversing = false;
    private bool reverseSet = false;
    //public bool gameOver = false;

    void Start()
    {
        //if (!gameOver)
        //{
            setPosition = GameObject.FindWithTag("Player").transform.position;
        //}
        //else
       //{
            setPosition = new Vector3(0f, 0f, 0f);
        //}
    }

    void Update()
    {
        //if (!gameOver)
        //{
            GameObject player = GameObject.FindWithTag("Player");
            if (Input.GetKey(KeyCode.R))
            {
                //Debug.Log("Reset Position");
                setPosition = player.transform.position;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                //Debug.Log("Set position");
                player.transform.position = setPosition;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                isReversing = true;
            }
            else
            {
                isReversing = false;
            }
        //}
    }
    void Awake()
    {
        StartCoroutine(UpdatePosition());
    }
    private IEnumerator UpdatePosition()
    {
        while (true)
        {
            //if (!gameOver)
            //if (player)
            //{
                GameObject player = GameObject.FindWithTag("Player");
                newCurrentPosition = player.transform.position;
                yield return new WaitForSeconds(2.5f);
            //}
        }
    }
    void FixedUpdate()
    {
        if (isReversing )//&& !gameOver)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = newCurrentPosition;
            //player.transform.position = (Vector3)playerPositions[playerPositions.Count - 1];
            //playerPositions.RemoveAt(playerPositions.Count - 1);
        }
    }

    /*public void GameOver()
    {
        gameOver = true;
    }*/
}
