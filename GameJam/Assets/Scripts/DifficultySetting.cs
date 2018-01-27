using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetting : MonoBehaviour
{
	public enum Difficulties { Easy, Normal, Hard }

	[System.Serializable]
	public struct DaySettings
	{
		public int numQuestions;
		public int numAnswers;
		public int correctScore;
		public int wrongScore;
	}

	[System.Serializable]
	public struct Setting
	{
		public int numDays;
		public int requiredScore;
		public int maxScore;
		public DaySettings[] daySettings;
	}

	[Header("Normal Settings")]
	public Setting normalSettings;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SelectDifficulty(int difficulty)
	{
		if (difficulty == (int)Difficulties.Normal)
		{
			PlayerPrefs.SetInt("NumDays", normalSettings.numDays);
			PlayerPrefs.SetInt("RequiredScore", normalSettings.requiredScore);
			PlayerPrefs.SetInt("MaxScore", normalSettings.maxScore);
			for (int i = 0; i < normalSettings.numDays; i++)
			{
				PlayerPrefs.SetInt("NumQuestions" + i, normalSettings.daySettings[i].numQuestions);
				PlayerPrefs.SetInt("NumAnswers" + i, normalSettings.daySettings[i].numAnswers);
				PlayerPrefs.SetInt("CorrectScore" + i, normalSettings.daySettings[i].correctScore);
				PlayerPrefs.SetInt("WrongScore" + i, normalSettings.daySettings[i].wrongScore);
			}
		}
	}
}
