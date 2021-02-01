using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class knock : MonoBehaviour
{
    public AudioClip yourAudioClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().clip = yourAudioClip;
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().clip = yourAudioClip;
            GetComponent<AudioSource>().Stop();
        }
    }
}