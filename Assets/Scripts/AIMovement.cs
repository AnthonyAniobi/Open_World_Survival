using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minMoveTime = 1f;
    [SerializeField] private float maxMoveTime = 3f;
    [SerializeField] private float minIdleTime = 1f;
    [SerializeField] private float maxIdleTime = 3f;
    private Animator animator;
    private float moveTime;
    private float idleTime;
    private float currentMoveTime;
    private float currentIdleTime;
    private int direction = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        ResetTimers();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMoveTime > 0)
        {
            Move();
            currentMoveTime -= Time.deltaTime;
        }
        else if (currentIdleTime > 0)
        {
            Idle();
            currentIdleTime -= Time.deltaTime;
        }
        else
        {
            ResetTimers();
        }
    }

    private void Move()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion lookRotation = Quaternion.identity;
        switch (direction)
        {
            case 0: // forward
                lookRotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 1: // backward
                lookRotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 2: // left
                lookRotation = Quaternion.Euler(0f, 270f, 0f);
                break;
            case 3: // right
                lookRotation = Quaternion.Euler(0f, 90f, 0f);
                break;
        }
        currentMoveTime -= Time.deltaTime;
        transform.localRotation = lookRotation;
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        animator.SetBool("IsMoving", true);
    }

    private void Idle()
    {
        currentIdleTime -= Time.deltaTime;
        animator.SetBool("IsMoving", false);
    }

    private void ResetTimers()
    {
        direction = Random.Range(0, 4); // 0: forward, 1: backward, 2: left, 3: right
        moveTime = Random.Range(minMoveTime, maxMoveTime);
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        currentMoveTime = moveTime;
        currentIdleTime = idleTime;
    }
}
