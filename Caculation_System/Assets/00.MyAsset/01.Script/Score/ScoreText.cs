using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : JHS.TextController
{
    protected override string WriteText => ScoreSystem.Instance.Score.ToString("N0");
}
