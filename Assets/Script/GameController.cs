using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(1);
        }
		if(Extension.SearchTagCount("Enemy") == 0)
        {
            SceneManager.LoadScene(1);
        }
	}
}
