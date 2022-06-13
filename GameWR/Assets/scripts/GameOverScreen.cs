using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;
    // KeyCode RestartKey = KeyCode.P;

    public GameObject scene = null;
    public GameObject game = null;

    public void Setup(int score) 
    {
        pointsText.text = score.ToString() + " POINTS ";
    }


    public void EndGameView()
    {
        scene.SetActive(!scene.activeSelf);
    }

    public void StartGameView()
    {
        scene.SetActive(!scene.activeSelf);
    }
}
