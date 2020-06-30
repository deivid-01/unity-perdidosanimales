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
       
    }

    public Sound[]narrativeQuestions;

    public Sound[]rightAnswers;

    public Sound[]wrongAnswers;
    void Awake()
    {
        SetSourceComponent ( narrativeQuestions );
        SetSourceComponent ( rightAnswers );
        SetSourceComponent ( wrongAnswers );

    }

    private void SetSourceComponent ( Sound [] sounds )
    {
        foreach ( Sound sound in sounds )
        {
            sound.source = gameObject.AddComponent<AudioSource> ();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
    }

    public void Play ( string name)
    {
        Sound s = Array.Find ( narrativeQuestions , sound => sound.name == name );

        s.source.Play ();
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
