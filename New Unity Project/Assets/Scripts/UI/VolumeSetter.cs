using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Made by Haley Vlahos
public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer master;

    // Sets the master volume to the volume parameter
    public void setMasterVol(float volume)
    {
        master.SetFloat("MasterVolume", volume);
    }
}
