using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f,10.0f),Random.Range(-10.0f,10.0f), Random.Range(-10.0f, 10.0f));
        Instantiate(enemy,pos, Quaternion.identity);
        

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
