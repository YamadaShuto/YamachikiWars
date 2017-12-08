using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFront : MonoBehaviour
{
    int frame = 0;
    [SerializeField]
    Vector2 target_pos;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(frame >= 160)
        {
            Destroy(this.gameObject);
        }
        target_pos.x = transform.localPosition.x;
        target_pos.x += 3.3f;
        transform.localPosition = target_pos;
        frame++;
	}
}
