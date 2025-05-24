using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForOrderState : CustomerState
{
    public WaitingForOrderState(Customer customer) : base(customer) {}

    public override void Enter()
    {
        customer.PlayAnimation("Waiting");
        customer.ShowOrder();
        customer.NotifyPlayerOfOrder();
    }

    public override void Update()
    {
        if(customer.orderTaken)
        {
            customer.SetState(new WaitingForFoodState(customer));
        }
    }
}
