using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour {

    [SerializeField]
    Sprite[] bodies;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = bodies[Random.Range(0, bodies.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
