using System;
using UnityEngine;

public class VoiceSubController : MonoBehaviour
{
    public  AudioSource audioSource;
    //public MOBController mobController;

    public int PlayVoice(string clip)
    {        
        int delay = 1000;
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/"+MOBController.currentDirectoryAudios+"/"+clip);
        audioSource.clip = audioClip;
        print("playing... "+ audioClip.name);
        
        audioSource.Play();
        if(audioClip != null)
        {
            delay = int.Parse(""+(Convert.ToInt32(audioSource.clip.length*1000)));
        }

        return delay;
    }
}
