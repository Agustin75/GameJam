using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpeed : MonoBehaviour
{
	[SerializeField]
	float TimeBetweenLetters;
	[SerializeField]
	Text textToanimate;
	[SerializeField]
	Image textBox;
	[SerializeField]
	string newScene;

	string originaltext;
	string textdisplay;

	// Use this for initialization
	void Start()
	{
		originaltext = textToanimate.text;
		textToanimate.text = "";
	}

	public void Animate()
	{
		textBox.gameObject.SetActive(true);
		StartCoroutine(AnimateText());
	}

	public IEnumerator AnimateText()
	{
		for (int i = 0; i < originaltext.Length; i++)
		{
			textToanimate.text += originaltext[i];

			yield return new WaitForSeconds(TimeBetweenLetters);
		}

		for (int i = 0; i < 3; i++)
		{
			yield return new WaitForSeconds(1f);
		}

		Utility.LoadSceneA(newScene);
	}
}
