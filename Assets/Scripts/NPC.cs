using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

    private enum NPCState { CHASE, PATROL };
    private NPCState m_NPCState;
    private NavMeshAgent m_NavMeshAgent;
    private int m_CurrentWaypoint;
    private bool m_IsPlayerNear;

    [SerializeField] float m_FieldOfView;
    [SerializeField] float m_ThresholdDistance;
    [SerializeField] private Transform[] m_Waypoints;
    [SerializeField] GameObject m_Player;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Manager m_Manager;

	// Use this for initialization
	void Start () {

        m_NPCState = NPCState.PATROL;
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

	    m_Animator = GetComponent<Animator>();
        m_CurrentWaypoint = 0;
	    
	    m_NavMeshAgent.updatePosition = false;
	    m_NavMeshAgent.updateRotation = true;

	    handleAnimation();
	}
	
	// Update is called once per frame
	void Update () {
	    CheckPlayer();
	    m_NavMeshAgent.nextPosition = transform.position;
	    
		switch(m_NPCState)
        {
            case NPCState.CHASE:
                Chase();
                break;
            case NPCState.PATROL:
                Patrol();
                break;
            default:
                break;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
        
        Gizmos.color = Color.yellow;
        Vector3 direction = m_Player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, direction);

        
        Vector3 rightDirection = Quaternion.AngleAxis(m_FieldOfView / 2, Vector3.up) * transform.forward;
        Vector3 leftDirection = Quaternion.AngleAxis(-m_FieldOfView / 2, Vector3.up) * transform.forward;
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rightDirection * 5.0f);
        Gizmos.DrawRay(transform.position, leftDirection * 5.0f);

    }

    void handleAnimation()
    {
        
        if (m_NPCState == NPCState.CHASE)
        {
            m_Animator.SetFloat("Forward", 2);
        }
        else
        {
            m_Animator.SetFloat("Forward", 1);
        }
    }
    void CheckPlayer()
    {
        if (m_NPCState == NPCState.PATROL && m_IsPlayerNear && CheckFieldOfView() && CheckOclusion())
        {
            m_NPCState = NPCState.CHASE;
            handleAnimation();
            return;
        }

        if (m_NPCState == NPCState.CHASE && !CheckOclusion())
        {
            m_NPCState = NPCState.PATROL;
            handleAnimation();
        }
    }
    
    void Chase()
    {
        m_NavMeshAgent.SetDestination(m_Player.transform.position);     
    }

    bool CheckFieldOfView()
    {
        Vector3 direction = m_Player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, direction)).eulerAngles;
        

        if (angle.y > 180.0f) angle.y = 360.0f - angle.y;
        else if (angle.y < -180.0f) angle.y = angle.y + 360.0f;
        

        if (angle.y < m_FieldOfView / 2)
        {
            return true;
        }

        return false;
    }

    bool CheckOclusion()
    {
        RaycastHit hit;
        Vector3 direction = m_Player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.gameObject == m_Player)
            {
                return true;
            }
        }
        return false;
    }

    void Patrol()
    {
        //Debug.Log("Patrolling");

        CheckWaypointDistance();
        m_NavMeshAgent.SetDestination(m_Waypoints[m_CurrentWaypoint].position);
    }

    void CheckWaypointDistance()
    {
        if(Vector3.Distance(m_Waypoints[m_CurrentWaypoint].position, this.transform.position) < m_ThresholdDistance)
        {
            m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length; 
        }
    }

    private void OnTriggerStay(Collider other) // CheckOclusion?
    {
        if (other.tag == "Player")
        {
            m_IsPlayerNear = true;
            m_Manager.DecreaseHealth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPlayerNear = false;
        }
    }
    
}
