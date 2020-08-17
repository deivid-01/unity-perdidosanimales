using UnityEngine.Audio;
using UnityEngine;

using System;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound {
        public AudioClip clip;

        [Range(0,1)]
        public float volume;
        public string name;

        [HideInInspector]
        public AudioSource source;
    }


    private void Start ()
    {
        GameEvent.instance.OnAnswerAnimal += Play;
        GameEvent.instance.OnCheckedAnswer += Play;
        GameEvent.instance.OnTellIntro += PlayIntro;
        GameEvent.instance.OnPlayFinalMess += PlayFinal;
    }
    public void PlayFinal ()
    {
        finalMessage.source.Play ();
        Debug.Log ( "oliwis" );
    }


    public Sound[]narrativeQuestions;

    public Sound[]rightAnswers;

    public Sound[]wrongAnswers;

    public Sound intro;

    public Sound finalMessage;
    void Awake()
    {
        SetSourceComponent ( narrativeQuestions );
        SetSourceComponent ( rightAnswers );
        SetSourceComponent ( wrongAnswers );
        AddSoundComponent ( intro );
        AddSoundComponent ( finalMessage );
    }

    private void SetSourceComponent ( Sound [] sounds )
    {
        foreach ( Sound sound in sounds )
        {
            AddSoundComponent ( sound );
            
          
        }
    }

    private void AddSoundComponent ( Sound sound )
    {
        sound.source = gameObject.AddComponent<AudioSource> ();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
    }

    public void Play ( string name)
    {
        Sound s = Array.Find ( narrativeQuestions , sound => sound.name == name );

        s.source.Play ();
    }


    private void PlayIntro () {
        intro.source.Play ();

    }
    public void Play ( bool right) {
        if ( right )
        {
            rightAnswers [UnityEngine.Random.Range ( 0 , rightAnswers.Length )].source.Play ();
        }
        else if ( !right )
        {
            wrongAnswers [UnityEngine.Random.Range ( 0 , wrongAnswers.Length )].source.Play ();
        }
    }
}
