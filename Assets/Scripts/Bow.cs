using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    [SerializeField] GameObject m_arrow;
    [SerializeField] Transform m_arrowReference;
    [SerializeField] Character m_character;
    

    private void OnEnable()
    {
        m_character.OnFire.AddListener(Fire);
    }

    private void OnDisable()
    {
        m_character.OnFire.RemoveListener(Fire);
    }

    private void Fire()
    {
        Instantiate(m_arrow, m_arrowReference.position, m_arrowReference.rotation);
       // Destroy(this.m_arrow, 10);
    }
}
