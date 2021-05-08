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
        if(op == ")")
        {
            // 앞 (의 개수를 파악한 후 (보다 )가 더 많을 경우 리턴함
        }
        calcSystem.Calc = op;
    }

    public void OnClickResultButton()
    {
        
    }

    public void OnClickClearButton()
    {
        calcSystem.NumberList.Clear();
        calcSystem.RefreshCalculateUI();
    }

    public void OnClickBackspaceButton()
    {
        calcSystem.NumberList.RemoveAt(calcSystem.NumberList.Count - 1);
        calcSystem.RefreshCalculateUI();
    }
}
