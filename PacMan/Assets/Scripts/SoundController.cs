using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    public Dictionary<string, AudioSource> Sounds = new Dictionary<string, AudioSource>();
    // Use this for initialization
    void Start () {
        LoadSounds();
    }

    void LoadSounds()
    {
        foreach (AudioSource audio in GetComponents<AudioSource>())
        {
            Sounds.Add(audio.clip.name, audio);
        }
    }

    public void StopLooped(string name)
    {
        if (Sounds[name].loop == true)
            Sounds[name].loop = false;
    }

    public void PlayLooped(string name)
    {
        Sounds[name].loop = true;
        Sounds[name].Play();
    }

    public void PlaySound(string name, bool replay = true)
    {
        if (replay == true)
        {
            if (!Sounds[name].isPlaying)
                Sounds[name].Play();
        }
    }
}
