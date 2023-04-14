using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int index = UnityEngine.Random.Range(0, _clips.Length);
        AudioClip clip = _clips[index];
        if (collision.relativeVelocity.magnitude > 5f)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Collision did not trigger audio."); 
        }
    }
}
