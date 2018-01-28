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
	public Text currentDayText;
	public Text playerSpeech;
	public Image scoreBar;
	public Image requiredEmotionImage;
	public Sprite[] emotionFaces;

	// Private Members
	private int requiredScore, maxScore;
	private int currentScore, correctScore, wrongScore;
	private int numAnswers;
	private int numQuestions, currQuestion;
	private int currentDay;
	private Utility.Emotions requiredEmotion;
   
	private Phrase[] answers;
	private int numDays;
	private bool playerAnswered;

    public Utility.Emotions GetCurrentEmotion()
    {
        return requiredEmotion;
    }
    public int getCurrentScore()
    {
        return currentScore;
    }
    public int getMaxScore()
    {
        return maxScore;
    }
    // Use this for initialization
    void Start()
	{
		playerAnswered = false;
		currentScore = currQuestion = currentDay = 0;
		requiredEmotion = (Utility.Emotions)Random.Range(0, System.Enum.GetValues(typeof(Utility.Emotions)).Length);

		numDays = PlayerPrefs.GetInt("NumDays");
		maxScore = PlayerPrefs.GetInt("MaxScore");
		requiredScore = PlayerPrefs.GetInt("RequiredScore");

		ResetValues();

		ShowQuestion(true);
	}

	public bool NewDay()
	{
		playerAnswered = false;
		currentDay++;
		currQuestion = 0;

		if (currentDay == numDays)
		{
			if (currentScore >= requiredScore)
			{
				// Game Won
				Debug.Log("Win");
				ShowQuestion(false);
				return false;
			}
			else
			{
				// Game Lost
				Debug.Log("Loss");
				ShowQuestion(false);
				return false;
			}
		}

		ResetValues();

		return true;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerAnswered)
		{
			if(Input.GetMouseButtonDown(0))
			{
				playerAnswered = false;
				NextQuestion();
				playerSpeech.gameObject.SetActive(false);
			}
		}
	}

	public void ShowQuestion(bool show)
	{
		answers = phrasePools.GetRandomPhrases(requiredEmotion);

		for (int i = 0; i < numAnswers; i++)
		{
			answerButtons[i].gameObject.SetActive(show);
			if (show)
			{
				answerTexts[i].text = answers[i].GetAnswerPhrase();
			}
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

		playerAnswered = true;

		playerSpeech.text = answers[answer].GetPhrase();
		playerSpeech.gameObject.SetActive(true);

		ShowQuestion(false);
	}

	// Function that handles moving on to the next question. Call after showing audience feedback
	public void NextQuestion()
	{
		currQuestion++;
		if (currQuestion == numQuestions)
		{
			if (NewDay() == false)
				return;
		}

		ShowQuestion(true);
	}

	public void ResetValues()
	{
		currentDayText.text = "Day " + (currentDay + 1).ToString();

		numQuestions = PlayerPrefs.GetInt("NumQuestions" + currentDay);
		numAnswers = PlayerPrefs.GetInt("NumAnswers" + currentDay);
		requiredEmotion = (Utility.Emotions)Random.Range(0, System.Enum.GetValues(typeof(Utility.Emotions)).Length);
		correctScore = PlayerPrefs.GetInt("CorrectScore" + currentDay);
		wrongScore = PlayerPrefs.GetInt("WrongScore" + currentDay);

		requiredEmotionImage.sprite = emotionFaces[(int)requiredEmotion];
		switch (requiredEmotion)
		{
			case Utility.Emotions.Happiness:
				requiredEmotionImage.color = Color.yellow;
				break;
			case Utility.Emotions.Anger:
				requiredEmotionImage.color = Color.red;
				break;
			case Utility.Emotions.Sadness:
				requiredEmotionImage.color = Color.blue;
				break;
			case Utility.Emotions.Fear:
				requiredEmotionImage.color = Color.gray;
				break;
		}
	}
}
