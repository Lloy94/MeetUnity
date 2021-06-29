using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    private bool playernear = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playernear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playernear = false;
        }
    }

    private void Update()
    {
        if (playernear == true && Input.GetKeyDown(KeyCode.E))
        {
            _gate.Open();
        }
    }

}
