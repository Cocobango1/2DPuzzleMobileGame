using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class Move : MonoBehaviour
{
    public UnityEvent moveEvent;

    public Vector2Int targetPosition;
    public Vector2Int direction;
    public float speed;
    [SerializeField] private int moveCounter = 23;
    Vector3 move;
    //public static int scoreValue = 23;
    

   // private void Start()
   // {
        
//    }

    private void Awake()
    {
        targetPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        move.x = (int)Input.GetAxisRaw("Horizontal");
        move.y = (int)Input.GetAxisRaw("Vertical");
        var moving = (Vector2)transform.position != targetPosition;

        if (moving)
        {
            MoveTowardsTargetPosition();
        }
        else
        {
            SetNewTargetPositionFromInput();
        }

        
    } 

    private void MoveTowardsTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void SetNewTargetPositionFromInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2Int.up;
            targetPosition += direction;
            CheckForObject();
            PlayerMoved();
        }if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2Int.down;
            targetPosition += direction;
            CheckForObject();
            PlayerMoved();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2Int.left;
            targetPosition += direction;
            CheckForObject();
            PlayerMoved();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2Int.right;
            targetPosition += direction;
            CheckForObject();
            PlayerMoved();
        }

        //else if
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            PlayerMoved();
        }
    }

    public void PlayerMoved()
    {
        //animator.SetTrigger("WhateveritsCalled");
        moveCounter--;
        CheckIfGameOver();
        moveEvent?.Invoke();
    }

    private void CheckIfGameOver()
    {
        if (moveCounter <= 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CheckForObject()
    {
        GetComponent<FindObject>().CheckArea(targetPosition, direction);
    }
}
