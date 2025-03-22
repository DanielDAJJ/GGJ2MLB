using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public GameObject personPrefab;
    public Transform spawnPoint;
    public float liftForce = 3f;
    public List<GameObject> activeHumans = new List<GameObject>();
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private bool isReturning = false;
    private bool isBeingLifted = false;
    private bool isPressingSpace = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }
    void Update()
    {
        isPressingSpace = Input.GetKey(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnHuman();
            ApplyLift();
        }
    }

    void SpawnHuman()
    {
        Vector3 spawnDownGlobe = new Vector3(spawnPoint.position.x, transform.position.y - 1, 0);

        GameObject newHuman = Instantiate(personPrefab, spawnDownGlobe, spawnPoint.rotation);
        activeHumans.Add(newHuman);

        AudioManager.Instance.PlaySFX();

        // aplly falling force
        Rigidbody2D humanRb = newHuman.GetComponent<Rigidbody2D>();
        float fallForceX = -5f;
        float fallForceY = -2f;

        if (humanRb != null)
        {
            humanRb.AddForce(new Vector2(fallForceX, fallForceY), ForceMode2D.Impulse);
        }
        if (!isReturning)
        {
            StartCoroutine(ReturnInitialPositionGlobe());
        }
        //StartCoroutine(ReturnInitialPositionGlobe());
    }

    void ApplyLift()
    {
        if (rb != null)
        {
            rb.AddForce(Vector2.up * liftForce, ForceMode2D.Impulse);
            isBeingLifted = true;
            // Si el jugador sigue presionando Space, no estabilizamos la altura
            StopCoroutine(StabilizeHeight());
            StartCoroutine(CheckForStabilization());
            if (rb != null && !isBeingLifted)
            {
                rb.AddForce(Vector2.up * liftForce, ForceMode2D.Impulse);
                isBeingLifted = true; // Indicamos que el globo está subiendo
                StartCoroutine(StabilizeHeight());
            }
        }
    }
    IEnumerator CheckForStabilization()
    {
        yield return new WaitUntil(() => !isPressingSpace); // Espera hasta que Space sea soltado
        StartCoroutine(StabilizeHeight());
    }
    IEnumerator StabilizeHeight()
    {
        yield return new WaitForSeconds(1f);
        isBeingLifted = false; // Se puede estabilizar de nuevo
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    IEnumerator ReturnInitialPositionGlobe()
    {
        isReturning = true;
        yield return new WaitForSeconds(1f);
        
        while (Vector3.Distance(transform.position, initialPosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
            yield return null;
        }
        transform.position = initialPosition; 
        isReturning = false;
        Debug.Log("Se supone que estoy funcionando");
    }
}
