using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourCustom : MonoBehaviour
{
    private Transform m_transform;
    private Rigidbody m_rigidbody;

	//Transformコンポーネントを返す
    public new Transform transform
    {
        get
        {
            if(m_transform == null)
            {
                m_transform = GetComponent<Transform>();
            }
            return m_transform;
        }
    }
    
    //Rigidbodyコンポーネントを返す
    public new Rigidbody rigidbody
    {
        get
        {
            if (m_rigidbody == null)
            {
                m_rigidbody = GetComponent<Rigidbody>();
            }
            return m_rigidbody;
        }
    }
    
}
