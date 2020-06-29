
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFounder : MonoBehaviour
{

    public Animal[]animals;

    private List<int >idUsed=new List<int>();
    
    public int goldenId=-1;


    private void Awake ()
    {
        SetAnimalId ();
        SetGoldenId ();
    }
    private void OnEnable ()
    {
        SetGoldenId ();

    }
    private void OnDisable ()
    {
        goldenId = -1;
    }
    void Start ()
    {

     
        GameEvent.instance.ChangeColor ( goldenId );
        GameEvent.instance.OnMouseOverAnimal += AnimalSelected;
     
    }

    private void AnimalSelected ( int id )
    {
        Debug.Log ( goldenId +"<-gold|id->"+ id );
        if ( id == goldenId )
        {
            Debug.Log ( "Encontraste al animal" );
            //Poner corrutina 
            GameEvent.instance.NextZone ();

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
