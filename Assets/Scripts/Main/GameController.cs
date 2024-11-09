using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameController : MonoBehaviour
    {
        private void Awake()
        {
            Find.ScriptManager = Engine.GetService<IScriptManager>();
        }
    }
}