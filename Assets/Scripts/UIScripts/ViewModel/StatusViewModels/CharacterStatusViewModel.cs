using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

public class CharacterStatusViewModel : ViewModelBase{
    public BindableProperty<string> Name = new BindableProperty<string>();
    public BindableProperty<string> Level = new BindableProperty<string>();
    public BindableProperty<HPModel> HPModel = new BindableProperty<HPModel>();

    public void Init(CharacterStatusModel characterStatusModel) {
        Name.Value = characterStatusModel.name;
        Level.Value = characterStatusModel.level;
        HPModel.Value = characterStatusModel.hPModel;
    }
}
