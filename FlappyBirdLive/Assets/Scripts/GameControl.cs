using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{   
    public GameObject gameOverText;
    public int gameOver = 0;
    
    
    public static GameControl instance;
    public float scrollSpeed = -1.5f;
    public Text scoreText;
    
    private int score = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == 2 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))){
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        }
    }
    
    public void BirdScored(){
        
        
        if(gameOver == 2){
            return;
        }else{
         
            score++;
            scoreText.text = "Score: " + score.ToString();

        }

    }
    
    public void BirdDied(){
        gameOver++;
        if(gameOver == 2){
            gameOverText.SetActive(true);
        }
    }
}
