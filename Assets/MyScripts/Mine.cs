using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime = 10;
    public void Init()
    {
        Destroy(gameObject, _maxLifeTime);
    }
}
