using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla la reproducción de video y puede cambiar de escena cuando termina
/// Útil para splash screens o cinemáticas
/// </summary>
[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Cambiar a esta escena cuando termine el video")]
    public string escenaSiguiente = "MainMenu";
    
    [Tooltip("Cambiar escena automáticamente cuando termine el video")]
    public bool cambiarEscenaAlTerminar = true;
    
    [Tooltip("Permitir saltar el video presionando una tecla")]
    public bool permitirSaltar = true;
    
    [Tooltip("Tecla para saltar el video")]
    public KeyCode teclaSaltar = KeyCode.Space;
    
    [Tooltip("Tiempo mínimo antes de poder saltar (segundos)")]
    public float tiempoMinimoAntesDeSaltar = 1f;

    private VideoPlayer videoPlayer;
    private float tiempoTranscurrido = 0f;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
        // Suscribirse al evento de fin de video
        videoPlayer.loopPointReached += OnVideoTerminado;
        
        // Reproducir el video
        videoPlayer.Play();
        
        Debug.Log($"Reproduciendo video. Duración: {videoPlayer.clip?.length ?? 0} segundos");
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        
        // Permitir saltar el video
        if (permitirSaltar && 
            tiempoTranscurrido >= tiempoMinimoAntesDeSaltar && 
            Input.GetKeyDown(teclaSaltar))
        {
            SaltarVideo();
        }
        
        // También permitir saltar con clic del mouse o tap en móvil
        if (permitirSaltar && 
            tiempoTranscurrido >= tiempoMinimoAntesDeSaltar && 
            Input.GetMouseButtonDown(0))
        {
            SaltarVideo();
        }
    }

    /// <summary>
    /// Se llama cuando el video termina de reproducirse
    /// </summary>
    void OnVideoTerminado(VideoPlayer vp)
    {
        Debug.Log("Video terminado");
        
        if (cambiarEscenaAlTerminar && !string.IsNullOrEmpty(escenaSiguiente))
        {
            CambiarEscena();
        }
    }

    /// <summary>
    /// Salta el video y cambia de escena inmediatamente
    /// </summary>
    public void SaltarVideo()
    {
        Debug.Log("Video saltado por el usuario");
        videoPlayer.Stop();
        
        if (!string.IsNullOrEmpty(escenaSiguiente))
        {
            CambiarEscena();
        }
    }

    /// <summary>
    /// Cambia a la siguiente escena
    /// </summary>
    void CambiarEscena()
    {
        Debug.Log($"Cambiando a escena: {escenaSiguiente}");
        SceneManager.LoadScene(escenaSiguiente);
    }

    /// <summary>
    /// Pausa el video
    /// </summary>
    public void PausarVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
    }

    /// <summary>
    /// Reanuda el video
    /// </summary>
    public void ReanudarVideo()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    void OnDestroy()
    {
        // Desuscribirse del evento para evitar errores
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoTerminado;
        }
    }
}
