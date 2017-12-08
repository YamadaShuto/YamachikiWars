using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //速度
    private float speed = 40.0f;
    //弾の最大数
    public const int max_bullet = 50;
    //ロックオンの状態
    private bool is_rockon = false;
    //誰が発射したか
    private bool is_player = false;
    private Transform target;
    
    // Use this for initialization
    void Start ()
    {
        //一定時間後に消える
        Destroy(this.gameObject, 1.0f);
        Rotation();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //移動処理
        Move();
	}

    private void Move()
    {
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotation()
    {
        //プレイヤーの物でロックオン中なら敵に向く
        if(is_player)
        {
            if (is_rockon)
            {
                transform.LookAt(target);
            }
        }
        //敵の物ならplayerを向く
        else
        {
            transform.LookAt(target);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == null)
        {
            Destroy(this.gameObject);
            return;
        }
        //誰の物か
        if (is_player)
        {
            //敵に当たったら
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("bullet");
                collision.gameObject.GetComponent<EnemyController>().HP--;
                Destroy(this.gameObject);
            }
        }
        else
        {
            //プレイヤーに当たったら
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("bullet Player");
                collision.gameObject.GetComponent<PlayerController>().HP--;
                Destroy(this.gameObject);
            }
        }
    }
    
    public bool Is_rockon
    {
        get { return is_rockon; }
        set { is_rockon = value; }
    }

    public bool Is_player
    {
        get { return is_player; }
        set { is_player = value; }
    }

    public GameObject Target
    {
       set { target = value.transform;   }
    }
}
