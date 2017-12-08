using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScene : MonoBehaviourCustom
{
    [SerializeField]
    private UnityEngine.UI.Text score;
    [SerializeField]
    private UnityEngine.UI.Text hp;
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        // The enemy count is 0
        if (Extension.SearchTagCount("Enemy") == 0)
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
