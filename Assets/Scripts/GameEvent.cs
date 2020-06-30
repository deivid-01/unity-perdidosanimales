﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    #region Singlenton
    public static GameEvent instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion


    public event Action<int> OnMouseOverAnimal;

    public event Action<int> OnVerifiedAnimal;
    public event Action OnNextZone;

    public event Action <string  > OnAnswerAnimal;

    public event Action <bool>OnCheckedAnswer;

    public void MouseOverAnimal ( int id ) => OnMouseOverAnimal?.Invoke ( id );
    public void ChangeColor (int id) => OnVerifiedAnimal?.Invoke (id );

    public void AnswerAnimal ( string name ) => OnAnswerAnimal?.Invoke ( name );

    public void NextZone () => OnNextZone?.Invoke ();
    public  void CheckedAnswer ( bool ans ) => OnCheckedAnswer?.Invoke ( ans );
}
