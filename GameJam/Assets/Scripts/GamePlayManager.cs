using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {

	// Manager that is in charge of creating random questions and answers
	// public QuestionPull questionPull;

	public Button[] answerButtons;
	public Image scoreBar;

	private int numAnswers;

	//private Answers answers;

	// Use this for initialization
	void Start () {
		numAnswers = answerButtons.Length;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestion()
	{
		for (int i = 0; i < numAnswers; i++)
		{
			//answerButtons[i].text = answers[i].phrase;
		}
	}
}
