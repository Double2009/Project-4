using UnityEngine;

public class GameOver : MonoBehaviour
{

    public bool gameEnded = false; 
    // Update is called once per frame
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
        Debug.Log("Game Over");
    }
}
