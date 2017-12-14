using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text score;
    [SerializeField]
    private UnityEngine.UI.Text hp;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Image gauge_image;
    [SerializeField]
    private Image maker_image;
    [SerializeField]
    private Image boost_image;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        score.text = "残り敵数:" + Extension.SearchTagCount("Enemy").ToString();
        hp.text = "HP:" + player.HP.ToString() + " / 50";
        gauge_image.transform.localScale = new Vector3(player.HP / 50.0f, 0.3f, 1);
        if (player.HP < 12)
        {
            gauge_image.color = new Color(1.0f, 0.0f, 0.0f);
        }
        boost_image.transform.localScale = new Vector3(player.BoostCnt / 240.0f * 2, 0.05f, 0);
    }
}
