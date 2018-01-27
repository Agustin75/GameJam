using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
	// Manager that is in charge of creating random questions and answers
	public WorldsPool phrasePools;

	// Public Members
	public Button[] answerButtons;
	public Text[] answerTexts;
	public Image scoreBar;
	public int requiredScore, maxScore;

	// Private Members
	// TODO: Change back to private (public for Debug)
	public int currentScore, correctScore, wrongScore;
	public int numAnswers;
	public int numQuestions, currQuestion;
	private Utility.Emotions requiredEmotion;
	private Phrase[] answers;
	public int numDays;

	private int currentDay;
	// Use this for initialization
	void Start()
	{
		currentScore = currQuestion = currentDay = 0;
		requiredEmotion = (Utility.Emotions)Random.Range(0, System.Enum.GetValues(typeof(Utility.Emotions)).Length);
		//numAnswers = answerButtons.Length;

		// TODO: REMOVE DEBUG CODE
		ShowQuestion(true);
	}

	public void NewDay(int _requiredScore, int _correctScore, int _wrongScore, int _numQuestions, int _numAnswers = 3)
	{
		currentDay++;
		currQuestion = 0;
		numQuestions = _numQuestions;
		numAnswers = _numAnswers;
		requiredScore = _requiredScore;
		requiredEmotion = (Utility.Emotions)Random.Range(0, System.Enum.GetValues(typeof(Utility.Emotions)).Length);
		correctScore = _correctScore;
		wrongScore = _wrongScore;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowQuestion(bool show)
	{
		answers = phrasePools.GetRandomPhrases(requiredEmotion);

		for (int i = 0; i < numAnswers; i++)
		{
			answerButtons[i].gameObject.SetActive(show);
			if (show)
				answerTexts[i].text = answers[i].GetPhrase();
		}
	}

	// Handles what happens when the player chooses an answer
	public void AnswerChosen(int answer)
	{
		// If they chose the correct answer
		if (answers[answer].GetFeelingID() == requiredEmotion)
		{
			// Increase their score
			currentScore += correctScore;
		}
		else
		{
			// Decrease their score if it is higher than 0
			if (currentScore > 0)
				currentScore -= wrongScore;

			// Set the score to 0 if its negative
			if (currentScore < 0)
				currentScore = 0;
		}
		// Change the bar accordingly
		scoreBar.fillAmount = (float)currentScore / maxScore;

		// TODO: REMOVE DEBUG CODE
		NextQuestion();
	}

	// Function that handles moving on to the next question. Call after showing audience feedback
	public void NextQuestion()
	{
		currQuestion++;
		if (currQuestion == numQuestions)
		{
			// NewDay();
			if (currentScore >= requiredScore)
			{
				// Game Won
				Debug.Log("Win");
				ShowQuestion(false);
				return;
			}
			else
			{
				// Game Lost
				Debug.Log("Loss");
				ShowQuestion(false);
				return;
			}
		}
		// TODO: REMOVE DEBUG CODE
		ShowQuestion(true);
	}
}
