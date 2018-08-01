using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

    public CharacterStatusView characterStatusView;

	// Use this for initialization
	void Start () {
        characterStatusView.BindingContext.Name.Value = "sjm";
        characterStatusView.BindingContext.Level.Value = "19";
        characterStatusView.BindingContext.HPModel.Value = new HPModel { Hp=50,maxHp=50 };
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            HPModel hPModel = characterStatusView.BindingContext.HPModel.Value as HPModel;
            characterStatusView.BindingContext.HPModel.Value = new HPModel { Hp = hPModel.Hp-10,maxHp=hPModel.maxHp };

        }
	}
}
