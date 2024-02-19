using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public UnityEngine.UI.Text _playerLevelText;
    public UnityEngine.UI.Text _playerXPText;
    public UnityEngine.UI.Text _playerHPText;

    public float _damage;//Damage the player deals with his arrows. Is also increased by level
    public float _movSpeed;
    public float _maxHp;
    private float _health;

    private float _timeAlive;
    private int _experience;
    private int _playerLevel;

    public GameObject _arrowPrefab;


    private void Awake()
    {
        _CurHp = _maxHp;
    }

    private void Update()
    {
        _timeAlive += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
            KillAllEnemies();
    }

    private void FixedUpdate () {
		if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.fixedDeltaTime * _movSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.fixedDeltaTime * _movSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.fixedDeltaTime * _movSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.fixedDeltaTime * _movSpeed;
        }
    }

    private void Die()
    {
        GetComponent<Renderer>().enabled = false;
        Time.timeScale = 0;
    }

    private void KillAllEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
            enemies[i]._CurHp = 0;
    }

    private void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        GameObject newArrowGO = Instantiate(_arrowPrefab, transform.position, Quaternion.identity);
        Vector2 dir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        newArrowGO.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        newArrowGO.GetComponent<Arrow>()._damage = _damage + _PlayerLevel;
    }

    public float _CurHp
    {
        get { return _health; }
        set {

            if (value > _maxHp)
                value = _maxHp;
            _health = value;
            _playerHPText.text = _health + " / " + _maxHp;
            if (_health <= 0)
                Die();
        }
    }

    public float _TimeAlive
    {
        get
        {
            return _timeAlive;
        }
    }

    public int _Experience
    {
        get { return _experience; }
        set
        {
            if (value > 800)
                _PlayerLevel = 4;
            else if (value > 400)
                _PlayerLevel = 3;
            else if (value > 200)
                _PlayerLevel = 2;
            else if (value > 100)
                _PlayerLevel = 1;
            else
                _PlayerLevel = 0;

            _experience = value;
            _playerXPText.text = _experience.ToString();
        }
    }

    public int _PlayerLevel
    {
        get { return _playerLevel; }
        set
        {
            _playerLevel = value;
            _playerLevelText.text = _playerLevel.ToString();
        }
    }
}
