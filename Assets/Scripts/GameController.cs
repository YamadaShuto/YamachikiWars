using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourCustom
{
    public GameObject enemy;

    [SerializeField]
    private UnityEngine.UI.Text score;
    [SerializeField]
    private UnityEngine.UI.Text hp;
    [SerializeField]
    private PlayerController player;

    // Use this for initialization
    void Start ()
    {
        // Create enemy
        for (int i = 0; i < 10; i++)
        {
            // Setting position
            int num = Random.Range(0, 1);
            Vector3 pos = Vector3.zero;
            if (num == 1)
            {
                pos.x = Random.Range(40, 100);
                pos.y = Random.Range(40, 100);
                pos.z = Random.Range(40, 100);
            }
            else
            {
                pos.x = Random.Range(-40, -100);
                pos.y = Random.Range(-40, -100);
                pos.z = Random.Range(-40, -100);
            }
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
        score.text = "残り敵数:" + Extension.SearchTagCount("Enemy").ToString();
        hp.text = "PlayerHP:" + player.HP.ToString();
	}

    static public void GameOver()
    {
        SceneManager.LoadScene(4);
    }
}
