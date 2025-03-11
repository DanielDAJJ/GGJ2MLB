using UnityEngine;

public class IntoScene : MonoBehaviour
{
    //asegura que solo exista una instancia del objeto en todas las escenas y evita su destrucción al cambiar de escena.
    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsByType<IntoScene>(FindObjectsSortMode.None);
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
