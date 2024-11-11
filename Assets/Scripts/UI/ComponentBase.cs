using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class ComponentBase : MonoBehaviour
    {
        public abstract void Draw();

        public abstract void Undraw();

        public abstract void Refresh();
    }
}