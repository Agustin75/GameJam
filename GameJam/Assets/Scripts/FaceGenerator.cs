using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceGenerator : MonoBehaviour {

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
        name.text = firstnames[Random.Range(0,firstnames.Length)] + " " +surnames[Random.Range(0, surnames.Length)];

        //set hair
        hair.sprite = HairPool[Random.Range(0, HairPool.Length)];
        //set eyes
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].sprite = EyePool[Random.Range(0, EyePool.Length)];
        }
        //set eyebrows
        for (int i = 0; i < eyebrows.Length; i++)
        {
            eyebrows[i].sprite = EyebrowPool[Random.Range(0, EyebrowPool.Length)];
        }
        //set nose
        Nose.sprite = NosePool[Random.Range(0, NosePool.Length)];
        // set stache
        stache.sprite = StachePool[Random.Range(0,StachePool.Length)];
        //set mouth
        mouth.sprite = MouthPool[Random.Range(0, MouthPool.Length)];
    }
}
