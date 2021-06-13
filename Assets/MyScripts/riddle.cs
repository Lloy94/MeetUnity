using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddle : MonoBehaviour
{
    [SerializeField] private Gate _gate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                _gate.Open();
            //}
        }
    }

}
