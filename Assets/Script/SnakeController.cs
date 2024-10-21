using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bodySpeed = 2f;
    public int steerSpeed = 100;
    public int gap = 10;

    float hInput, vInput;

    public FixedJoystick joystick;

    public GameObject snakeBody;

    public GameObject firstSnakeBody;

    public List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    private void Start()
    {
        bodyParts.Add(firstSnakeBody);
    }


    void FixedUpdate()
    {
        //move the head forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //steer
        hInput = joystick.Horizontal;
        vInput = joystick.Vertical;
        
        transform.Rotate(transform.up * hInput * moveSpeed * steerSpeed * Time.deltaTime);

        //store position history
        positionHistory.Insert(0, transform.position);

        //move body parts
        int index = 0;
        foreach(var part in bodyParts)
        {
            Vector3 point = positionHistory[Mathf.Min(positionHistory.Count - 1, index * gap)];
            Vector3 moveDirection = point - part.transform.position;
            part.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            part.transform.LookAt(point);
            index++;
        }
    }

    public void GrowSnake()
    {
        Vector3 spawnPosition = bodyParts.Count == 0 ? transform.position : bodyParts[bodyParts.Count - 1].transform.position;
        GameObject body = Instantiate(snakeBody,spawnPosition,Quaternion.identity);
        bodyParts.Add(body);
    }
}
