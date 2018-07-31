using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class FightView : UnityGuiView<FightViewModel> {

    //===================================
    // 此View管理的控件
    CanvasGroup cG;
    public Selectable forcus;
    public AudioManagement AudioManagement;
    private EventTrigger eventTrigger;

    private void Awake() {

        eventTrigger = GetComponent<EventTrigger>();

        BindingContext = new FightViewModel();

        BindingContext.isActived.Value = false;
    }

    private void Start() {
        cG = GetComponent<CanvasGroup>();
    }

    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<bool>("isActived", OnActivedChanged);

        // 为EventTrigger注册事件
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Submit;
        entry.callback.AddListener(eventData => Attack());

        eventTrigger.triggers.Add(entry);
    }

    private void OnActivedChanged(bool oldValue, bool newValue) {
        cG.interactable = newValue;
        if (newValue) forcus.Select();
        else Hide(immediate: true);
    }

    // Submit事件函数
    private void Attack() {
        // 播放声音
        AudioManagement.Audios["menuselect"].Play();
        // 设置当前面板的可活动性为false
        BindingContext.isActived.Value = false;
        // 播放攻击动画,同时敌人受伤
        MessageAggregator<int>.Instance.Publish("SansInjured",this,null);
        // 玩家本回合结束
    }
}

