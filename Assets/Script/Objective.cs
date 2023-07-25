using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour
{
   public virtual bool IsDone() {
       return true;
   }
}
