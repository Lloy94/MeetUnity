using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private float mouseLook;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private GameObject _minePref;
    [SerializeField] private Transform _mineStartPosition;
    [SerializeField] private float _speed;
    [SerializeField] private int sensitivity;
    private Vector3 _dir;
    private void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            PlaceMine();
        }

        PlayerMove();
    }

    private void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    private void Fire()
    {
        var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, Quaternion.identity);
        var b = bullet.GetComponent<Bullet>();
        b.Init();


    }

    private void PlaceMine()
    {
        var mine = Instantiate(_minePref, _mineStartPosition.position, Quaternion.identity);
        var m = mine.GetComponent<Mine>();
        m.Init();
    }

    private void PlayerMove()
    {
        mouseLook = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseLook * sensitivity * Time.deltaTime, 0);
    }
}
