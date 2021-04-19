using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject EndLevelUI;
    public  int  Hearts = 10;  // player hearts
    public  int  Score = 0;   // player score
    public UIController uic; // instance of UIController
   

    // Update is called once per frame
    void Update()
    {
        UIAction.scoreDisplay = Score;
        UIAction.heartDisplay = Hearts;

        if(Hearts <=0){
        EndLevelUI.SetActive(true);
        Debug.Log("STOP THE GAME");
        uic.Stopgame();
        }
    }
}
