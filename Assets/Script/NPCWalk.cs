using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalk : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject path;
    private Transform[] pathPoints;

    public int index;

    public int minDistance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        pathPoints = new Transform[path.transform.childCount];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i] = path.transform.GetChild(i);
        }
    }

    void Update()
    {
        Roam();
    }

    void Roam()
    {
        if (Vector3.Distance(transform.position, pathPoints[index].position) < minDistance)
        {
            if (index > 0 && index < pathPoints.Length)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
        }

        agent.SetDestination(pathPoints[index].position);
        animator.SetFloat("Vertical", !agent.isStopped ? 1 : 0);
    }
}
