using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private int _maxHP = 200;
    [SerializeField] private int _mineCount = 3;
    [SerializeField] private float jumpForce = 2;
    [SerializeField] private Text _hpValue;
    [SerializeField] private Text _mineValue;

    private int _hp;
    [SerializeField] private Animator _animator;

    [SerializeField] private Canvas _pauseMenu;

   


    private void Awake()
    {
        _pauseMenu.enabled = false;
        _hp = _maxHP;
        _hpValue.text = $"Hp: {_hp}";
        _mineValue.text = $"Мины: {_mineCount}";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      
    }
    private void Update()
    {
        _hpValue.text = $"Hp: {_hp}";
        _mineValue.text = $"Мины: {_mineCount}";
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

       
            if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.timeScale==1)
            {
                Fire();
          
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            { if(_pauseMenu.enabled == false)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _pauseMenu.enabled = true;
            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                _pauseMenu.enabled = false; }

             }
            if (Input.GetKeyDown(KeyCode.Mouse1)&&Time.timeScale==1)
            {
                if (_mineCount > 0)
                {
                     PlaceMine();
                _mineCount--;
            }
                 
            }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * jumpForce);

        }
        else _animator.SetBool("Jump", false);

        if (_dir != Vector3.zero)
            _animator.SetBool("Running", true);
        else _animator.SetBool("Running", false);
        PlayerMove();

        if (gameObject.transform.position.y < -10) { Death(); }
    }

    private void FixedUpdate()
    {
       
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
    }

    private void Fire()
    {
        
       
            var bullet = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
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

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Death();
        }
    }

    public void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("WinMenu");
    }

    public void AdHP(int hp) 
    {
        _hp += hp;
        if (_hp > _maxHP)
            _hp = _maxHP;
    }

    public void AdMine()
    {
        _mineCount++;
    }
    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
