using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer master;

    public void setMasterVol(float volume)
    {
        master.SetFloat("MasterVolume", volume);
    }
}
