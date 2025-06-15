using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForFoodState : CustomerState
{
    public WaitingForFoodState(Customer customer) : base(customer) {}

    public override void Enter()
    {
        customer.PlayAnimation("Waiting");
    }

    public override void Update()
    {
        if(customer.GetorderFulfilled())
        {
            customer.HideOrder();
            customer.SetState(new LeavingState(customer));
        }
    }
}
