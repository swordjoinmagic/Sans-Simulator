using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
class FightView : UnityGuiView<FightViewModel>{

    //===================================
    // 此View管理的控件
    new CanvasGroup canvasGroup;
    public Selectable forcus;
    private EventTrigger eventTrigger;

    private void Awake() {

        eventTrigger = GetComponent<EventTrigger>();

        BindingContext = new FightViewModel();

        BindingContext.isActived.Value = false;
    }

    private void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<bool>("isActived",OnActivedChanged);

        // 为EventTrigger注册事件
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Submit;
        entry.callback.AddListener(eventData => { print("单击了选择战斗按钮"); });

        eventTrigger.triggers.Add(entry);
    }

    private void OnActivedChanged(bool oldValue,bool newValue) {
        canvasGroup.interactable = newValue;
        if (newValue) forcus.Select();
    }
}

