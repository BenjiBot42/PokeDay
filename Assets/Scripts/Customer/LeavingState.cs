using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingState : CustomerState
{
    public LeavingState(Customer customer) : base(customer) {}

    public override void Enter()
    {
        customer.PlayAnimation("WalkDown");
        customer.MoveTo(customer.exitPosition);
    }

    public override void Update()
    {
        if(customer.ReachedDestination())
        {
            customer.Despawn();
        }
    }
}
