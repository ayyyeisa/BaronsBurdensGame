using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SkipIntroScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayDragon()
    {
        //Opens Dragon Riding Scene from Menu
        EditorSceneManager.LoadScene(2);
    }
    public void PlayCatapult()
    {
        //Opens Catapult Scene from Menu
        EditorSceneManager.LoadScene(3);
    }
    public void PlayDuel()
    {
        //Opens Duel Scene from Menu
        EditorSceneManager.LoadScene(4);

    }
    public void QuitGame()
    {
         Debug.Log("Quit");
        //On Selction of the Quit Button, Game will close
        Application.Quit();
        
       
    }



}
