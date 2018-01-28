using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsPool : MonoBehaviour {

    [SerializeField]
    Phrase[] HappyPhrases;
    [SerializeField]
    Phrase[] AngryPhrases;
    [SerializeField]
    Phrase[] SadPhrases;
    [SerializeField]
    Phrase[] FearPhrases;

    List<Phrase[]> Feelings = new List<Phrase[]>();

    private void Start()
    {
       // DontDestroyOnLoad(this.gameObject);

        Feelings.Add(HappyPhrases);
        Feelings.Add(AngryPhrases);
        Feelings.Add(SadPhrases);
        Feelings.Add(FearPhrases);
    }

    public Phrase GetRandomPhrase(Utility.Emotions feeling) {
        Phrase temp = new Phrase();
        switch (feeling)
        {
            case Utility.Emotions.Happiness:
                temp = HappyPhrases[Random.Range(0, HappyPhrases.Length)];
                break;
            case Utility.Emotions.Anger:
                temp = AngryPhrases[Random.Range(0, AngryPhrases.Length)];
                break;
            case Utility.Emotions.Sadness:
                temp = SadPhrases[Random.Range(0, SadPhrases.Length)];
                break;
            case Utility.Emotions.Fear:
                temp = FearPhrases[Random.Range(0, FearPhrases.Length)];
                break;
        }
        return temp;
    }
    int ramdomizeForEva(Utility.Emotions notThisNumber)
    {
        int returnthisnumber = 0;
        do
        {
            returnthisnumber = Random.Range(0, 4);
        } while (returnthisnumber == (int)notThisNumber);

        return returnthisnumber;
    }

    void swapLocalArray(Phrase[] _temp, int indexa, int indexb)
    {
        Phrase a = _temp[indexa];
        _temp[indexa] = _temp[indexb];
        _temp[indexb] = a;
    }

    public Phrase[] GetRandomPhrases(Utility.Emotions feelingID)
    {
        Phrase[] temp = new Phrase[3];
		int randEmotion = (int)feelingID, index = 0;
		Phrase previousPhrase = new Phrase();

		while (index < 3)
		{
			temp[index] = GetRandomPhrase((Utility.Emotions)randEmotion);

			if (index == 0 || !(previousPhrase.GetAnswerPhrase().Equals(temp[index].GetAnswerPhrase())))
			{
				previousPhrase = temp[index];
				index++;
			}

			while (randEmotion == (int)feelingID)
				randEmotion = Random.Range(0, System.Enum.GetValues(typeof(Utility.Emotions)).Length);
		}

		for (int i = 0; i < 5; i++)
		{
			swapLocalArray(temp, Random.Range(0, 3), Random.Range(0, 3));
		}
		return temp;
    }

}

[System.Serializable]
public struct Phrase
{
    [SerializeField]
    string shortVersion;
	[SerializeField]
	string phrase;
	[SerializeField]
    Utility.Emotions feelingID;

	public string GetAnswerPhrase()
	{
		return shortVersion;
	}
	public string GetPhrase()
    {
        return phrase;
    }
    public Utility.Emotions GetFeelingID()
    {
        return feelingID;
    }
}
