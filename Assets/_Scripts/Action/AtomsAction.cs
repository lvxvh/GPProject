﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;



public class AtomsAction : VRTK_InteractableObject
{
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        print("start use atom");
        base.StartUsing(usingObject);
        GameManager.SetSelectedComponent(gameObject);
        GameObject.FindGameObjectWithTag("EventManager").GetComponent<UiDisplayController>().ShowComponentOpCanvas(true, gameObject);
    }

    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        print("stop use atom");
        base.StopUsing(usingObject);
        

        GameManager.CancelComponentSelected();
        GameObject.FindGameObjectWithTag("EventManager").GetComponent<UiDisplayController>().ShowComponentOpCanvas(false, gameObject);

        gameObject.GetComponentInParent<MoleculesAction>().DisableAllComponent();

        StartCoroutine(CountDown());
        
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInParent<MoleculesAction>().RemoveComponentsAction();
    }

    private void ShowComponentOperationCanvas()
    {
        
        print("atom id: " + gameObject.GetComponent<Atom>().Id);
    }
}
