using UnityEngine;
using UnityEngine.UI;

public class MaterialUnicoBoton : MonoBehaviour
{
    void Start()
    {
        // Para textos UI normales
        Text texto = GetComponent<Text>();
        if (texto != null && texto.material != null)
        {
            texto.material = new Material(texto.material); // Crea copia única
        }

        // Para TextMeshPro
        TMPro.TextMeshProUGUI textoPro = GetComponent<TMPro.TextMeshProUGUI>();
        if (textoPro != null && textoPro.fontMaterial != null)
        {
            textoPro.fontMaterial = new Material(textoPro.fontMaterial); // Crea copia única
        }

        // Para Image del botón
        Image imagen = GetComponent<Image>();
        if (imagen != null && imagen.material != null)
        {
            imagen.material = new Material(imagen.material); // Crea copia única
        }
    }
}
