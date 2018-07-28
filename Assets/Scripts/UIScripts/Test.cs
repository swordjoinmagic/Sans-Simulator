using Assets.Scripts.UIScripts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIScripts {
    class Test : MonoBehaviour{

        public TestView testView;
        public InputField input;

        private void Awake() {
            //input = GetComponent<InputField>();
        }

        public void ValueChange() {
            testView.BindingContext.text.Value = input.text;
        }
    }
}
