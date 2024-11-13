using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class QuestMessageSubcomponent : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;

        private void Start()
        {
            StartCoroutine(StartDecaying());
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public IEnumerator StartDecaying()
        {
            yield return new WaitForSeconds(5f);
            Destroy(this.gameObject);
        }
    }
}