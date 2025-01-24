using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] GameObject Notify;

    [SerializeField] TextMeshProUGUI subtitles;

    private void Awake()
    {
        RadioOnSound.SetActive(false);
        Radio.SetActive(false);
        Notify.SetActive(false);
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
        SetSubtitle("Buenas noches, son las 11:23 PM y estás sintonizando Radio Ruta 103");
        Radio.SetActive(true);
        StartCoroutine(AudioStoped());
        yield return new WaitForSeconds(5.2f);
        SetSubtitle("la mejor compañía para los viajeros nocturnos.");
        yield return new WaitForSeconds(3.2f);
        SetSubtitle("El clima para esta noche es tranquilo,");
        yield return new WaitForSeconds(2.3f);
        SetSubtitle("con cielos despejados y una ligera brisa que acompaña a las estrellas.");
        yield return new WaitForSeconds(3.4f);
        SetSubtitle("Ideal para un viaje relajante por carretera.");
        yield return new WaitForSeconds(3.1f);
        SetSubtitle("Y sobre todo,");
        yield return new WaitForSeconds(0.9f);
        SetSubtitle("recuerden mantener la vista al frente con las luces encendidas,");
        Notify.SetActive(true);
        Notify.GetComponent<TextMeshProUGUI>().text = "Nota: Mantén la vista al frente con las luces encendidas.";
        yield return new WaitForSeconds(3.8f);
        SetSubtitle("sí estáis demasiado tiempo distraídos, podríais perder el control...");
        yield return new WaitForSeconds(4.2f);
        SetSubtitle("y nadie quiere que su viaje termine de forma inesperada.");
        yield return new WaitForSeconds(3.4f);
        SetSubtitle("");
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
        LocutorRadio.clip = A_Locutor2;
        yield return new WaitForSeconds(1f);
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
        SetSubtitle("En otras noticias,");
        yield return new WaitForSeconds(1.4f);
        SetSubtitle("la feria anual del condado ha abierto hoy sus puertas con gran éxito,");
        yield return new WaitForSeconds(3.6f);
        SetSubtitle("atrayendo a cientos de miles de visitantes.");
        yield return new WaitForSeconds(2.5f);
        SetSubtitle("La atracción principal ha sido la rueda de la fortuna con diferencia.");
        yield return new WaitForSeconds(3.7f);
        SetSubtitle("Y se espera gran éxito con el espectáculo de fuegos artificiales programado para mañana por la noche.");
        yield return new WaitForSeconds(5.5f);
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
        LocutorRadio.enabled = true;
        GetComponent<Animator>().SetTrigger("change");
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

    void SetSubtitle(string text)
    {
        subtitles.text = text;
    }
}
