using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour{
    //public HPModel hPModel;
    public HPView hpView;

    private float time = 0;

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.CompareTag("bone")) {

            // 每隔0.1s触发一次
            time += Time.deltaTime;
            if (time > 0.02f) {
                time = 0;
            } else if (time < 0.1f){
                return;
            }

            if(hpView.BindingContext.HP.Value>0)
                hpView.BindingContext.HP.Value -= 1;
        }
    }

}

