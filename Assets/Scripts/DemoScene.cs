using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScene : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Text score;
    [SerializeField]
    private UnityEngine.UI.Text hp;
    [SerializeField]
    private PlayerController player;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
