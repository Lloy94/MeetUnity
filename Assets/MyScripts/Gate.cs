using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private bool _isOpen = false;

    private void Update()
    {
        if (_isOpen)
            Destroy(gameObject);
    }

    public void Open()
    {
        _isOpen = true;
    }
}
