using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech; 
using System.IO;
using System.Text;
public class UIController : MonoBehaviour
{
    [SerializeField] private string valueString;
    private GrammarRecognizer gr;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    public  float speed = 10f;
    bool move = false;
    
    private void Start()
    { 

        Time.timeScale =0f;
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, 
        "MenuGrammar.xml"), ConfidenceLevel.Low);
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
        Debug.Log(message);
    }
    void Update()
    {

        if(move == true){
                player.transform.position += transform.forward * Time.deltaTime * speed;
                
            }

    switch (valueString)
        {
            case "pause the game":
                Pause();
                break;
            case "resume the game":
                Resume();
                break;
            case "start the game":
                movePlayer();
                break;
            case "restart the game":
                Restart();
                break;
            case "quit the game":
                LoadMenu();
                break;
            case "turn sound off":
                Mute();
                break;
            case "turn sound on":
                SoundOn();
                break;
            default:
                break;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        GameIsPaused = false;

    }
    public void movePlayer(){
        Time.timeScale =1f;
        move = true;
    }

    
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        GameIsPaused = true;

    }


    public void Options(){
        pauseMenuUI.SetActive(false);
        Time.timeScale =0f;
        GameIsPaused = true;
    
    }

    public void Return(){
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        GameIsPaused = true;
      

    }
    public void Mute(){    
        AudioListener.volume = 0f;
    }

    public void SoundOn(){    
        AudioListener.volume = 1f;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale =1f;      
    }


    public void Restart(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
        Time.timeScale =1f;
    }
}
