using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int id;
    bool isTheOne;
    bool touchAlready;

    private void Awake ()
    {
        isTheOne = false;
        touchAlready = false;
    }

    private void Start ()
    {
        GameEvent.instance.OnVerifiedAnimal += IsTheOne;
       
    }

    public  void IsTheOne (int id) {
        if ( id == this.id )
        {
            isTheOne = true;
          
        }
      
        
    }
    private void OnMouseDown ()
    {
        if ( !touchAlready )
        { 
        GameEvent.instance.MouseOverAnimal ( id );

       
        touchAlready = true;
        
        }
        this.GetComponent<AudioSource> ().Play ();
      //  this.GetComponent<Collider> ().enabled = false;
    }

    private void OnDrawGizmos ()
    {
        if ( isTheOne )
        {
            Gizmos.color = Color.green;
        }
        else
        { 
            Gizmos.color = Color.red;
        }
        Gizmos.DrawSphere ( transform.position ,1);
        
    }
}
