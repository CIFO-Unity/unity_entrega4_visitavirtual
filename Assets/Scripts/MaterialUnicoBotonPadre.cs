using UnityEngine;
using UnityEngine.UI;

// Este script se pone en el GameObject del BUTTON (el padre)
public class MaterialUnicoBotonPadre : MonoBehaviour
{
    void Start()
    {
        // Busca el componente Text en los HIJOS (GetComponentInChildren)
        Text texto = GetComponentInChildren<Text>();
        if (texto != null && texto.material != null)
        {
            texto.material = new Material(texto.material); // Crea copia única
        }

        // Para TextMeshPro en los hijos
        TMPro.TextMeshProUGUI textoPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (textoPro != null && textoPro.fontMaterial != null)
        {
            textoPro.fontMaterial = new Material(textoPro.fontMaterial); // Crea copia única
        }

        // Para Image del botón mismo
        Image imagen = GetComponent<Image>();
        if (imagen != null && imagen.material != null)
        {
            imagen.material = new Material(imagen.material); // Crea copia única
        }
    }
}
