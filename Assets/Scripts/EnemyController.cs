using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //移動速度
    private float speed = 3.0f;
    //
    private GameObject player;
    //探査時間
    //private int search_time = 10;
    //弾のオブジェクト
    [SerializeField]
    private GameObject bullet;
    //HP
    [SerializeField]
    private int m_hp = 10;
    //発射感覚
    private int m_shot_time = 25;
    private float m_shot_time_cnt = 0;
    private bool is_bullet = false;
    private float m_heal_time = 1600;
    private float m_heal_cnt = 0;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        Move();
        if(m_heal_cnt >= m_heal_time)
        {
            HP++;
            m_heal_cnt = 0;
        }
        else
        {
            m_heal_cnt++;
        }
        //探知時間に達していたら弾発射
        
      // if(search_time == time_cnt)
        {
            //target_pos = player.transform.position;
            //GameObject obj = Instantiate(bullet, transform.position, transform.rotation);
            //obj.GetComponent<Bullet>().Is_rockon = true;
            //obj.GetComponent<Bullet>().Is_player = false;
            //time_cnt = 0;
        }

        //敵とPlayerとの距離の判定
        if (Vector3.Distance(transform.position, player.transform.position) <= 30.0f)
        {
            if (is_bullet)
            {
                m_shot_time_cnt++;
                if (m_shot_time <= m_shot_time_cnt)
                {
                    is_bullet = false;
                    m_shot_time_cnt = 0;
                }
            }
            else
            {
                GameObject obj = Instantiate(bullet, transform.position, transform.rotation);
                obj.GetComponent<Bullet>().Is_rockon = true;
                obj.GetComponent<Bullet>().Is_player = false;
                obj.GetComponent<Bullet>().Target = transform.SearchNearTag("Player");
                is_bullet = true;
            }
        }
        //スムーズにターゲットの方向を向く
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * speed);

    }

    private void Move()
    {
        //transform.LookAt(player.transform);
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed );
    }

    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }
}
