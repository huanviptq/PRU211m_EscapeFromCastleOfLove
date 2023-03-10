using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] float loadSceneDelay = 2f;

    void Start(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame(){
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Level 1");
    }

    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().name == "Level 1"){
            StartCoroutine(WaitAndLoad("Level 2", loadSceneDelay));
        }
        if(SceneManager.GetActiveScene().name == "Level 2"){
            StartCoroutine(WaitAndLoad("Level 3", loadSceneDelay));
        }
        if(SceneManager.GetActiveScene().name == "Level 3"){
            LoadGameOver();
        }
    }

    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("Game Over", loadSceneDelay));
    }

    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
