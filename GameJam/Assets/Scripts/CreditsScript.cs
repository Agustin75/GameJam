using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{

    public int level = 1;
    public float setTime = 5.0f;
    Camera c;
    float timer;

	// Use this for initialization
	void Start ()
    {

        c = GetComponent<Camera>();
        timer = 0.0f;

	}
	
	// Update is called once per frame
	void Update ()
    {

        timer += Time.deltaTime;
        if(timer > setTime)
        {
            Application.LoadLevel(level);
        }

	}
}
