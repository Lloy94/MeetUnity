using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<HeroMove>().AdHP(50);
        }
    }
}
