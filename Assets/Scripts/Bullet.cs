using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody m_rigidbody;
    [SerializeField] float m_power;
    // Use this for initialization

    private void OnEnable()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_power);
    }


}
