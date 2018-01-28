using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour {

    [FMODUnity.EventRef]
    public string PlayerStateEvent;
    //public static FMOD.Studio.Bus GetBus(String path);
    FMOD.Studio.EventInstance playerState;
    FMOD.Studio.Bus playerBus;



	// Use this for initialization
	void Start () {
		
        playerState = FMODUnity.RuntimeManager.CreateInstance(PlayerStateEvent);
        playerState.start();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        StopAllPlayerEvents();

        //--------------------------------------------------------------------
        // 6: This shows how to release resources when the unity object is 
        //    disabled
        //--------------------------------------------------------------------
        playerState.release();
    }


    void StopAllPlayerEvents()
    {
        playerBus = FMODUnity.RuntimeManager.GetBus("bus:/player");
        //playerState.stop(STOP);
    }
}

