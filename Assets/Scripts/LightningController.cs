using System.Collections;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public Light lightningLight;
    public float minTime = 80f;  // 1 minuto
    public float maxTime = 110f;  // 1 minuto y medio
    public AudioSource thunderAudio;

    private float timer;
    private bool isPlaying = false; // Evita que se superpongan truenos

    void Start()
    {
        lightningLight.enabled = false;
        
        // El primer trueno empieza a los 20 segundos
        timer = 20f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && !isPlaying)
        {
            StartCoroutine(LightningFlash());
        }
    }

    IEnumerator LightningFlash()
    {
        isPlaying = true; // Bloquea nuevos truenos mientras este se reproduce

        // Reproduce el audio del trueno (dura 32 segundos)
        if (thunderAudio != null)
            thunderAudio.Play();

        // Pequeña pausa antes del flash visual
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));

        // Intensidad aumentada para URP (visible pero no cegadora)
        lightningLight.intensity = Random.Range(15f, 25f);
        lightningLight.enabled = true;

        // Duración del flash visual
        yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));

        lightningLight.enabled = false;

        // Espera a que el audio termine completamente (32 segundos total)
        yield return new WaitForSeconds(32f);

        // Reinicia el timer para el próximo trueno
        timer = Random.Range(minTime, maxTime);
        isPlaying = false;
    }
}
