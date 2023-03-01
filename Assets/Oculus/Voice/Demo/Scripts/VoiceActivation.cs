using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;


public class VoiceActivation : MonoBehaviour
{
    private AppVoiceExperience _voiceExperience;
    private void OnValidate()
    {
        if (!_voiceExperience) _voiceExperience = GetComponent<AppVoiceExperience>();
    }

    private void Awake()
    {
        
    }
    private void Start()
    {
        _voiceExperience = GetComponent<AppVoiceExperience>();
        // Debug.Log(Microphone.devices.Length);
        // Debug.Log(Application.internetReachability.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("*** Pressed Space bar ***");
            ActivateWit();
        }
    }

    /// <summary>
    /// Activates Wit i.e. start listening to the user.
    /// </summary>
    public void ActivateWit()
    {
        _voiceExperience.Activate();
    }

    public void DeactivateWit()
    {
        _voiceExperience.Deactivate();
    }
}
