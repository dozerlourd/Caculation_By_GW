using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButtonScript : MonoBehaviour
{
    CalculateSystem calcSystem;

    private void Awake()
    {
        calcSystem = CalculateSystem.Instance;
    }

    public void OnClickNumberButton(int num)
    {
        calcSystem.IsOperator = false;
        calcSystem.Calc = num.ToString();
    }
}
