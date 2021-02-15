using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        foreach (var GObject in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            GObject.GetComponent<MoveGhost>().cur = 0;
        }

        ;
        SceneManager.LoadScene("Level1");
    }
}