using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Utility : MonoBehaviour {

	public enum Emotions
    {
		Happiness, Anger, Sadness,Fear
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    
}
