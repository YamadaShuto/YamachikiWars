using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 15.0f;
    public static int bullet_num = 0;
    public const int max_bullet = 5;

	// Use this for initialization
	void Start ()
    {
        bullet_num++;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();	
	}

    private void Move()
    {
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("bullet");
            Destroy(collision.gameObject);
        }
    }

}
