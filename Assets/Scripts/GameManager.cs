using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded; 

    public GameObject gameOverUI; 

    public GameObject completeLevelUI;
    
    void Start(){
        gameEnded = false;
    }


    void Update()
    {
        if(gameEnded){
            return;
        }

        if(PlayerStats.Lives <=0){
            EndGame();
        }
    }

    void EndGame(){
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel(){
        gameEnded = true; 
        completeLevelUI.SetActive(true);
    }
}
