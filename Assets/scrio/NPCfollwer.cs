using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class NPCfollwer : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform tramsformFfollwer;
    [SerializeField] Vector3 sizeOfView;
    [SerializeField] LayerMask whatIsCharacter;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        FindCharcterToFollow();

        if (tramsformFfollwer == null) { return; }

        agent.SetDestination(tramsformFfollwer.position);  
    }

    void FindCharcterToFollow()
    {
        if (tramsformFfollwer != null) { return; }

        var characters = Physics.OverlapBox(transform.position, sizeOfView, Quaternion.identity,whatIsCharacter);
        if (characters.Length > 0)
        {
            tramsformFfollwer = characters[0].transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, sizeOfView);
    }




}
