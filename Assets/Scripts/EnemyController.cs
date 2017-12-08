using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviourCustom
{
    // Velocirt
    private float m_speed = 3.0f;
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
    // Healing interval
    private float m_heal_time = 1600;
    // Use this for initialization
    void Start ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        if(Time.time % m_heal_time == 0)
        {
            HP++;
        }
        Move();
        Rotation();
    }

    private void Move()
    {
        // Moving constant velocity to the front
        transform.Translate(Vector3.forward * Time.deltaTime * m_speed );
    }

    private void Rotation()
    {
        // Look at the target
        transform.rotation = Quaternion.Slerp(transform.rotation, m_player.transform.rotation, Time.deltaTime * m_speed);
    }

    private void Shot()
    {
        //Judgment of player distance
        if (Vector3.Distance(transform.position, m_player.transform.position) <= 30.0f)
        {
            if (Time.time % m_shot_time == 0)
            {
                GameObject obj = Instantiate(m_bullet, transform.position, transform.rotation);
                obj.GetComponent<Bullet>().IsLockOn = true;
                obj.GetComponent<Bullet>().IsPlayer = false;
                obj.GetComponent<Bullet>().Target = transform.SearchNearTag("Player");
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
