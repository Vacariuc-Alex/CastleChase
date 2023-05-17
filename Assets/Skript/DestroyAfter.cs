using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float lifeDuration = 1;
    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }
}
