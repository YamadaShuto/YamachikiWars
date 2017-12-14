using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviourCustom
{
    // Rotate velocity
    private float rot_speed = 0.3f;
    [ReadOnly]
    // Velocity
    private float m_speed = 5.0f;
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
    // Shot Counter
    private int m_shot_cnt = 0;
    // Whether it`s shooting bullets
    private bool is_shoot = false;
    // Whether it`s boosting
    private bool is_boost = false;
    // Boost time
    private int m_boost_time = 180;
    [ReadOnly]
    // Boost time interval
    private int m_boost_time_cnt = 180;

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            return;
        }
        if(Input.GetKey(KeyCode.A))
        {
            is_boost = true;
        }
        else
        {
            is_boost = false;
            if(m_boost_time_cnt < 240)
            {
                m_boost_time_cnt++;
            }
        }
        // Rotation processing
        Rotation();
        // Shooting bullets processing
        Shot();
        // Moving processing
        Move();
        // Lock on processing
        LockOn();
    }

    private void Move()
    {
        if (m_boost_time_cnt <= 0)
        {
            is_boost = false;
        }
        // Moving to the front
        if (is_boost)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (m_speed + 3.0f));
            m_boost_time_cnt--;
        }
        else
        {

            transform.Translate(Vector3.forward * Time.deltaTime * m_speed);
        }
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
            m_shot_cnt++;
            if ( m_shot_time == m_shot_cnt)
            {
                is_shoot = false;
                m_shot_cnt = 0;
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

    public int BoostCnt
    {
        get { return m_boost_time_cnt; }
    }

    // Collision ditermination
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP = 0;
        }
    }
}
