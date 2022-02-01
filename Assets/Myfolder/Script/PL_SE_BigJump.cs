using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_SE_BigJump : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider triger)
    {
        if (triger.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(sound1);

        }

    }

}
