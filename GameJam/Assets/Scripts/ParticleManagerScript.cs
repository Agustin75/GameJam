using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerScript : MonoBehaviour {

    [SerializeField]
    GamePlayManager gameplayman;

    [SerializeField]
    ParticleSystem[] particles;
	// Use this for initialization
	void Start () {
        StartCoroutine(ColorParticles());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ColorParticles()
    {
        while (true)
        {
           
            float curr = gameplayman.GetCurrentScore();
            float goal = gameplayman.GetMaxScore();
            for (int i = 0; i < particles.Length; i++)
            {
                ParticleSystem.MainModule p = particles[i].main;
                p.simulationSpeed = (curr/goal)*2;
                switch (gameplayman.GetCurrentEmotion())
                {
                    case Utility.Emotions.Happiness:
                p.startColor = Color.Lerp(Color.white, Color.yellow, (curr/goal));
                        break;
                    case Utility.Emotions.Anger:
                        p.startColor = Color.Lerp(Color.white, Color.red, (curr / goal));
                        break;
                    case Utility.Emotions.Sadness:
                        p.startColor = Color.Lerp(Color.white, Color.blue, (curr / goal));
                        break;
                    case Utility.Emotions.Fear:
                        p.startColor = Color.Lerp(Color.white, Color.black, (curr / goal));
                        break;
                    default:
                        break;
                }
                
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
