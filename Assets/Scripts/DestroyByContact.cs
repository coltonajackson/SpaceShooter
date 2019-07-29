using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject!=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            gameController = new GameController();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        if (this.gameObject.tag != "Player")
        {
            if (SceneManager.GetActiveScene().name != "MainMenu" && (this.gameObject.tag == "Asteroid" || this.gameObject.tag == "Enemy"))
            {
                gameController.AddScore(scoreValue);
            }
            if (this.gameObject.tag == "Enemy")
            {
                gameController.AddEnemy(1);
            }
            Destroy(this.gameObject);
        }
        else
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    
}
