using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Script de diagnóstico para verificar el estado del Video Player
/// </summary>
[RequireComponent(typeof(VideoPlayer))]
public class VideoDebug : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
        Debug.Log("=== VIDEO PLAYER DEBUG ===");
        Debug.Log($"Video asignado: {(videoPlayer.clip != null ? videoPlayer.clip.name : "NINGUNO")}");
        Debug.Log($"Source type: {videoPlayer.source}");
        Debug.Log($"Render mode: {videoPlayer.renderMode}");
        Debug.Log($"Play on awake: {videoPlayer.playOnAwake}");
        Debug.Log($"Is playing: {videoPlayer.isPlaying}");
        Debug.Log($"Is prepared: {videoPlayer.isPrepared}");
        
        // Intentar reproducir manualmente
        if (videoPlayer.clip != null)
        {
            Debug.Log("Intentando reproducir video manualmente...");
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("¡NO HAY VIDEO ASIGNADO! Arrastra el archivo .mp4 al campo 'Video Clip'");
        }
        
        // Suscribirse a eventos
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.started += OnVideoStarted;
        videoPlayer.errorReceived += OnVideoError;
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("✅ Video preparado correctamente");
        Debug.Log($"Duración: {vp.length} segundos");
        Debug.Log($"Frame rate: {vp.frameRate} fps");
        Debug.Log($"Resolución: {vp.width}x{vp.height}");
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        Debug.Log("✅ Video INICIADO correctamente");
    }

    void OnVideoError(VideoPlayer vp, string message)
    {
        Debug.LogError($"❌ ERROR en video: {message}");
    }

    void Update()
    {
        // Mostrar información cada 2 segundos
        if (Time.frameCount % 120 == 0 && videoPlayer.isPlaying)
        {
            Debug.Log($"Reproduciendo: {videoPlayer.time:F1}s / {videoPlayer.length:F1}s");
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.started -= OnVideoStarted;
            videoPlayer.errorReceived -= OnVideoError;
        }
    }
}
