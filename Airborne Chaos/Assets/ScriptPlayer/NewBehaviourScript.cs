using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;      // Velocidad de movimiento horizontal
    public float fuerzaVuelo = 5f;   // Fuerza con la que vuela el personaje
    public float gravedad = 2f;      // Intensidad de la caída cuando no vuela

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal (Izquierda/Derecha)
        float movimientoX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoX * velocidad, rb.velocity.y);

        // Movimiento vertical (Volar)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaVuelo);
        }
        else
        {
            // Aplica gravedad personalizada para una caída más controlada
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - gravedad * Time.deltaTime);
        }
    }
}
