using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateText : JHS.TextController
{
    protected override string WriteText => string.Join("",CalculateSystem.Instance.NumberList);
}
