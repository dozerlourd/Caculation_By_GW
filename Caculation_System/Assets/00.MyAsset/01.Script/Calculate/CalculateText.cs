using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateText : JHS.TextController
{
    [SerializeField] bool isResult = false;
    protected override string WriteText => isResult ? CalculateSystem.Instance.Result.ToString() : string.Join("", CalculateSystem.Instance.NumberList);
}
