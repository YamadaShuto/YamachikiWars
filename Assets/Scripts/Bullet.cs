using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourCustom
{
    // Velocity
    private float m_speed = 40.0f;
    // Whether it`s locked on
    private bool is_lock_on = false;
    // Whether it`s thing of the player
    private bool is_player_has = false;
    // Target information
    private Transform m_target;
    
    // Use this for initialization
    void Start ()
    {
        // Destory after contant time
        Destroy(this.gameObject, 1.0f);
        // Adjustment direction
        Rotation();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Moving processing
        Move();
	}

    private void Move()
    {
        // Moving to the front
        transform.Translate(Vector3.forward * Time.deltaTime * m_speed);
    }

    private void Rotation()
    {
        // If the player has
        if(is_player_has)
        {
            // If in the lock on state
            if (is_lock_on)
            {
                // Look at the target
                transform.LookAt(m_target);
            }
        }
        // If the enemy has
        else
        {
            // Look at the player
            transform.LookAt(m_target);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        /*
        if(collision.gameObject == null)
        {
            Destroy(this.gameObject);
            return;
        }
        */
        // If the player has
        if (is_player_has)
        {
            // If hitting Enemy
            if (collision.gameObject.tag == "Enemy")
            {
                // Cut back Enemy HP
                collision.gameObject.GetComponent<EnemyController>().HP--;
                Destroy(this.gameObject);
            }
        }
        else
        {
            // If hitting player 
            if (collision.gameObject.tag == "Player")
            {
                // Cut back Player HP
                collision.gameObject.GetComponent<PlayerController>().HP--;
                Destroy(this.gameObject);
            }
        }
    }

    // Setting property
    public bool IsLockOn
    {
        get { return is_lock_on; }
        set { is_lock_on = value; }
    }
    public bool IsPlayer
    {
        get { return is_player_has; }
        set { is_player_has = value; }
    }
    public GameObject Target
    {
       set { m_target = value.transform;   }
    }
}
