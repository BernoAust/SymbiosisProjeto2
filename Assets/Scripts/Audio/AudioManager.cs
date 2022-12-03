using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public List<Sound> sounds = new List<Sound>();

    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }

        AudioEvent.playAudio.AddListener(Play);
        AudioEvent.stopAudio.AddListener(Stop);
            
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if(sound == null)
        {
            Debug.LogWarning($"Sound {name} not found.");
        }

        if(sound.source.isPlaying)
        {
            Stop(name);
        }

        sound.source.Play();

    }

    public void Stop(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound {name} not found.");
        }

        sound.source.Stop();
    }

}
