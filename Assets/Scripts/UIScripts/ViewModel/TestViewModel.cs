using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uMVVM;

public class TestViewModel : ViewModelBase{
    public BindableProperty<string> text = new BindableProperty<string>();
}
