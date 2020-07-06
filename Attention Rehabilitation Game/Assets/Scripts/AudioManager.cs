using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [HideInInspector]
    public Sound[] sounds;

    public Sound[] level5sounds;
    public Sound[] level5distractions;

    public Sound[] level7sounds;
    public Sound[] level7distractions;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
           instance = this;
        }

        Level level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

        

       // sounds = (level.Equals(Level.level5) || level.Equals(Level.level6)) ? level5sounds.Concat(level5distractions).ToArray() : level7sounds.Concat(level7distractions).ToArray();

        var myList = new List<Sound>();

        if(level.Equals(Level.level5) || level.Equals(Level.level6)){
            myList.AddRange(level5sounds);
            myList.AddRange(level5distractions);
            Debug.Log("level5 or six");
        }
        if(level.Equals(Level.level7) || level.Equals(Level.level8)){
            myList.AddRange(level7sounds);
            myList.AddRange(level7distractions);
        }
        
        sounds = myList.ToArray();


        Debug.Log("SOunds ength " +sounds.Length);

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.name = s.name;
            Debug.Log(s.name);

        }
        
    }


    public List<string> getSounds(Level level)
    {

        IList<string> soundNames = new List<string>();
        Sound[] sounds = (level.Equals(Level.level5) || level.Equals(Level.level6)) ? level5sounds : level7sounds;

        foreach (Sound s in sounds)
        {
            soundNames.Add(s.name);
        }
            return (List<string>)soundNames;
    }

    public List<string> getDistractions(Level level)
    {

        IList<string> soundNames = new List<string>();

        Sound[] sounds = (level.Equals(Level.level5) || level.Equals(Level.level6)) ? level5distractions : level7distractions;

        foreach (Sound s in sounds)
        {
            soundNames.Add(s.name);
        }
        return (List<string>)soundNames;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
        
    }
}
