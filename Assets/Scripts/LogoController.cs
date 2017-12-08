using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviourCustom
{
    int frame_cnt = 0;
    // Update is called once per frame
    void Update()
    {
        frame_cnt++;
        if (frame_cnt >= 180)
            // Transition scenes
            SceneManager.LoadScene(1);
    }
}
