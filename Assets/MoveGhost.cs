using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhost : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.02f;
    void FixedUpdate()
    {
        // Move closer to waypoint until touching waypoint
        
        if (transform.position != waypoints[cur].position)
        {

            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Select next waypoint after reaching first waypoint
        //else cur = (cur + 1) % waypoints.Length;
        else if (cur == waypoints.Length) { cur = 0; } else { cur++; }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "pacman")
            Destroy(collider.gameObject);
    }
}
