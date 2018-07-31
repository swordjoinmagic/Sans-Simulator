using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Test4 : MonoBehaviour{
    public Animator animator;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            animator.SetTrigger("downAttack");
        }
    }
}

