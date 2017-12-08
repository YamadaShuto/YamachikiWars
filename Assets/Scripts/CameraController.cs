using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourCustom
{
    // Player object
    [SerializeField]
    private GameObject m_target;
    // Fixed distance
    [SerializeField]
    private Transform m_offset;
    
	// Update is called once per frame
	void LateUpdate ()
    {
        // If the player dose not alive
        if (m_target == null) return;
        Rotation();
        Move();
    }

    private void Move()
    {
        // Whether  it`s accelerating or not
        if(m_target.GetComponent<PlayerController>().IsBoost)
        {
            transform.position = Vector3.Lerp(transform.position, m_offset.position + new Vector3(0, 0, -1), Time.deltaTime * 5.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, m_offset.position, Time.deltaTime * 7.0f);
        }
    }

    private void Rotation()
    {
        // Look at the player
        transform.rotation = Quaternion.Lerp(transform.rotation, m_target.transform.rotation, Time.deltaTime * 10.0f);
    }
}
