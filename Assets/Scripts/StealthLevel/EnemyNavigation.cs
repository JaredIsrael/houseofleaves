using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    NavMeshAgent enemy;

    float speed = 2;
    float walkRadius = 10;

    Renderer ren;
    public bool investigating = false;

    void Start()
    {
        ren = this.GetComponent<Renderer>();
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = speed;
        enemy.SetDestination(randomNavMeshLocation());
    }

    void Update()
    {
        if(!investigating && enemy.remainingDistance <= enemy.stoppingDistance)
        {
            ren.material.color = Color.gray;
            StartCoroutine(newDestination());
        }
    }

    Vector3 randomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += this.transform.position;

        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    public void investigate(Vector3 position)
    {
        investigating = true;
        enemy.isStopped = true;

        enemy.speed = speed + 1;

        StartCoroutine(heardSomething(position));
    }

    IEnumerator newDestination()
    {
        yield return new WaitForSeconds(1);

        enemy.SetDestination(randomNavMeshLocation());
    }

    IEnumerator heardSomething(Vector3 position)
    {
        enemy.SetDestination(position);
        ren.material.color = Color.red;
        enemy.isStopped = false;

        yield return new WaitForSeconds(5);

        enemy.speed = speed;
        investigating = false;
    }
}
