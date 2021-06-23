using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void DeathAnimation()
    {
        _animator.SetBool("Death",true);
    }
}
