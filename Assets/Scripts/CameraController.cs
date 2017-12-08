using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourCustom
{
    [SerializeField]
    // Player object
    private GameObject player;
    [SerializeField]
    private Transform offset;
    /*
    private float distance = 4.0f;
    private float height = 2.0f;
    private float speed = 2.0f;
    */
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (player == null) return;
        Rotation();
        Move();
       
    }

    private void Move()
    {
        if(player.GetComponent<PlayerController>().IsBoost)
        {

            transform.position = Vector3.Lerp(transform.position, offset.position + new Vector3(0, 0, -1), Time.deltaTime * 5.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, offset.position, Time.deltaTime * 7.0f);
        }
    }

    private void Rotation()
    {
        //プレイヤーの方を向く
       // transform.rotation = player.transform.localRotation;
        //Quaternion target_rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime * 10.0f);
    }
}
