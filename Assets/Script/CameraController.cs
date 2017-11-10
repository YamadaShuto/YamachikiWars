using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourCustom
{
    private GameObject player;
    private float angle;
    private Vector3 pos;

    private Transform target;
    [SerializeField]
    private Transform maker;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = Vector3.zero;

        newPosition.x = player.transform.position.x;
        newPosition.y = player.transform.position.y;
        newPosition.z = player.transform.position.z;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 3.0f);

       //if(Input.GetKey(KeyCode.X))
        {
            //Vector3 direction = transform.SearchNearTag("Enemy").transform.position - transform.position;
            //Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2.0f * Time.deltaTime);

            //transform.LookAt(transform.SearchNearTag("Enemy").transform);
        }
        //else
        {
            transform.LookAt(transform.SearchNearTag("Player").transform);
        }
    }

    private void LockOn()
    {

    }
}
