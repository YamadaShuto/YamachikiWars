using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = Vector3.zero;
    private Vector3 newPosition;

    // Use this for initialization
    void Start ()
    {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        newPosition = transform.position;

        newPosition.x = player.transform.position.x + offset.x;
        newPosition.y = player.transform.position.y + offset.y;
        newPosition.z = player.transform.position.z + offset.z;

        transform.position = Vector3.Lerp(transform.position, newPosition, 2.0f * Time.deltaTime);
    }
}
