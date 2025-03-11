using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FondoMovimiento : MonoBehaviour {


    [SerializeField] private Vector2 velocidadDeMovimiento;
    private Vector2 offset;


    private Material material;

    private void Awake()
    {
        material = GetComponent<Material>();

    }
    private void Update()
    {
        offset = velocidadDeMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}

