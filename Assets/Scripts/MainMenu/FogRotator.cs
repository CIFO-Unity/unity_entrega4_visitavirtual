using UnityEngine;

/// <summary>
/// Rota lentamente un objeto para simular niebla en movimiento
/// </summary>
public class FogRotator : MonoBehaviour
{
    [Header("Configuración de Rotación")]
    [Tooltip("Velocidad de rotación en el eje Y (horizontal)")]
    public float rotationSpeed = 5f;

    [Tooltip("Si quieres rotación aleatoria en múltiples ejes")]
    public bool randomRotation = false;

    private Vector3 rotationAxis;

    void Start()
    {
        if (randomRotation)
        {
            // Genera un eje de rotación aleatorio
            rotationAxis = new Vector3(
                Random.Range(-0.3f, 0.3f),
                1f,
                Random.Range(-0.3f, 0.3f)
            ).normalized;
        }
        else
        {
            // Solo rota en el eje Y (horizontal)
            rotationAxis = Vector3.up;
        }
    }

    void Update()
    {
        // Rota el objeto lentamente
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }
}
