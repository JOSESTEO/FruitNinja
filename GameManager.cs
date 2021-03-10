using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Para los enumerados, antes de nada los definimos así
    public enum GameState
    {
        inGame,
        gameOver,
        himno,
        primerQuiz,
        primeraParte,
        segundoQuiz,
        segundaparte,
    }
    //Y luego defino la variable que contenga el estado del enum
    public GameState gameSate;
    
    private float spawnRate=1;
    public List<GameObject> targetPrefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    //Con esta forma mantengo los valores de score entre un mínimo y un máximo
    private int _score;
    private int Score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 9999);
        }
        get
        {
            return _score;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (gameSate == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }

    }
    /// <summary>
    /// Actualiza la puntuación y la muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos que se suman a la puntuación</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd; //Primero la lógica del juego
        scoreText.text = "Puntos:\n" + Score;  //Luego la visualización
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameSate = GameState.gameOver;
    }
    // Esto es de prueba
}
