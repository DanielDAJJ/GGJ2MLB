using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAutoDestroy : MonoBehaviour
{
    public float timeToDisappear = 5f;
    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeToDisappear); 
        Destroy(gameObject); 
    }
}
