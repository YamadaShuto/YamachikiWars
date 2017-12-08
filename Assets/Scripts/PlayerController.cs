using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviourCustom
{
    // Rotate velocity
    private float rot_speed = 0.3f;
    [ReadOnly]
    // Velocity
    private float m_speed = 3.0f;
    // Bullet object
    [SerializeField]
    private GameObject bullet;
    // Whether it`s locked on
    private bool is_lock_on = false;
    // HP
    [ReadOnly]
    public int m_hp = 50;
    // Shot interval
    private int m_shot_time = 20;
    // Whether it`s shooting bullets
    private bool is_shoot = false;
    // Whether it`s boosting
    private bool is_boost = false;

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            GameController.GameOver();
        }
        if(Input.GetKey(KeyCode.A))
        {
            m_speed = 4.5f;
            is_boost = true;
        }
        else
        {
            m_speed = 3.0f;
            is_boost = false;
        }
        // Moving processing
        Move();
        // Rotation processing
        Rotation();
        // Lock on processing
        LockOn();
        // Shooting bullets processing
        Shot();

    }

    private void boost()
    {

    }

    private void Move()
    {
        // Moving to the front
        transform.Translate(Vector3.forward * Time.deltaTime * m_speed * 1);
    }

    private void Rotation()
    {
        Quaternion AddRot = Quaternion.identity;
        float yaw = 0;
        float pitch = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yaw = -rot_speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yaw = rot_speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pitch = -rot_speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pitch = rot_speed;
        }
        AddRot.eulerAngles = new Vector3(yaw, pitch, 0);
        transform.rotation *= AddRot;
    }

    private void LockOn()
    {
        // While X key is pressed
        if (Input.GetKey(KeyCode.X))
        {
            is_lock_on = true;
        }
        else
        {
            is_lock_on = false;
        }
    }

    private void Shot()
    {
        if (is_shoot)
        {
            if (Time.time % m_shot_time == 0)
            {
                is_shoot = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject obj;
                // Create bullet
                obj = Instantiate(bullet, transform.position, transform.rotation);
                // Change state it a player`s bullet
                obj.GetComponent<Bullet>().IsPlayer = true;
                // While is lock on
                if (is_lock_on)
                {
                    // Change to lock on state
                    obj.GetComponent<Bullet>().IsLockOn = true;
                    obj.GetComponent<Bullet>().Target = transform.SearchNearTag("Enemy");
                }
               // Change state a shooting bullet
                is_shoot = true;
            }
        }
    }

    // Setting property
    public bool IsLockOn
    {
        get { return is_lock_on; }
    }
    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }
    public bool IsBoost
    {
        get { return is_boost; }
    }

    // Collision ditermination
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameController.GameOver();
        }
    }
}
