using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulink : MonoBehaviourCustom
{
    private float m_next_time;
    [SerializeField]
    private float m_interval;

	// Use this for initialization
	void Start ()
    {
        m_next_time = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time > m_next_time)
        {
            if(GetComponent<CanvasRenderer>().GetAlpha() > 0.0f)
            {
                GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            } 
            else
            {
                GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            }
            m_next_time += m_interval;
        }
	}
}
