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

   


    // Update is called once per frame
    void Update()
    {
      score.text = "Score: "+scoreDisplay.ToString();
      hearts.text = "Hearts: "+heartDisplay.ToString();

    }
}
