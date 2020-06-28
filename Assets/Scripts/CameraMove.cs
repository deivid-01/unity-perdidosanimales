using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera camera;
    public Transform[]pivotes;
    public int pivoteActual;
    public float speed;
    void Start ()
    {
        GameEvent.instance.OnNextZone += NextPivote;
        pivoteActual = 0;
    }

    public void NextPivote () { 
            pivoteActual = ( pivoteActual + 1 ) % pivotes.Length;

    }

    public void PreviewPivote () {
        pivoteActual = ( pivoteActual - 1 );

        if ( pivoteActual < 0 )
        {
            pivoteActual = pivotes.Length - 1;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        camera.transform.position = Vector3.Lerp ( camera.transform.position , pivotes [pivoteActual].position , speed*Time.deltaTime );
        camera.transform.rotation = Quaternion.Lerp ( camera.transform.rotation , pivotes [pivoteActual].rotation , speed*Time.deltaTime );

        if ( Input.GetKeyDown ( KeyCode.RightArrow ) )
        {
            NextPivote ();
           
        }
        else if ( Input.GetKeyDown ( KeyCode.LeftArrow ) )
        {
            PreviewPivote ();
        }
    }
}
