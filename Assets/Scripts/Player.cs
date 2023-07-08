using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource shotSoundEffect;
    [SerializeField] private GameObject levelController;
    private Vector2 _dir;
    private bool gamePause = false;
    public GameObject BulletPrefab;
    public Transform BulletPoint;
    public bool _shoot = true;
    public bool walking;
    public bool attacking;
    float lastX;
    float lastY;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon.SetOwner(GetComponent<HealthComponent>());
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //_dir = Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.up;
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + dir * _speed * Time.fixedDeltaTime);

        //rb.position += _dir.normalized * _speed * Time.deltaTime;
        walking = true;
        lastX = dir.x;
        lastY = dir.y;

        if (dir == Vector2.zero)
        {
            walking = false;
            //return;
        }

        if (_dir.magnitude >= .1f)
        {
            transform.up = _dir;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_shoot)
            {
                // Emito el fx de disparo.
                shotSoundEffect.Play();
                // Invoco a la función de disparo.
                ShootPJ();
                Debug.Log("---Disparando---");
                // Invoco a la animación de ataque.
                anim.SetTrigger("Attacking 0");
                // Seteamos la variable _shott en false.
                _shoot = false;
                // Seteamos el tiempo del cooldown.
                Invoke("CooldownShoot", 0.3f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Debug.Log("Se presiono el botón pausa.");
                gamePause = false;
                levelController.GetComponent<LevelController>().PauseMenuResume();
                Debug.Log(gamePause);
            }
            else
            {
                gamePause = true;
                levelController.GetComponent<LevelController>().PauseMenuPause();
                Debug.Log(gamePause);
            }
        }
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + _dir.normalized * (_speed * Time.fixedDeltaTime));//
        anim.SetBool("Walking", walking);
        anim.SetFloat("Last X", lastX);
        anim.SetFloat("Last Y", lastY);
    }

    void ShootPJ()
    {
        GameObject bullet = Instantiate(BulletPrefab);
        bullet.transform.position = BulletPoint.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletPJ>().ownedByPlayer = true;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, y, 0).normalized;
        bullet.transform.right = dir;
    }

    // Función cooldown
    void CooldownShoot()
    {
        _shoot = true;
    }

    // public void AnimationAttack()
    // {
    //anim.SetBool("Attacking", attacking);
    //attacking = true;
    // }
}