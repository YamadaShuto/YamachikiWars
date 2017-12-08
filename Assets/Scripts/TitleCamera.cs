using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    private Vector3 m_rotate;
	
	// Update is called once per frame
	void Update ()
    {
        m_rotate.x += 0.02f;
        m_rotate.y += 0.02f;
        transform.localEulerAngles = m_rotate;
	}
}
