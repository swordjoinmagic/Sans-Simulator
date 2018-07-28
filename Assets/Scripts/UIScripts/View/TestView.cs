using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using uMVVM;
using UnityEngine.UI;

namespace Assets.Scripts.UIScripts.View {
    class TestView : UnityGuiView<TestViewModel>{

        //===========================================
        //此View控制的UI控件
        public Text text;

        public void Awake() {
            BindingContext = new TestViewModel();

            // 显示该View
            Reveal();
        }

        protected override void OnInitialize() {
            base.OnInitialize();
            binder.Add<string>("text", OnTextValueChanged);
        }


        // 数据绑定事件
        private void OnTextValueChanged(string oldValue,string newValue) {
            text.text = newValue;
        }

    }
}
