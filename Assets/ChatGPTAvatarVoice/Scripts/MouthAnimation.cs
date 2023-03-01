using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthAnimation : MonoBehaviour
{
    public SkinnedMeshRenderer _headMeshRenderer;
    int mouthOpenIndex;
    private AudioSource _audioSource;
    void Start()
    {
        mouthOpenIndex = _headMeshRenderer.sharedMesh.GetBlendShapeIndex("mouthOpen");
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        

        if (_audioSource.isPlaying)
        {
            GetComponent<Animator>().SetInteger("animState", 1);
            float tempWeight = Mathf.PingPong(Time.time * 200, 50);
            _headMeshRenderer.SetBlendShapeWeight(mouthOpenIndex, tempWeight);
        }
        else
        {
            GetComponent<Animator>().SetInteger("animState", 0);
            _headMeshRenderer.SetBlendShapeWeight(mouthOpenIndex, 0);
        }
    }
}
