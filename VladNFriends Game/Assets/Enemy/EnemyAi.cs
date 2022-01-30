using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    public GameObject enemy;
    public Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = enemy.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(target.transform.position, gameObject.transform.position) > 1.5f)
        {
            agent.SetDestination(target.position);

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);

            agent.SetDestination(transform.position);

            Debug.Log("i catch");

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
