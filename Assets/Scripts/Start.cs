using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject UIStart;

    // Update is called once per frame
    void Update()
    {
        if ( Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            GameEvent.instance.TellIntro ();
            GameEvent.instance.NextPlace ();
            UIStart.SetActive ( false );
            //DisableUI;
            gameObject.SetActive ( false );
        }
    }
}
