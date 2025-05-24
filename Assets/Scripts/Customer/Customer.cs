using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private CustomerState currentState;

    private Animator animator;

    public Vector2 counterPostion;
    public Vector2 exitPosition;
    public bool orderTaken = false;
    public bool orderFulfilled = false;

    private Vector2 currentTarget;
    private float moveSpeed = 2f;

    private void Awake()
    {
        if(animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        SetState(new WalkingToCounterState(this));
    }

    private void Update()
    {
        currentState?.Update();

        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
    }

    public void PlayAnimation(string animName)
    {
        if(animator != null)
        {
            animator.Play(animName);
        }
    }

    public void SetState(CustomerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetPatrolPoints(Vector2 counterPos, Vector2 exitPos)
    {
        this.counterPostion = counterPos;
        this.exitPosition = exitPos;
    }

    public void MoveTo(Vector2 position)
    {
        currentTarget = position;
    }

    public bool ReachedDestination()
    {
        return Vector2.Distance(transform.position, currentTarget) < 0.2f;
    }
    
    public void ShowOrder() { /* TODO: SHOW ORDER UI*/ }
    public void HideOrder() { /* TODO: HIDE ORDER UI*/ }
    public void NotifyPlayerOfOrder(){}

    public void OnOrderTaken()
    {
        orderTaken = true;
    }

    public void OnOrderFulfilled()
    {
        orderFulfilled = true;
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
