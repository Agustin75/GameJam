using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverSound : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string HoverSoundEvent;
    FMOD.Studio.EventInstance HoverSound;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayUISound(string Sound)
    {
        HoverSound = FMODUnity.RuntimeManager.CreateInstance(HoverSoundEvent);
        HoverSound.start();
    }

    void test()
    {

    }
}
