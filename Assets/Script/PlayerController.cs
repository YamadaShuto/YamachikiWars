using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rot_speed = 0.3f;
    public float speed = 0.5f;
    public GameObject bullet;
    private bool rot_right = false;
    private bool rot_left = false;
    private bool rot_up = false;
    private bool rot_down = false;
    private GameObject near_enemy;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        
        Rotation();

        if(Bullet.bullet_num <= Bullet.max_bullet)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot();
            }
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            LockOn();
        }
    }

    private void Move()
    {
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
    }

    private void Rotation()
    {
        //回転行列
        Quaternion AddRot = Quaternion.identity;
        //横回転
        float yaw = 0;
        //縦回転
        float pitch = 0;
        //同時押し回避
        if (!(rot_down && rot_up))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                yaw = -1 * rot_speed;
                rot_up = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                yaw = rot_speed;
                rot_down = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rot_up = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rot_down = false;
        }

        //同時押し回避
        if (!(rot_left && rot_right))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pitch = -1 * rot_speed;
                rot_left = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pitch = rot_speed;
                rot_right = true;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rot_left = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rot_right = false;
        }
        
        //回転の適用
        AddRot.eulerAngles = new Vector3(yaw, pitch, 0);
        transform.rotation *= AddRot;
    }

    private void Shot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void CalcDistance()
    {
        //Vector3 distance = enemy.transform.position - transform.position;
        //distance.Normalize();
        //transform.Rotate(distance);
    }

    private void LockOn()
    {

    }
}
