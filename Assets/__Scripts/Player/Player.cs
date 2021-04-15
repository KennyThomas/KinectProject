using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject EndLevelUI;
    public  int  Hearts = 10;
    public  int  Score = 0;
    public UIController uic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
