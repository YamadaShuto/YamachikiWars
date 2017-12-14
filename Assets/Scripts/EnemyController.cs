using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviourCustom
{
    // Velocirt
    private float m_speed = 4.0f;
    // Player object
    private GameObject m_player;
    // Bullet object
    [SerializeField]
    private GameObject m_bullet;
    // HP
    [SerializeField]
    private int m_hp = 10;
    // Bullet firing interval
    private int m_shot_time = 25;
    // Bullet interval count
    private int m_shot_time_cnt = 0;
    // Target transform
    Transform trans;
    private float m_rot_cnt;

    // Use this for initialization
    void Start ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        trans = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        Rotation();
        Move();
        Shot();
    }

    private void Move()
    {
        // Moving constant velocity to the front
        transform.Translate(Vector3.forward * Time.deltaTime * m_speed );
    }

    private void Rotation()
    {
        if(m_rot_cnt >= 180)
        {
            trans.transform.LookAt(m_player.transform);
            m_rot_cnt = 0;
        }
        else
        {
            m_rot_cnt++;
        }
        // Look at the target
        transform.rotation = Quaternion.Slerp(transform.rotation, trans.rotation, Time.deltaTime * m_speed);
    }

    private void Shot()
    {
        //Judgment of player distance
        if (Vector3.Distance(transform.position, m_player.transform.position) <= 40.0f)
        {
            if (m_shot_time == m_shot_time_cnt)
            {
                GameObject obj = Instantiate(m_bullet, transform.position, transform.rotation);
                obj.GetComponent<Bullet>().IsLockOn = true;
                obj.GetComponent<Bullet>().IsPlayer = false;
                obj.GetComponent<Bullet>().Target = transform.SearchNearTag("Player");
                m_shot_time_cnt = 0;
            }
            else
            {
                m_shot_time_cnt++;
            }
        }
    }

    // Setting property
    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }
}
