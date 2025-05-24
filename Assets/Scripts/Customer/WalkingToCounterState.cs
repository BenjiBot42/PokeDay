using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingToCounterState : CustomerState
{
    public WalkingToCounterState(Customer customer) : base(customer) {}

    public override void Enter()
    {
        customer.PlayAnimation("WalkUp");
        customer.MoveTo(customer.counterPostion);
    }

    public override void Update()
    {
        if(customer.ReachedDestination())
        {
            customer.SetState(new WaitingForOrderState(customer));
        }
    }
}
