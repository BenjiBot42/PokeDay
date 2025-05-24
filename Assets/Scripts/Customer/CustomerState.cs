using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerState
{
    protected Customer customer;

    public CustomerState(Customer customer)
    {   
        this.customer = customer;
    }

    public virtual void Enter() {}
    public virtual void Update() {}
    public virtual void Exit() {}

}
