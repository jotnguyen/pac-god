using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Rigidbody rb;

    public int maxSceneIndex;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
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
        foreach (GameObject GObject in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            var moveGhost = GObject.GetComponent<MoveGhost>();
            if (moveGhost) moveGhost.cur = 0;
        }

        if (col.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex < maxSceneIndex)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                GameObject score_board = GameObject.FindWithTag("Score");
                score_board.GetComponent<ScoreManager>().SetTextAfter("\nThat's all the levels we have so far, so I guess you win!");
                Destroy(this.gameObject);
            }
        }
    }
}