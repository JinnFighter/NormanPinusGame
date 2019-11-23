using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip collectStickSound;
    [SerializeField] private AudioClip maleDeathSound;
    [SerializeField] private AudioClip femaleDeathSound;
    [SerializeField] private AudioClip positiveAnswerSound;
    [SerializeField] private AudioClip negativeAnswerSound;
    [SerializeField] private AudioClip startDialogueSound;
    [SerializeField] private AudioClip bonfireSound;
    [SerializeField] private AudioClip startGameSound;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollectingStick()
    {
        audioSource.PlayOneShot(collectStickSound);
    }
}
