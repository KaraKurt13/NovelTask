using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _spriteRenderer;

        [SerializeField] Button _button;

        public ItemTypeEnum ItemType;

        public void Activate()
        {

        }
    }
}