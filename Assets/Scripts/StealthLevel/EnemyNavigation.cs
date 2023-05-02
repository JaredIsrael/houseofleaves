using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    NavMeshAgent enemy;

    [SerializeField] float speed = 20f;
    [SerializeField] float walkRadius = 8f;

    Renderer ren;
    public bool investigating = false;
    public bool locationChosen = false;

    public bool restartLevel = false;

    void Start()
    {
        ren = this.GetComponent<Renderer>();
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = speed;
        enemy.SetDestination(randomNavMeshLocation());
    }

    void Update()
    {
        if (!investigating && enemy.remainingDistance <= enemy.stoppingDistance)
        {
            if (!locationChosen)
            {
                StartCoroutine(newDestination());
            }
        }
    }

    Vector3 randomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += this.transform.position;

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
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
        locationChosen = true;

        yield return new WaitForSeconds(1);
        enemy.SetDestination(randomNavMeshLocation());

        locationChosen = false;
    }

    IEnumerator heardSomething(Vector3 position)
    {
        enemy.SetDestination(position);
        enemy.isStopped = false;

        yield return new WaitForSeconds(5);

        enemy.speed = speed;
        investigating = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player") && !restartLevel)
        {
            Debug.Log("Restart Level");
            restartLevel = true;
        }
    }
}