using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Utility : MonoBehaviour {

	public enum emotions
    {
        Happy,Angry,Sadness,Fear
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
