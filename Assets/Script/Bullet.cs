using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 40.0f;
    public static int bullet_num = 0;
    public const int max_bullet = 1000;
    public bool is_rockon = false;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Move();
        Rotation();
        Destroy(this.gameObject, 2.0f);
	}

    private void Move()
    {
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotation()
    {
        if(!is_rockon)
        {
            //回転行列
            Quaternion AddRot = Quaternion.identity;
            //横回転
            float yaw = 0;
            //縦回転
            float pitch = 0;
            //回転の適用
            AddRot.eulerAngles = new Vector3(yaw, pitch, 0);
            transform.rotation *= AddRot;
        }
        else
        {
            transform.LookAt(transform.SearchNearTag("Enemy").transform);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("bullet");
            Destroy(collision.gameObject);
        }
    }
    
    public bool Is_rockon
    {
        get { return is_rockon; }
        set { is_rockon = value; }
    }
}
