using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviourCustom
{
    //回転速度
    private float rot_speed = 0.3f;
    [SerializeField]
    //移動速度
    private float speed = 3.0f;
    //弾オブジェクト
    [SerializeField]
    private GameObject bullet;
    //ロックオンの状態
    private bool is_rockon = false;
    //回転状態
    private bool is_rotate = false;
    //HP
    [ReadOnly]
    public int m_hp = 50;
    //発射感覚
    private int m_shot_time = 20;
    private float m_shot_time_cnt = 0;
    private bool is_bullet = false;
    // Use this for initialization
    private bool is_boost = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            GameController.GameOver();
        }
        if(Input.GetKey(KeyCode.A))
        {
            speed = 4.5f;
            is_boost = true;
        }
        else
        {
            speed = 3.0f;
            is_boost = false;
        }
        //自動移動処理
        Move();
        //回転処理
        Rotation();
        //ロックオン処理
        RockOn();
        //弾発射処理
        if(is_bullet)
        {
            m_shot_time_cnt++;
            if(m_shot_time <= m_shot_time_cnt)
            {
                is_bullet = false;
                m_shot_time_cnt = 0;
            }
        }
        else
        {
            Shot();
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
            is_rotate = true;
        }
        else
        {
            is_rotate = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yaw = rot_speed;
            is_rotate = true;
        }
        else
        {
            is_rotate = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pitch = -1 * rot_speed;
            is_rotate = true;
        }
        else
        {
            is_rotate = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pitch = rot_speed;
            is_rotate = true;
        }
        else
        {
            is_rotate = false;
        }

        //回転の適用
        AddRot.eulerAngles = new Vector3(yaw, pitch, 0);
        transform.rotation *= AddRot;
    }

    private void RockOn()
    {
        //Xが押されている間ロックオン
        if (Input.GetKey(KeyCode.X))
        {
            is_rockon = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            is_rockon = false;
        }
    }

    private void Shot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //弾の数が最大なら発射しない
            if (Extension.SearchTagCount("Bullet") <= Bullet.max_bullet)
            {
                GameObject obj;
                //ロックオン時
                if (is_rockon)
                {
                    //弾の生成
                    obj = Instantiate(bullet, transform.position, transform.rotation);
                    //ロックオン状態にする
                    obj.GetComponent<Bullet>().Is_rockon = true;
                    obj.GetComponent<Bullet>().Target = transform.SearchNearTag("Enemy");
                }
                else
                {
                    //弾の生成
                    obj = Instantiate(bullet, transform.position, transform.rotation);
                }
                //プレイヤーの弾
                obj.GetComponent<Bullet>().Is_player = true;
                is_bullet = true;
            }
        }
    }

    public bool IsRockOn
    {
        get { return is_rockon; }
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
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameController.GameOver();
        }
    }
}
