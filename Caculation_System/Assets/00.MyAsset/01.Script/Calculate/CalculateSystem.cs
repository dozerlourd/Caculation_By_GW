using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSystem : SceneObject<CalculateSystem>
{
    private List<string> numberList = new List<string>();

    public List<string> NumberList
    {
        get => numberList;
    }

    string calc;

    public string Calc
    {
        get => calc;
        set
        {
            calc = value;
            numberList.Add(calc);
            RefreshCalculateUI();
        }
    }

    // Score Property(속성) 정의
    // 위 값이 바뀔 때마다 ObserverSystem 특정한 키워드로 이벤트를 보내
    float result = 0;
    public float Result
    {
        get => result;
        set
        {
            result = value;
            RefreshResultUI();
        }

    }

    public void RefreshCalculateUI()
    {
        JHS.ObserverSystem.Instance.PostNofication("Calc갱신");
    }

    public void RefreshResultUI()
    {
        JHS.ObserverSystem.Instance.PostNofication("Result갱신");
    }
}
