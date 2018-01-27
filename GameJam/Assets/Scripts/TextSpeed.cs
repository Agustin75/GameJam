using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpeed : MonoBehaviour {

    [SerializeField]
    float TimeBetweenLetters;
    [SerializeField]
    Text textToanimate;
    //Text t;

    string originaltext;
    string textdisplay;
	// Use this for initialization
	void Start () {
       // textToanimate = GetComponent<Text>();
        originaltext = textToanimate.text;
        textToanimate.text = "";
	}

    public void Animate()
    {
        StartCoroutine(AnimateText());
        
    }
    public IEnumerator AnimateText() {
        for (int i = 0; i < originaltext.Length; i++)
        {
            textToanimate.text += originaltext[i];
          
        yield return new WaitForSeconds(TimeBetweenLetters);


        }

        Utility.LoadSceneA("Pablo Scene");

        
    }
	

}
