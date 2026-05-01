using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameHandler : MonoBehaviour
{
    [Header("Scene Stats")]
    public static int currentScene = 0; //current scene
	private string sceneName;
    public static bool inMenu = true;

    [Header("Player Stats")]

	private GameObject player;
    //private Renderer playerRenderer;
	
    public static int currencyCount = 100;
    
   
    [Header("UI elements")]
    //Something something TextTMP Coins or something

    public TMP_Text VariableText;

    private void Awake()
    {
        //if (SceneManager.GetActiveScene().name != "Shop")
        //{
        //    sceneName = SceneManager.GetActiveScene().name;
        //}

        //make sure currentScene is accurate
        switch (sceneName)
        {
            case "Scene0": currentScene = 0; break;
            case "Scene1": currentScene = 1; break;
            case "Scene2": currentScene = 2; break;
        }
        Debug.Log("current scene: " + currentScene);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Credits" && SceneManager.GetActiveScene().name != "MainMenu")
        {
            //somethingupdate();  
        }
    }

    private void Update()
    {
            //????++;
    }
    void FixedUpdate()
    {

        
    }
//fuckign hell my mouse i hate my life why is it doing this


    //STATE CHANGES
    public void EnterMenu() //entering a menu
    {
		//Debug.Log("EnteringMenu");
        inMenu = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadLevel() //exiting ???, entering level
    {
        SceneManager.LoadScene("Scene" + (currentScene + 1));
        inMenu = false;
    }
    public void StartGame() {
            SceneManager.LoadScene("Scene0");
        inMenu = false;
      }

      // Return to MainMenu
      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
            ResetStats(); // Reset all static variables here, for new games:
            EnterMenu();
    }


      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
        inMenu = true;
    } 

      public void ResetStats()
      {
        currentScene = 0; //current scene
    //float levelTimer = 0; //current time elapsed in level
      }

      

}
