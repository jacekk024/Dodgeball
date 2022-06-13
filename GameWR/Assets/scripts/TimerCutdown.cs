using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCutdown : MonoBehaviour
{
    public GameObject textDisplay;
    private int seconds = 59;
    private int secondsAll;
    public bool takingAway = false;
    private int min = 1;
    public GameOverScreen gameOver;
    public PlayerInventory player;
    public KeyCode RestartKey = KeyCode.P;
    public InventoryUI inv;

    private int secondsConst;
    private int minConst;

    private void Start()
    {
        if(min == 0)
            textDisplay.GetComponent<Text>().text = "00:" + seconds;
        else
            textDisplay.GetComponent<Text>().text = "0"+ min + ":" + seconds;

        secondsAll += 60 * min + seconds;
        minConst = min;
        secondsConst = seconds;
    }

    private void Update()
    {
        if (takingAway == false && seconds > 0) 
        {
            StartCoroutine(TimerTake());
     
        }

        if (secondsAll <= 0)
        {
            if (Input.GetKeyDown(RestartKey))
            {
                min = minConst;
                seconds = secondsConst;
                secondsAll += 60 * min + seconds;
                gameOver.StartGameView();
                player.SetNumberOfDiamonds();
                inv.UpdateDiamondNull();
            }
        }
    }

    IEnumerator TimerTake() 
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        seconds -= 1;
        secondsAll -= 1;
        if ((secondsAll % 60) == 0 && (secondsAll != 0))
        {
            min -= 1;
            seconds = 60;
        }
        else if (secondsAll == 0) 
        {
            gameOver.Setup(player.GetNumberOfDiamonds());

            gameOver.EndGameView();
        }

        if (seconds < 10 && (min < 1))
        {
            textDisplay.GetComponent<Text>().text = "00:0" + seconds;
        }
        else if ((seconds >= 10) && (min < 1))
        {

            textDisplay.GetComponent<Text>().text = "00:" + seconds;
        }
        else if ((min >= 1) && (seconds >= 10))
        {
            textDisplay.GetComponent<Text>().text = "0" + min + ":" + seconds;
        }
        else if ((seconds < 10) && (min >= 1))
        {
            textDisplay.GetComponent<Text>().text = "0" + min + ":0" + seconds;
        }

        takingAway = false;
    }

 

}
