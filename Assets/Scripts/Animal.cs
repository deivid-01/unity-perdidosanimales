﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int id;
    bool isTheOne;

    private void Start ()
    {
        isTheOne = false;
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
        GameEvent.instance.MouseOverAnimal ( id );
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
        Gizmos.DrawWireSphere ( transform.position ,1);
        
    }
}