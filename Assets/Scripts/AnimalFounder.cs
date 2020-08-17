
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

    private void OnDisable ()
    {
        goldenId = -1;
    }
    IEnumerator Start ()
    {

        yield return new WaitForSeconds ( 0.001f );
        GameEvent.instance.ChangeColor ( goldenId );
        GameEvent.instance.OnMouseOverAnimal += AnimalSelected;

        QuestionAnimal ();
    }

    public void QuestionAnimal ()
    {

        foreach ( Animal anim in animals )
        {
            if ( anim.id.Equals ( goldenId ) )
            {
                GameEvent.instance.AnswerAnimal ( anim.gameObject.name );
                return;
            }
        }

    }
    private void AnimalSelected ( int id )
    {
        if(gameObject.activeInHierarchy)
            StartCoroutine ( Check ( id ) );

    }

    private IEnumerator Check ( int id )
    {
        yield return new WaitForSeconds ( 1.0f );

        if ( id == goldenId )
        {
            GameEvent.instance.CheckedAnswer ( true );
            yield return new WaitForSeconds ( 0.9f );
            GameEvent.instance.NextZone ();
        }
        else
        {
            GameEvent.instance.CheckedAnswer ( false );
        }
    }

    public void SetGoldenId () => goldenId = UnityEngine.Random.Range ( 0 , animals.Length );



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
