 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIAction : MonoBehaviour
{ 
    
  public static int scoreDisplay;      
  public TextMeshProUGUI score;

  public static int heartDisplay;      
  public TextMeshProUGUI hearts;

  public TextMeshProUGUI timer;
  public static float timerDisplay;

   


    // Update is called once per frame
    void Update()
    {
      score.text = "Score: "+scoreDisplay.ToString();
      hearts.text = "Hearts: "+heartDisplay.ToString();
      timer.text = "Time: "+timerDisplay.ToString("F0");

    }
}
