using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttenuateAudio : MonoBehaviour
{
    private AudioSource aud;  // Reference to the AudioSource component
    public AudioClip audioClip;  // The audio clip to be played, attached manually in Unity
    public float initialVolume = 1.0f;
    public float initialPitch = 1.0f;
    public float maxDistance = 20.0f; // the maximum distance the audio travels
    public HumanoidLandController playerController;  // Reference to a player controller object
    
    // Initialize the audio clip
    private void Start()
    {
        aud = gameObject.AddComponent<AudioSource>(); // Create and attach an AudioSource component to the game object
        aud.clip = audioClip;  // Set the audio clip for the AudioSource
        aud.volume = initialVolume;
        aud.pitch = initialPitch;
        aud.Play(); // Start the audio 
    }

    // Change the volume based on the user's distance from the object
    private void Update()
    {
        // Calculate the distance between the object and the user
        float distanceToPlayer = Vector3.Distance(transform.position, playerController.transform.position);

        // Calculate the new volume based on distance from object
        float newVolume = 1.0f - (distanceToPlayer / maxDistance); // Attenuate the volume linearly
        newVolume = Mathf.Clamp(newVolume, 0.0f, 1.0f); // Ensure that newVolume stays within the range [0, 1].

        // Update the audio source's volume
        aud.volume = newVolume;
    }
}
