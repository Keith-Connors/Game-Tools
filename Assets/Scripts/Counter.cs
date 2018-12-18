using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    [SerializeField] private Manager m_GameManager;
    [SerializeField] private Text m_PlayerHealth;
    [SerializeField] private Text m_KillCounter;
    [SerializeField] private Text m_AmmoCounter;
	
	// Update is called once per frame
	void Update ()
    {
        m_PlayerHealth.text = "Health: "+ m_GameManager.playerHealth.ToString("0"); //Display the Health value of the player, from the GameManager
        m_AmmoCounter.text = "Ammo: " + m_GameManager.PlayerArrows.ToString(); //Display the Ammo value of the player, from the GameManager
        m_KillCounter.text = "Kills: " + m_GameManager.Kills.ToString(); //Display the amount of kills from the GameManager
	}
}
