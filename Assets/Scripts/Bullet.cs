using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody m_rigidbody;
    [SerializeField] float m_power;
    [SerializeField] float Damage = 50;
    [SerializeField] NPCHandler m_NPCHander;
    
    
    private void OnEnable()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_power);
    }

    private void OnCollisionEnter(Collision collider)
    {
        if(collider.collider.tag == "NPC")
        {
            m_NPCHander.enemyHealth = m_NPCHander.enemyHealth - Damage;
        }
    }

}
