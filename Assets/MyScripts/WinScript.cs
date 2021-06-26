using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private HeroMove _player;
    public void OnTriggerStay(Collider other)
    {
        if (_boss == null)
        {
            _player.Invoke("Win", 6);
        }

    }
}
