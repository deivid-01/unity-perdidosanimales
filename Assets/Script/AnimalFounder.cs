﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFounder : MonoBehaviour
{

    public Animal[]animals;

    private List<int >idUsed=new List<int>();
    
    public int goldenId;

    void Start ()
    {

        SetAnimalId ();
        SetGoldenId ();
        GameEvent.instance.ChangeColor ( goldenId );
        GameEvent.instance.OnMouseOverAnimal += AnimalSelected;
    }

    private void AnimalSelected ( int id )
    {
        if ( id == goldenId )
        {
            Debug.Log ( "Encontraste al animal" );

        }
        else
        {
            Debug.Log ( "Ese no es el animal que buscas" );

        }
    }

    public void SetGoldenId () => goldenId = UnityEngine.Random.Range ( 0 , animals.Length);



    public void SetAnimalId ()
    {
        foreach ( Animal animal in animals )
        {
            animal.id = RandomId ();
        }
    }

    public int RandomId ()
    {


        var id =  ( int )  UnityEngine.Random.Range ( 0 , animals.Length);
        if ( !idUsed.Contains ( id ) )
        {
            idUsed.Add ( id );
            return id;
        }
        else
        {

            try
            {
                return RandomId ();
            }
            catch ( Exception exc )
            {
                Debug.Log ( exc.Message );
            }

        }

        return 0;
    }
 }
