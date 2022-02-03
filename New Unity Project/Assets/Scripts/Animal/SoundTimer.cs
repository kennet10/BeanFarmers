using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class SoundTimer : MonoBehaviour
{
    [SerializeField] int timeMin;
    [SerializeField] int timeMax;
    private AudioSource animalSound;
    private bool waiting;
    
    private void Awake()
    {
        animalSound = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(waitSound(timeMin, timeMax));
    }

    //Starts the playSound coroutine if it is not currently playing and not waiting for the current sound to end
    void Update()
    {
        if (!animalSound.isPlaying && !waiting) {
            StartCoroutine(waitSound(timeMin, timeMax));
        }
    }

    // Plays the animal sound after a range of seconds between min and max, then waits for the length of the sound clip
    private IEnumerator waitSound(int min, int max)
    {
        waiting = true;
        yield return new WaitForSeconds(Random.Range(min, max));
        animalSound.Play();
        yield return new WaitForSeconds(animalSound.clip.length);
        waiting = false;
    }
}
