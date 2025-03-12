using System.Collections;
using UnityEngine;

public class HumanAutoDestroy : MonoBehaviour
{
    public float timeToDisappear = 0.1f;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }
    }

}
