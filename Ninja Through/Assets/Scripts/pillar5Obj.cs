using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar5Obj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Assets.Scripts.Globals.ClickValidation = true;

        Assets.Scripts.Globals.MovingPillarID = 5;
    }
}
