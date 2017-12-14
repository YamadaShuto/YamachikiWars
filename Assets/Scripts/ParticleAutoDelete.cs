using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDelete : MonoBehaviourCustom
{
	// Use this for initialization
	void Start ()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
