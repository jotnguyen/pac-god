using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExplosion : MonoBehaviour
{
    private float lifetime = 0.75f;
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
