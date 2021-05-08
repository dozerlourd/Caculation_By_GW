using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorButtonScript : MonoBehaviour
{
    CalculateSystem calcSystem;

    private void Awake()
    {
         calcSystem = CalculateSystem.Instance;
    }

    public void OnClickOperatorButton(string op)
    {
        calcSystem.Calc = op;
    }

    public void OnClickResultButton()
    {

    }

    public void OnClickClearButton()
    {

    }

    public void OnClickBackspaceButton()
    {

    }
}
