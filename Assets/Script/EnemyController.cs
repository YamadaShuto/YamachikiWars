using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.9f;
    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
       // Move();
	}

    private void Move()
    {
        transform.LookAt(player.transform);
        //向いている正面に一定速度移動
        transform.Translate(Vector3.forward * Time.deltaTime * speed );
    }
    
    private void OnBecameInvisible()
    {
        enabled = true;
    }
    private void OnBecameVisible()
    {
        enabled = false;
    }
}
