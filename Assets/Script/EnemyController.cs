using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.3f;
    //public const int 

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Move();
	}

    private void Move()
    {
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
    }

}
