using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int scoreValue;

    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Game Controller Missing!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            gameController.AddToScore(scoreValue);
        }
    }
}
