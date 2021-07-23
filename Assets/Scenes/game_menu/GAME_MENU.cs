using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_MENU : MonoBehaviour
{
 public void play(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
 }
public void endgame(){
    Debug.Log("END");
    Application.Quit();
}
}
