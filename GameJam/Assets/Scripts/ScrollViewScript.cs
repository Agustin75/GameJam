using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollViewScript : MonoBehaviour {

    [SerializeField]
    Scrollbar scr;
    public void ChangeObjectState( bool activeness)
    {
        scr.value = 1;
        gameObject.SetActive(activeness);
        scr.value = 1;
    }
}
