using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;
    [SerializeField] AudioClip[] _clipsBreaking;
    [SerializeField] ParticleSystem _particleSystem1;
    [SerializeField] ParticleSystem _particleSystem2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int index1 = UnityEngine.Random.Range(0, _clips.Length);
        int index2 = UnityEngine.Random.Range(0, _clipsBreaking.Length);

        if (collision.relativeVelocity.magnitude > 15f)
        {
            AudioClip clip = _clipsBreaking[index2];
            GetComponent<AudioSource>().PlayOneShot(clip);
            _particleSystem1.Play();
            _particleSystem2.Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (collision.relativeVelocity.magnitude > 5f)
        {
            AudioClip clip = _clips[index1];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Collision did not trigger audio."); 
        }
    }
}
