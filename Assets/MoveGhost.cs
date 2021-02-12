using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhost : MonoBehaviour
{
    public Transform[] waypoints;

    public static int cur = 0;

    public float speed = 0.02f;
    void FixedUpdate()
    {
        // Move closer to waypoint until touching waypoint
        //transform.position != waypoints[cur].position
        if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.1f)
        {
            Debug.Log(cur + "if");
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Select next waypoint after reaching first waypoint
        else
        {
            //cur = cur + 1;
            cur = (cur + 1) % waypoints.Length;
            Debug.Log(cur);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            Destroy(collider.gameObject);
    }
}
