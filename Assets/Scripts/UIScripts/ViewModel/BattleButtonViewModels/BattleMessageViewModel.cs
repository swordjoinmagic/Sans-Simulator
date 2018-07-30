using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

/// <summary>
/// 用来管理战斗中，对角色的提醒对话
/// </summary>
public class BattleMessageViewModel : ViewModelBase{
    public BindableProperty<string> Message = new BindableProperty<string>();
}
