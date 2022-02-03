using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_SE_multijump : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
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
        if (triger.gameObject.tag == "multijump")
        {
            audioSource.PlayOneShot(sound1);
            

        }
        else if (triger.gameObject.tag == "multijump2")
        {
            audioSource.PlayOneShot(sound2);
           

        }
        else if (triger.gameObject.tag == "multijump3")
        {
            audioSource.PlayOneShot(sound3);
          

        }

    }
}
