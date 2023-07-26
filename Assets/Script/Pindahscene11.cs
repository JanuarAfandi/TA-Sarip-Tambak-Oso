using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pindahscene11 : MonoBehaviour
{
    public List<Objective> objectiveLevel;
    [SerializeField] private string newscene;
    
    private bool IsObjectiveDone() {
        foreach (Objective obj in objectiveLevel) {
            if (!obj.IsDone())
                return false;
        }
        
        return true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsObjectiveDone()) 
            return;

        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newscene);
        }
    }
}

