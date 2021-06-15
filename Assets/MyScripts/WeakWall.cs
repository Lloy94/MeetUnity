using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mine"))
        {
            Destroy(gameObject, 10);
        }
    }
}
