using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech; 
public class Navigation : MonoBehaviour
{


     [SerializeField] private string valueString;
   private GrammarRecognizer gr;

   private void Start()
    {
       
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, //load in Grammar
                                                "MenuGrammar.xml"), 
                                    ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Recogniser running");
    }


     private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder  message = new StringBuilder();
        Debug.Log("Recognised a phrase");
        SemanticMeaning[] meanings = args.semanticMeanings;
        foreach(SemanticMeaning meaning in meanings)
        {
            string  keyString = meaning.key.Trim();
            valueString = meaning.values[0].Trim();
            message.Append("Key: " + keyString + ", Value: " + valueString + " ");
        }
        // use a string builder to create the string and out put to the user
        Debug.Log(message);
    }



     void Update()
    {
        // depending on the command it will trigger a method

        switch (valueString)  
        {
            case "go to level select":
                LevelSelect();
                break;
            case "exit the game":
                Exit();
                break;
            case "go to tutorial":
                Tutorial();
                break;
            case "turn sound off":
                Mute();
                break;
           case "turn sound on":
                SoundOn();
                break;
            case "go to instructions":
                instructions();
                break;
            case "go back":
                Back();
                break;
            case "go to level one":
                Level1();
                break;

            case "go to level two":
                Level2();
                break;
            default:
                break;
        }
    }
    
    public void LevelSelect(){
        SceneManager.LoadScene("LevelSelect");

    }

    public void Level1(){
        SceneManager.LoadScene("Level1");

    }

    public void Level2(){
        SceneManager.LoadScene("Level2");

    }

     public void instructions(){
        SceneManager.LoadScene("Instructions");

    }

    public void Back(){
        SceneManager.LoadScene("Menu");

    }

    
    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");

    }


    public void Exit(){
        Debug.Log("QUIT");

        Application.Quit();

    }

     public void Mute(){    
        AudioListener.volume = 0f;
    }

    public void SoundOn(){    
        AudioListener.volume = 1f;
    }
}
