using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceGenerator : MonoBehaviour {

    [SerializeField]
    bool FirstScene = false;

    [SerializeField]
    Image hair;
    [SerializeField]
    Image[] eyebrows;
    [SerializeField]
    Image[] eyes;
    [SerializeField]
    Image Nose;
    [SerializeField]
    Image stache;
    [SerializeField]
    Image mouth;
    [SerializeField]
    Text name;

    string[] firstnames;
    string[] surnames;

    [SerializeField]
    Sprite[] HairPool;
    [SerializeField]
    Sprite[] EyePool;
    [SerializeField]
    Sprite[] EyebrowPool;
    [SerializeField]
    Sprite[] NosePool;
    [SerializeField]
    Sprite[] StachePool;
    [SerializeField]
    Sprite[] MouthPool;


    private void Start()
    {
       

        //set names
        TextAsset tfn = Resources.Load<TextAsset>("names");
        firstnames = tfn.text.Split('\n');
        TextAsset tln = Resources.Load<TextAsset>("surnames");
        surnames = tln.text.Split('\n');

        if (FirstScene)
        {

        Generatefaceandname();
        }
        else
        {
            LoadFace();
        }
        
    }

    void LoadFace()
    {
        //retrieve exisiting data
        hair.sprite = HairPool[PlayerPrefs.GetInt("Hair")];
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].sprite = EyePool[PlayerPrefs.GetInt("Eye")];
            eyebrows[i].sprite = EyebrowPool[PlayerPrefs.GetInt("EyeBrow")];
        }

        Nose.sprite = NosePool[PlayerPrefs.GetInt("Nose")];
        stache.sprite = StachePool[PlayerPrefs.GetInt("Stache")];
        mouth.sprite = MouthPool[PlayerPrefs.GetInt("Mouth")];
        name.text = firstnames[PlayerPrefs.GetInt("name")] + " ";
        name.text += surnames[PlayerPrefs.GetInt("surname")];
    }

    void Generatefaceandname()
    {
        int randname = Random.Range(0, firstnames.Length);
        PlayerPrefs.SetInt("name", randname);

        int randsurname = Random.Range(0, surnames.Length);
        PlayerPrefs.SetInt("surname", randsurname);
        name.text = firstnames[randname] + " " + surnames[randsurname];

        //set hair
        int randHair = Random.Range(0, HairPool.Length);
        PlayerPrefs.SetInt("Hair", randHair);
        hair.sprite = HairPool[randHair];
        //set eyes and eyebrows
            int randEye = Random.Range(0, EyePool.Length);
            PlayerPrefs.SetInt("Eye", randEye);
            int randEyebrow = Random.Range(0, EyebrowPool.Length);
            PlayerPrefs.SetInt("Eyebrow", randEyebrow);
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].sprite = EyePool[randEye];

            eyebrows[i].sprite = EyebrowPool[randEyebrow];
        }

        //set nose
        int randnose = Random.Range(0, NosePool.Length);
        PlayerPrefs.SetInt("Nose", randnose);
        Nose.sprite = NosePool[randnose];
        // set stache
        int randstache = Random.Range(0, StachePool.Length);
        PlayerPrefs.SetInt("Stache", randstache);
        stache.sprite = StachePool[randstache];
        //set mouth
        int randmouth = Random.Range(0, MouthPool.Length);
        PlayerPrefs.SetInt("Mouth", randmouth);
        mouth.sprite = MouthPool[randmouth];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Generatefaceandname();
        }
    }
}
