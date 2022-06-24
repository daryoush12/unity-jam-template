using Doozy.Engine;
using Doozy.Engine.Nody.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventInvoker : MonoBehaviour
{

    private void Start()
    {
        Message.Send("onLevelCompleted");
    }
}
