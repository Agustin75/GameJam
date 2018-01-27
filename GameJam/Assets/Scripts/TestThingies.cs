using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThingies : MonoBehaviour {

    [SerializeField]
    int feeling;

    [SerializeField]
    Phrase curentphrase;
    [SerializeField]
    Phrase[] phrases = new Phrase[3];
    [SerializeField]
    WorldsPool worldspool;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           curentphrase = worldspool.GetRandomPhrase(feeling);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            phrases = worldspool.GetRandomPhrases(feeling);
        }
	}
}
