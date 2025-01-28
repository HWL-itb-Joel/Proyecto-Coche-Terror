using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitles;
    [Header("GameObjects")]
    [SerializeField] GameObject Radio;

    [SerializeField] GameObject RadioOnSound;
    AudioSource radioOnSource;

    [SerializeField] GameObject KickWindow;

    [SerializeField] GameObject Notify;
    [SerializeField] GameObject UIIntroControls;
    Animator uiAnimators;

    [SerializeField] AudioSource SoundEffects;
    AudioSource LocutorRadio;

    [Header("Audios")]
    [SerializeField] AudioClip A_Locutor1;
    [SerializeField] AudioClip A_Locutor2;
    [SerializeField] AudioClip A_Locutor3;
    [SerializeField] AudioClip A_Locutor4;
    [SerializeField] AudioClip A_Locutor5;
    [SerializeField] AudioClip A_Locutor6;
    [SerializeField] AudioClip A_Locutor7;

    [Space(20)]

    [SerializeField] AudioClip Music;

    [SerializeField] AudioClip DramaticHit;

    [Space(20)]

    [SerializeField] AudioClip RadioOn;
    [SerializeField] AudioClip RadioOff;

    private void Awake()
    {
        UIIntroControls.SetActive(true);
        uiAnimators = UIIntroControls.GetComponent<Animator>();
        SoundEffects.enabled = false;
        SoundEffects.clip = DramaticHit;
        radioOnSource = RadioOnSound.GetComponent<AudioSource>();
        radioOnSource.enabled = false;
        radioOnSource.clip = RadioOn;
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
        yield return new WaitForSecondsRealtime(4f);
        radioOnSource.enabled = true;
        yield return new WaitUntil(() => !radioOnSource.isPlaying);
        SetSubtitle("Buenas noches, son las 11:23 PM y est?s sintonizando Radio Ruta 103");
        radioOnSource.enabled = false;
        Radio.SetActive(true);
        StartCoroutine(AudioStoped());
        yield return new WaitForSecondsRealtime(5.2f);
        SetSubtitle("la mejor compa??a para los viajeros nocturnos.");
        yield return new WaitForSecondsRealtime(3.2f);
        SetSubtitle("El clima para esta noche es tranquilo,");
        yield return new WaitForSecondsRealtime(2.3f);
        SetSubtitle("con cielos despejados y una ligera brisa que acompa?a a las estrellas.");
        yield return new WaitForSecondsRealtime(3.4f);
        SetSubtitle("Ideal para un viaje relajante por carretera.");
        yield return new WaitForSecondsRealtime(3.1f);
        SetSubtitle("Y sobre todo,");
        yield return new WaitForSecondsRealtime(0.9f);
        SetSubtitle("recuerden mantener la vista al frente con las luces encendidas,");
        Notify.SetActive(true);
        Notify.GetComponent<TextMeshProUGUI>().text = "Nota: Mant?n la vista al frente con las luces encendidas.";
        yield return new WaitForSecondsRealtime(3.8f);
        SetSubtitle("s? est?is demasiado tiempo distra?dos, podr?ais perder el control...");
        yield return new WaitForSecondsRealtime(4.2f);
        SetSubtitle("y nadie quiere que su viaje termine de una forma inesperada.");
        yield return new WaitForSecondsRealtime(3.4f);
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
        else if (LocutorRadio.clip == A_Locutor5)
        {
            StartCoroutine(StartAudio5());
        }

        Debug.Log("STOP");
    }

    IEnumerator StartAudio2()
    {
        LocutorRadio.clip = A_Locutor2;
        yield return new WaitForSecondsRealtime(1f);
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
        SetSubtitle("En otras noticias,");
        yield return new WaitForSecondsRealtime(1.4f);
        SetSubtitle("la feria anual del condado ha abierto hoy sus puertas con gran ?xito,");
        yield return new WaitForSecondsRealtime(3.7f);
        SetSubtitle("atrayendo a cientos de miles de visitantes.");
        yield return new WaitForSecondsRealtime(2.5f);
        SetSubtitle("La atracci?n principal ha sido la rueda de la fortuna con diferencia.");
        yield return new WaitForSecondsRealtime(3.7f);
        SetSubtitle("Y se espera gran ?xito con el espect?culo de fuegos artificiales programado para ma?ana por la noche.");
        yield return new WaitForSecondsRealtime(5.5f);
        SetSubtitle("Y si eres amante de los animales,");
        yield return new WaitForSecondsRealtime(1.6f);
        SetSubtitle("te encantar? saber que el refugio local organizar? una adopci?n especial este fin de semana.");
        yield return new WaitForSecondsRealtime(5.1f);
        SetSubtitle("No olvides pasar y darle un hogar a una mascota que lo necesite.");
        yield return new WaitForSecondsRealtime(3.5f);
        SetSubtitle("");
        yield return new WaitForSecondsRealtime(0.3f);
        SetSubtitle("Ahora una breve actualizaci?n de tr?fico.");
        yield return new WaitForSecondsRealtime(1.9f);
        SetSubtitle("La carretera principal en direcci?n norte est? completamente despejada.");
        yield return new WaitForSecondsRealtime(4f);
        SetSubtitle("Pero cuidado:");
        yield return new WaitForSecondsRealtime(0.7f);
        SetSubtitle("reportan niebla en algunos tramos,");
        yield return new WaitForSecondsRealtime(1.9f);
        SetSubtitle("as? que mant?n las luces encendidas y presta atenci?n al camino.");
        yield return new WaitForSecondsRealtime(3.4f);
        SetSubtitle("");
    }

    IEnumerator StartAudio3()
    {
        LocutorRadio.clip = A_Locutor3;
        yield return new WaitForSecondsRealtime(1f);
        LocutorRadio.enabled = true;
        StartCoroutine(AudioStoped());
        SetSubtitle("Hablando de mantener la atenci?n.");
        yield return new WaitForSecondsRealtime(2f);
        SetSubtitle("");
        yield return new WaitForSecondsRealtime(0.5f);
        SetSubtitle("?te ha pasado alguna vez sentir que alguien te est? observando mientras conduces?");
        yield return new WaitForSecondsRealtime(4.5f);
        SetSubtitle("");
        yield return new WaitForSecondsRealtime(0.8f);
        SetSubtitle("Quiz? solo sea el cansancio...");
        yield return new WaitForSecondsRealtime(2.2f);
        SetSubtitle("");
        yield return new WaitForSecondsRealtime(0.7f);
        SetSubtitle("O tal vez...");
        yield return new WaitForSecondsRealtime(1.1f);
        SetSubtitle("no est?s tan solo como crees.");
        SoundEffects.enabled = true;
        yield return new WaitForSecondsRealtime(2.6f);
        SetSubtitle("");
        yield return new WaitUntil(() => !SoundEffects.isPlaying);
        SoundEffects.enabled = false;
    }

    IEnumerator StartAudio4()
    {
        LocutorRadio.clip = A_Locutor4;
        yield return new WaitForSecondsRealtime(2f);
        LocutorRadio.enabled = true;
        GetComponent<Animator>().SetTrigger("change");
        uiAnimators.SetTrigger("DisableContrls");
        StartCoroutine(AudioStoped());
        SetSubtitle("?Pero no te preocupes!");
        yield return new WaitForSecondsRealtime(1.1f);
        SetSubtitle("?Porque aqu? estamos para acompa?arte!");
        yield return new WaitForSecondsRealtime(1.9f);
        SetSubtitle("Y ahora, una canci?n cl?sica para animar el viaje.");
        yield return new WaitForSecondsRealtime(3f);
        SetSubtitle("?Sube el volumen y disfruta!");
        yield return new WaitForSecondsRealtime(1.8f);
        SetSubtitle("");
    }

    IEnumerator StartMusic()
    {
        LocutorRadio.clip = Music;
        yield return new WaitForSecondsRealtime(1f);
        LocutorRadio.enabled = true;
        radioOnSource.clip = RadioOff;
        yield return new WaitForSecondsRealtime(44f);
        LocutorRadio.enabled = false;
        LocutorRadio.clip = A_Locutor5;
        radioOnSource.enabled = true;
        StartCoroutine(AudioStoped());
    }

    IEnumerator StartAudio5()
    {
        LocutorRadio.clip = A_Locutor5;
        yield return new WaitForSecondsRealtime(0.5f);
        LocutorRadio.enabled = true;
        SetSubtitle("En noticias m?s serias,");
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
