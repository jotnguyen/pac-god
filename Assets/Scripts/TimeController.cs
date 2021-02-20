using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject player;
    private Vector3 newCurrentPosition;
    private Vector3 setPosition;
    public bool isReversing = false;
    private bool reverseSet = false;

    void Start()
    {
        setPosition = player.transform.position;
    }

    void Update()
    {
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
    }
    void Awake()
    {
        StartCoroutine(UpdatePosition());
    }
    private IEnumerator UpdatePosition()
    {
        while (true)
        {
            newCurrentPosition = player.transform.position;
            yield return new WaitForSeconds(2.5F);
        }
    }
    void FixedUpdate()
    {
        if (isReversing)
        {
            player.transform.position = newCurrentPosition;
            //player.transform.position = (Vector3)playerPositions[playerPositions.Count - 1];
            //playerPositions.RemoveAt(playerPositions.Count - 1);
        }
    }
}
