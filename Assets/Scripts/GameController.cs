using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourCustom
{
    public GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        // Create enemy
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.x = Extension.RandumRange(80, 150, -80, -150);
            pos.y = Extension.RandumRange(80, 150, -80, -150);
            pos.z = Extension.RandumRange(80, 150, -80, -150);
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Extension.SearchTagCount("Enemy") == 0)
        {
            SceneManager.LoadScene(3);
        }
	}

    static public void GameOver()
    {
        SceneManager.LoadScene(4);
    }   
}