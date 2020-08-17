using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera camera;
    public Transform [] storyPivotes;
    public Transform[]pivotes;
    public static  int pivoteActual;
    public float speed;
    [Range(1,20)]
    public int dist;

    private void Awake ()
    {
        pivoteActual = 0;
    }
    void Start ()
    {
        GameEvent.instance.OnNextZone += NextPivote;
        GameEvent.instance.OnNextPlace += NextPivote ;
    }

    public void NextPivote () { 
            pivoteActual = ( pivoteActual + 1 ) % pivotes.Length;

    }

    // Update is called once per frame
    void Update ()
    {
     
        
        if ( pivoteActual == 1 )
        {
            if ( ( camera.transform.position - pivotes [pivoteActual].position ).sqrMagnitude < dist )
            {
                NextPivote ();
                GameEvent.instance.InitZones ();
            }
        }
        
        
        camera.transform.position = Vector3.Lerp ( camera.transform.position , pivotes [pivoteActual].position , speed * Time.deltaTime );
        camera.transform.rotation = Quaternion.Lerp ( camera.transform.rotation , pivotes [pivoteActual].rotation , speed * Time.deltaTime );

        if ( Input.GetKeyDown ( KeyCode.RightArrow ) )
        {
            NextPivote ();
        }
    }
}
