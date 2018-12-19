using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private float m_PlayerHealth = 100;
    [SerializeField] public int PlayerArrows;
    [SerializeField] private int MaxArrows = 10;
    [SerializeField] public int Kills;

    [Header("Arrow UI Information")]
    public GameObject ArrowsFull;
    public GameObject ArrowsEmpty;


    private void Update()
    {
        if (PlayerArrows > MaxArrows)
        {
            PlayerArrows = MaxArrows;
            ArrowsFull.SetActive(true);
        }
    }

    public void DecreaseHealth()
    {
        m_PlayerHealth--;
    }

    private void CheckHealth()
    {
        if (m_PlayerHealth <= 0.0f)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public float playerHealth
    
        {
            get { return m_PlayerHealth; }
            set { m_PlayerHealth = value; }
        }
}