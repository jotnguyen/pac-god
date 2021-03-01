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
    public GameObject pacWaypointPrefab;
    private GameObject pacWaypoint;
    //public bool gameOver = false;

    public int blink_cost = 100;

    void Start()
    {
        setPosition = GameObject.FindWithTag("Player").transform.position;
        pacWaypoint = new GameObject("New");
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(pacWaypoint);
            setPosition = player.transform.position;
            pacWaypoint = Instantiate(pacWaypointPrefab, player.transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (FindObjectOfType<ScoreManager>() != null && FindObjectOfType<ScoreManager>().Decrease_energy(blink_cost))
                player.transform.position = setPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FindObjectOfType<ScoreManager>() != null && FindObjectOfType<ScoreManager>().Decrease_energy(blink_cost))

                player.transform.position = newCurrentPosition;
            //isReversing = true;
        }
        else
        {
            isReversing = false;
        }
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
