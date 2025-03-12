using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Necesario para detectar eventos del mouse

public class BotonSonido : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource; // Fuente de sonido
    public AudioClip sonidoHover; // Sonido al pasar el mouse

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null && sonidoHover != null)
        {
            audioSource.PlayOneShot(sonidoHover); // Reproduce el sonido sin interrumpir otros sonidos
        }
    }
}
