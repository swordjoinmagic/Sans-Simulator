using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleButtonsView : UnityGuiView<BattleButtonsViewModel>{
    //=================================
    // 此View管理的控件
    public Button fightButton;
    public Button moveButton;
    public Button itemButton;
    public Button mercyButton;
    public AudioManagement audioManagement;
    private EventTrigger eventTriggerFightButton;
    private EventTrigger eventTriggerMoveButton;
    private EventTrigger eventTriggerItemButton;
    private EventTrigger eventTriggerMercyButton;
    public CanvasGroup cG;
    public FightView fightView;

    private void Awake() {

        eventTriggerFightButton = fightButton.GetComponent<EventTrigger>();
        eventTriggerMoveButton = moveButton.GetComponent<EventTrigger>();
        eventTriggerItemButton = itemButton.GetComponent<EventTrigger>();
        eventTriggerMercyButton = mercyButton.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry {
            eventID = EventTriggerType.Select
        };
        entry.callback.AddListener(eventdata => { OnSelectButton();});
        eventTriggerFightButton.triggers.Add(entry);
        eventTriggerMoveButton.triggers.Add(entry);
        eventTriggerItemButton.triggers.Add(entry);
        eventTriggerMercyButton.triggers.Add(entry);


        //BindingContext = new BattleButtonsViewModel();
        //BindingContext.isActive.Value = true;
    }

    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<bool>("isActive",OnActiveChanged);

        // 为各个按钮注册事件
        fightButton.onClick.AddListener(OnClickFightButton);

    }

    private void OnActiveChanged(bool oldValue,bool newValue) {
        cG.interactable = newValue;
        if (newValue) {
            print("battleButtonView的Actied改变,同时,自动选择fightButton");
            fightButton.Select();
        }
    }

    /// <summary>
    /// 按下战斗按钮后
    /// </summary>
    private void OnClickFightButton() {
        // 首先将当前CanvasGroup的interactable设为false
        cG.interactable = false;
        // 发出声音
        audioManagement.Audios["menuselect"].Play();
        // 显示FightView
        fightView.Reveal(immediate:true);
        // 然后发布消息,让订阅该消息的FightViewModele处理,
        // 将FightView中的interactable设为true,同时将当前forcus放到该View上
        MessageAggregator<bool>.Instance.Publish("FightViewActiveChanged",this,new MessageArgs<bool>(item:true));
    }

    private void OnSelectButton() {
        audioManagement.Audios["menucursor"].Play();
    }
}

