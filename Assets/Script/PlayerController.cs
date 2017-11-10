using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourCustom
{
    public float rot_speed = 0.3f;
    public float speed = 0.5f;
    public GameObject bullet;
    public bool is_rockon = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Rotation();

        if (Input.GetKey(KeyCode.X))
        {
            is_rockon = true;
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            is_rockon = false;
        }
        if (Extension.SearchTagCount("Bullet") <= Bullet.max_bullet)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shot();
            }
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yaw = -1 * rot_speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yaw = rot_speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pitch = -1 * rot_speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pitch = rot_speed;
        }

        //回転の適用
        AddRot.eulerAngles = new Vector3(yaw, pitch, 0);
        transform.rotation *= AddRot;
    }

    private void Shot()
    {
        if (!is_rockon)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>().is_rockon = true;
        }
    }

}
