using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeCollisionController : MonoBehaviour
{
    // Reference to SnakeController
    public SnakeController snakeController;

    public Score score;

    public GameObject endScreen;

    private void Awake()
    {
        snakeController.GetComponent<SnakeController>();
        score = gameObject.GetComponent<Score>();  
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            StartCoroutine("EndScreenManager");
            //SceneManager.LoadScene("LoaderScreen");
        }
        else if (collision.gameObject.tag == "Body")
        {
            if(snakeController.bodyParts.Count > 3)
            {
                StartCoroutine("EndScreenManager");
                //SceneManager.LoadScene("LoaderScreen");
            }
        }
        else if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            snakeController.GrowSnake();
            score.UpdateScore();
            
        }
    }

    IEnumerator EndScreenManager()
    {
        snakeController.moveSpeed = 0;
        snakeController.bodySpeed = 0;
        score.SetScore();
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("LoaderScreen");
        yield return null;
    }
}
