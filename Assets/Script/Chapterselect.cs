using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Chapterselect : MonoBehaviour
{
    // Start is called before the first frame update
     public void selectChapter(){
       switch (this.gameObject.name){
           case "chprologue":
                SceneManager.LoadScene ("Prologue");
                break;
           case "ch1":
                SceneManager.LoadScene ("Chapter 1");
                break;
            case "ch2":
                SceneManager.LoadScene ("Chapter 2");
                break;
            case "ch3":
                SceneManager.LoadScene ("Chapter 3");
                break;
       }
}
}
