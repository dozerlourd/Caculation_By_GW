using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSystem : SceneObject<CalculateSystem>
{
    private List<string> numberList = new List<string>();
    private List<object> resultList = new List<object>();

    public List<string> NumberList
    {
        get => numberList;
    }
    public List<object> ResultList
    {
        get => resultList;
    }

    string calc;

    public string Calc
    {
        get => calc;
        set
        {
            if (isOperator) return;
            calc = value;
            numberList.Add(calc);
            RefreshCalculateUI();
        }
    }

    bool isOperator = false;
    public bool IsOperator
    {
        get => isOperator;
        set => isOperator = value;
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

    private void Start()
    {
        isOperator = true;
    }

    public void RefreshCalculateUI()
    {
        if(numberList.Count == 0) isOperator = true;
        JHS.ObserverSystem.Instance.PostNofication("Calc갱신");
    }

    public void RefreshResultUI()
    {
        JHS.ObserverSystem.Instance.PostNofication("Result갱신");
    }

    public void DeriveResult()
    {
        //for문으로 리스트 0번부터 끝까지 검색한다.
        //operator가 나오면 operator 전까지 하나의 float형으로 묶은 후 따로 저장한다.
        //operator도 따로 분류해놓는다.
        SortOperatorAndNumber();
        CalculateResult();
    }

    void SortOperatorAndNumber()
    {
        int temp = 0;
        string op;

        for (int i = 0; i < numberList.Count; i++)
        {
            if (numberList[i] == "+") {
                op = "+";
            } else if (numberList[i] == "-") {
                op = "-";
            } else if (numberList[i] == "*") {
                op = "*";
            } else if (numberList[i] == "/") {
                op = "/";
            } else if (numberList[i] == "(") {
                op = "(";
            } else if (numberList[i] == ")") {
                op = ")";
            } else if (numberList[i] == ".") {
                op = ".";
            } else if (numberList[i] == "+/-") {
                op = "+/-";
            } else if(numberList[i] == "=") {
                op = "=";
            } else { continue; }

            float num = 0;
            for (int t = i - 1; t >= temp; t--)
            {
                int exponent = (i - 1 - t);
                Debug.Log("exp : " + exponent);
                //Debug.Log(float.Parse(numberList[t]) * (10 ^ (i - t)));
                num += float.Parse(numberList[t]) * Mathf.Pow(10, exponent); //temp = 0; i = 3; t = 2->0; //temp = 4; i = 6; t = 5->4;
                Debug.Log("numberList[t] : " + float.Parse(numberList[t]));
                Debug.Log("num : " + num);
            }
            resultList.Add(num);
            resultList.Add(op);
            temp = i + 1;
        }
    }

    void CalculateResult()
    {
        //최종적으로 나온  ResultList를 이용하여 결과값을 계산한다
        while(resultList.Count > 1)
        {
            //if (resultList."+")
            //{

            //}
            //else if (resultList[i] == "-")
            //{

            //}
            //else if (resultList[i] == "*")
            //{

            //}
            //else if (resultList[i] == "/")
            //{

            //}
            //else if (resultList[i] == "(")
            //{

            //}
            //else if (resultList[i] == ")")
            //{

            //}
            //else if (resultList[i] == ".")
            //{

            //}
            //else if (resultList[i] == "+/-")
            //{

            //}
        }
        Result = (float)resultList[0];
    }
}
