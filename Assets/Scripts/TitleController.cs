using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene(5);
        }
    }
}
