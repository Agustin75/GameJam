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
        DontDestroyOnLoad(this.gameObject);

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
                temp = HappyPhrases[Random.Range(0, HappyPhrases.Length - 1)];
                break;
            case Utility.Emotions.Anger:
                temp = AngryPhrases[Random.Range(0, AngryPhrases.Length - 1)];
                break;
            case Utility.Emotions.Sadness:
                temp = SadPhrases[Random.Range(0, SadPhrases.Length - 1)];
                break;
            case Utility.Emotions.Fear:
                temp = FearPhrases[Random.Range(0, FearPhrases.Length - 1)];
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
        
        switch (feelingID)
        {
            case Utility.Emotions.Happiness:
                {
                    temp[0] = HappyPhrases[Random.Range(0, HappyPhrases.Length - 1)];

                    int randomtemp = ramdomizeForEva(feelingID);
                    temp[1] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    randomtemp = ramdomizeForEva(feelingID);
                    temp[2] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    for (int i = 0; i < 5; i++)
                    {
                        swapLocalArray(temp, Random.Range(0,3), Random.Range(0, 3));
                    }
                    return temp;
                }
            case Utility.Emotions.Anger:
                {
                    temp[0] = AngryPhrases[Random.Range(0, AngryPhrases.Length - 1)];

                    int randomtemp = ramdomizeForEva(feelingID);
                    temp[1] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    randomtemp = ramdomizeForEva(feelingID);
                    temp[2] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    for (int i = 0; i < 5; i++)
                    {
                        swapLocalArray(temp, Random.Range(0, 3), Random.Range(0, 3));
                    }

                    return temp;
                }
            case Utility.Emotions.Sadness:
                {

                temp[0] = SadPhrases[Random.Range(0, SadPhrases.Length - 1)];

                int randomtemp = ramdomizeForEva(feelingID);
                temp[1] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                randomtemp = ramdomizeForEva(feelingID);
                temp[2] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    for (int i = 0; i < 5; i++)
                    {
                        swapLocalArray(temp, Random.Range(0, 3), Random.Range(0, 3));
                    }

                    return temp;
                }
            case Utility.Emotions.Fear:
                {

                temp[0] = FearPhrases[Random.Range(0, FearPhrases.Length - 1)];

                int randomtemp = ramdomizeForEva(feelingID);
                temp[1] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                randomtemp = ramdomizeForEva(feelingID);
                temp[2] = Feelings[randomtemp][Random.Range(0, Feelings[randomtemp].Length)];

                    for (int i = 0; i < 5; i++)
                    {
                        swapLocalArray(temp, Random.Range(0, 3), Random.Range(0, 3));
                    }

                    return temp;
                }
            default:
                break;
        }
        return null;
    }

}

[System.Serializable]
public struct Phrase
{
    [SerializeField]
    string phrase;
    [SerializeField]
    Utility.Emotions feelingID;

    public string GetPhrase()
    {
        return phrase;
    }
    public Utility.Emotions GetFeelingID()
    {
        return feelingID;
    }
}
