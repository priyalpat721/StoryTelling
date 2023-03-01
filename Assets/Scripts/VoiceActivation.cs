using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
<<<<<<< Updated upstream


public class VoiceActivation : MonoBehaviour
{
=======
using UnityEngine.InputSystem;

public class VoiceActivation : MonoBehaviour
{
    public InputActionReference input;
>>>>>>> Stashed changes
    private AppVoiceExperience _voiceExperience;
    private void OnValidate()
    {
        if (!_voiceExperience) _voiceExperience = GetComponent<AppVoiceExperience>();
    }

    private void Awake()
    {
<<<<<<< Updated upstream
        
    }
=======
        input.action.started += ActivateWitMic;
        input.action.canceled += DeactivateWitMic;

    }

    private void OnDestroy()
    {
        input.action.started += ActivateWitMic;
        input.action.canceled += DeactivateWitMic;

    }

>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======
    public void ActivateWitMic(InputAction.CallbackContext context)
    {
        ActivateWit();
    }

    public void DeactivateWitMic(InputAction.CallbackContext context)
    {
        DeactivateWit();
    }

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
