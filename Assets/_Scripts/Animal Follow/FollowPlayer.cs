using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    Transform player = null;
    private Animator Anim;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        if (GetComponent<NavMeshAgent>() != null)
            agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            player = other.transform;
            Anim.SetBool(Constants.Walk, true);
        }
    }
    

    private void Update()
    {
        if (player == null) return;
        agent.SetDestination(player.position);
        if (PlayerController.stop == true)
        {
            Anim.SetBool(Constants.Walk, false);
        }
       
    }
}