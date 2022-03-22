using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
   
    public void Setup(){
        gameObject.SetActive(true);

    }

    public void RestartButton() {

        SceneManager.LoadScene("working2");
    }

    public void ExitButton(){

        Application.Quit();
    }
}
