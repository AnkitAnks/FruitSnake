using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeCollisionController : MonoBehaviour
{
    public SnakeController snakeController;

    private void Awake()
    {
        snakeController.GetComponent<SnakeController>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("LoaderScreen");
        }
        else if (collision.gameObject.tag == "Body")
        {
            if(snakeController.bodyParts.Count >= 3)
            {
                SceneManager.LoadScene("LoaderScreen");
            }
        }
        else if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            snakeController.GrowSnake();
            
        }
    }
}
