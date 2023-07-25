using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveChapter1 : Objective
{
    public bool IsDoneChatWithNPC = false;

    public void DoneChat() {
        IsDoneChatWithNPC = true;
    }

    public override bool IsDone()
    {
        return IsDoneChatWithNPC;
    }
}
