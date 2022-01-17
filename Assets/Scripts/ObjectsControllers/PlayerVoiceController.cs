using System;
using UnityEngine;

public class PlayerVoiceController : MonoBehaviour
{
    static AudioSource audioSource;

    public BoxCollider TPMesa;
    public BoxCollider TPCentro;
    public BoxCollider TPDer;

    //Se inicializan los sonidos usando variables AudioClip y los audios guardados en Resources/audios/
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if(GameObject.Find("TPPoint0")!=null)
        {
            Physics.IgnoreCollision(GameObject.Find("TPPoint0").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
            Physics.IgnoreCollision(GameObject.Find("TPPoint1").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
            Physics.IgnoreCollision(GameObject.Find("TPPoint2").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
            Physics.IgnoreCollision(GameObject.Find("TPPoint3").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
            Physics.IgnoreCollision(GameObject.Find("TPPoint4").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
            Physics.IgnoreCollision(GameObject.Find("TPPoint5").GetComponent<BoxCollider>(), GetComponent<CapsuleCollider>());
        }
    }


    public void DisableCollisionsTutorialTPS()
    {
        Physics.IgnoreCollision(TPMesa, GetComponent<CapsuleCollider>());
        Physics.IgnoreCollision(TPCentro, GetComponent<CapsuleCollider>());
        Physics.IgnoreCollision(TPDer, GetComponent<CapsuleCollider>());
    }

    public static int Play(string clip)
    {
        return PlayVoice(clip);   
    }

    public static int PlayVoice(string clip, string mob="MOB1")
    {
        print("playing... "+ clip);
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/"+MOBController.currentDirectoryAudios+"/"+clip);
        audioSource.clip = audioClip;
        audioSource.Play();
        print(""+audioSource.clip.length*1000);
        return int.Parse(""+ Convert.ToInt32(audioSource.clip.length*1000));   
    }
}
