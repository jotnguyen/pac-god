using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPellet : MonoBehaviour
{
    public GameObject portal;
    public Vector3 portal_pos;
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Instantiate(portal, portal_pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
