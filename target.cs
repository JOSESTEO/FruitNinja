using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Random = UnityEngine.Random;

public class target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12, maxForce = 16, maxTorque = 10, xRange = 4, ySpawPos = -6;
    
    private GameManager _gameManager;
    [Range(-10,50)]
    public int pointValue;

    public ParticleSystem explosionPaticle;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse); //Aplicamos una fuerza aleatoria entre 12 y 16
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse); //Aplicamos una rotación aleatorio
        transform.position = RandomSpawnPosition(); //Si sólo pongo dos parámetros, z=0
        _gameManager = FindObjectOfType<GameManager>();
    }
/// <summary>
/// Genera un vector aleatoria
/// </summary>
/// <returns>Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minForce, maxForce);
    }
/// <summary>
/// Genera un número aleatorio
/// </summary>
/// <returns>Valor aleatorio entre menos MaxTorque y e</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
/// <summary>
/// Genera una posición aleatoria
/// </summary>
/// <returns>Posición aleatoria en 3D con coordenada z=0</returns>
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawPos);
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (_gameManager.gameSate == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            _gameManager.UpdateScore(this.pointValue);
            Instantiate(explosionPaticle, transform.position, explosionPaticle.transform.rotation);
            if(this.CompareTag("Bad")) _gameManager.gameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (this.CompareTag("Good")) _gameManager.UpdateScore(-this.pointValue);
    }
}
