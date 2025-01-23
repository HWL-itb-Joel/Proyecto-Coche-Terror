using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    [SerializeField] GameObject Radio;
    AudioSource LocutorRadio;
    [SerializeField] GameObject RadioOnSound;

    [SerializeField] GameObject KickWindow;

    [SerializeField] AudioClip A_Locutor1;
    [SerializeField] AudioClip A_Locutor2;
    [SerializeField] AudioClip A_Locutor3;
    [SerializeField] AudioClip A_Locutor4;
    [SerializeField] AudioClip A_Locutor5;
    [SerializeField] AudioClip A_Locutor6;

    [SerializeField] AudioClip Music;

    private void Awake()
    {
        RadioOnSound.SetActive(false);
        Radio.SetActive(false);
        LocutorRadio = Radio.GetComponent<AudioSource>();
        LocutorRadio.clip = A_Locutor1;
    }

    private void Update()
    {
        Debug.Log(LocutorRadio.isPlaying);
    }

    private void OnEnable()
    {
        EventManager.OnSpeak += DoSomething;
    }
    private void OnDisable()
    {
        EventManager.OnSpeak -= DoSomething;

    }

    private void DoSomething()
    {
        StartCoroutine(StartLocutor());
    }

    IEnumerator StartLocutor()
    {
        yield return new WaitForSeconds(4f);
        RadioOnSound.SetActive(true);
        yield return new WaitUntil(() => !RadioOnSound.GetComponent<AudioSource>().isPlaying);
        Radio.SetActive(true);
        StartCoroutine(AudioStoped());
    }

    IEnumerator AudioStoped()
    {
        yield return new WaitUntil(() => !LocutorRadio.isPlaying);
        LocutorRadio.enabled = false;

        if (LocutorRadio.clip == A_Locutor1)
        {
            StartCoroutine(StartAudio2());
        }
        else if (LocutorRadio.clip == A_Locutor2)
        {
            StartCoroutine(StartAudio3());
        }
        else if (LocutorRadio.clip == A_Locutor3)
        {
            StartCoroutine(StartAudio4());
        }
        else if (LocutorRadio.clip == A_Locutor4)
        {
            StartCoroutine(StartMusic());
        }
        
        
        Debug.Log("STOP");
    }

    IEnumerator StartAudio2()
    {
        LocutorRadio.clip = A_Locutor4;
        yield return new WaitForSeconds(1f);
        LocutorRadio.enabled = true;
        GetComponent<Animator>().SetTrigger("change");
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
    }

    IEnumerator StartAudio3()
    {
        LocutorRadio.clip = A_Locutor3;
        yield return new WaitForSeconds(1f);
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
    }

    IEnumerator StartAudio4()
    {
        LocutorRadio.clip = A_Locutor4;
        yield return new WaitForSeconds(2f);
        
        StartCoroutine(AudioStoped());
    }

    IEnumerator StartMusic()
    {
        LocutorRadio.clip = Music;
        yield return new WaitForSeconds(1f);
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
    }

    void desableAnimator()
    {
        GetComponent<Animator>().enabled = false;
        GetComponentInChildren<CameraMovement>().enabled = true;
    }
}
