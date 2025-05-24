using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPrefabs;

    [SerializeField] private Transform counterPoint;
    [SerializeField] private Transform exitPoint;

    [SerializeField] private float spawnInterval;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCustomer();
        }
    }

    public void SpawnCustomer()
    {
        GameObject prefab = customerPrefabs[Random.Range(0, customerPrefabs.Length)];
        GameObject newCustomer = Instantiate(prefab, exitPoint);

        Customer customer = newCustomer.GetComponent<Customer>();
        customer.SetPatrolPoints(counterPoint.position, exitPoint.position);
    }

}
