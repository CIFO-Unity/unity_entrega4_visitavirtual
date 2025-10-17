using UnityEngine;
using UnityEngine.UI;

public class ControlBoton : MonoBehaviour
{
    [SerializeField] private Color colorBoton = Color.white;
    [SerializeField][Range(0f, 1f)] private float brillo = 1f;

    private Text texto;

    void Start()
    {
        texto = GetComponentInChildren<Text>();
        // Crea material único
        if (texto.material != null)
            texto.material = new Material(texto.material);

        ActualizarApariencia();
    }

    void ActualizarApariencia()
    {
        if (texto != null)
        {
            Color colorFinal = colorBoton * brillo;
            texto.color = colorFinal;
        }
    }

    // Llama a esto desde el Inspector o código para actualizar
    void OnValidate()
    {
        if (texto != null)
            ActualizarApariencia();
    }
}

//Lo asignamos este script al texto que queremos para poder modificar el color a ese texto y no a todos.