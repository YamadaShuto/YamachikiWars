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
        transform.position = Vector3.Lerp(transform.position, m_offset.position, Time.deltaTime * 1.0f);
        if (m_target.GetComponent<PlayerController>().IsBoost)
        {
            transform.localPosition += new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f),0.0f);
        } 
    }

    private void Rotation()
    { 
        // Look at the player
        transform.rotation = Quaternion.Lerp(transform.rotation, m_offset.rotation, Time.deltaTime * 1.0f);
    }
}
