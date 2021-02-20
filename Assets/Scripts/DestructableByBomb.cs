using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableByBomb : MonoBehaviour
{
    public virtual void OnDestroyedByBomb()
    {
        Destroy(gameObject);
    }
}
