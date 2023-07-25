using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pindahscene11 : MonoBehaviour
{
    public Objective objectiveLevel;
    [SerializeField] private string newscene;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectiveLevel.IsDone()) return;

        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newscene);
        }
    }
}

