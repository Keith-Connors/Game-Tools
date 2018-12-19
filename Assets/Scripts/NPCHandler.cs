using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour {

    [SerializeField] float NPCHealth;

    public void NPCDeath()
    {
            Destroy(gameObject);   
    }
	// Update is called once per frame
	void Update ()
    {
	if (NPCHealth <= 0)
        {
            NPCDeath(); //Kill the NPC
        }
	}

    public float enemyHealth

    {
        get { return NPCHealth; }
        set { NPCHealth = value; }
    }
}
