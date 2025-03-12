using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public GameObject personPrefab;
    public Transform spawnPoint;
    private float maxHumans = 10;
    public float liftForce = 0.1f;
    public List<GameObject> activeHumans = new List<GameObject>();
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (
                activeHumans.Count < maxHumans
            )
            {
                SpawnHuman();
                ApplyLift();
            }

        }
    }

    void SpawnHuman()
    {
        GameObject newHuman = Instantiate(personPrefab, spawnPoint.position, spawnPoint.rotation);
        activeHumans.Add(newHuman);

        // aplly falling force
        Rigidbody2D humanRb = newHuman.GetComponent<Rigidbody2D>();
        float fallForceX = -5f;
        float fallForceY = -2f;

        if (humanRb != null)
        {
            humanRb.AddForce(new Vector2(fallForceX, fallForceY), ForceMode2D.Impulse);
        }
    }

    void ApplyLift()
    {
        if (rb != null)
        {
            rb.AddForce(Vector2.up * liftForce, ForceMode2D.Impulse);
            StartCoroutine(StabilizeHeight());
        }
    }

    IEnumerator StabilizeHeight()
    {
        yield return new WaitForSeconds(1f);
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Estabiliza la velocidad en Y
        }
    }

    public void RemovePerson(GameObject human)
    {
        activeHumans.Remove(human);
        Destroy(human);
    }
}
