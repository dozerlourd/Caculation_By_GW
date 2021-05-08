using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : SceneObject<ScoreSystem>
{
    // Score Property(속성) 정의
    // 위 값이 바뀔 때마다 ObserverSystem 특정한 키워드로 이벤트를 보내
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            RefreshScoreUI();
        }

    }

    void RefreshScoreUI()
    {
        JHS.ObserverSystem.Instance.PostNofication("Score갱신");
    }
}
