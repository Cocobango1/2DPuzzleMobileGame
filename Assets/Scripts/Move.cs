using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class DashEvent : UnityEvent<Vector2Int> { }

[System.Serializable]
public class HitEvent : UnityEvent<Vector2Int> { }

public class Move : MonoBehaviour
{
    [SerializeField]private DashEvent DashEvent;
    [SerializeField]private HitEvent HitEvent;
    public UnityEvent moveEvent;

    public Vector2Int targetPosition;
    Vector2Int currentPosition;
    public Vector2Int direction = Vector2Int.zero;
    public float speed;
    [SerializeField] private int moveCounter = 23;
    private bool playerBlocked = false;
    Vector3 move;
    public Animator animator;
    
    private void Awake()
    {
        GetPositions();
        transform.position = (Vector2)targetPosition;
    }

    private void Update()
    {
        move.x = (int)Input.GetAxisRaw("Horizontal");
        move.y = (int)Input.GetAxisRaw("Vertical");
        var moving = (Vector2)transform.position != targetPosition;

        if (moving && !playerBlocked)
        {
            MoveTowardsTargetPosition();
        }
        else
        {
            GetComponent<LayerOrder>().SetlayerOrder();
            SetNewTargetPositionFromInput();
        }
    } 

    private void MoveTowardsTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        targetPosition = currentPosition + direction;
    }

    private void GetPositions()
    {
        currentPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        targetPosition = currentPosition + direction;
    }

    private void SetNewTargetPositionFromInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2Int.up;
            GetPositions();
            CheckForObject();
            PlayerMoved();
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2Int.down;
            GetPositions();
            CheckForObject();
            PlayerMoved();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2Int.left;
            GetPositions();
            CheckForObject();
            PlayerMoved();
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2Int.right;
            GetPositions();
            CheckForObject();
            PlayerMoved();
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        else
            {
            animator.SetBool("isIdle", true);
        }
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
        if (!playerBlocked)
        {
            animator.SetTrigger("isWalking");
            DashEvent?.Invoke(direction);
        }
        moveCounter--;
        CheckIfGameOver();
        moveEvent?.Invoke();
    }

    private void CheckIfGameOver()
    {
        if (moveCounter < 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CheckForObject()
    {
        playerBlocked = GetComponent<FindObject>().CheckArea(targetPosition, direction);

        if (playerBlocked)
        {
            animator.SetTrigger("isPushing");
            HitEvent?.Invoke(direction);
        }
    }
}
