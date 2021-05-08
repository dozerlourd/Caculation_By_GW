using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace JHS
{
    public delegate void Reaction();

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 씬에서 일어나는 이벤트 제어 <para></para>
    /// 참고 : 옵저버 패턴 - https://victorydntmd.tistory.com/296?category=719467 <para></para>
    ///        UniRx - https://tech.lonpeach.com/2019/11/17/UniRx-Getting-Started-List/ <para></para>
    /// ----- 공개 메소드 ----- <para></para>
    /// AddListener(string eventType, GameObject listener, Reaction reaction) : 리스너 추가, 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다. <para></para>
    /// PostNofication(string eventType) : 지정된 이벤트가 발생했다고 리스너들에게 알림 <para></para>
    /// ClearListeners() : 리스너 목록 초기화 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Awake()문 오버라이드시 base.Awake()를 필히 호출해야한다. <para></para>
    /// 2. 구독자가 비활성화 상태여도 이벤트는 전송된다.
    /// 3. 구독자가 파괴될 시 구독을 해제해두지 않으면 오작동한다. 
    ///
    /// </summary>
    #endregion
    public class ObserverSystem : SceneObject<ObserverSystem>
    {
        #region 변수

        Dictionary<string, Subject<Unit>> m_listeners = new Dictionary<string, Subject<Unit>>();

        #endregion

        #region 인터페이스부

        /// <summary>
        /// 리스너 추가
        /// 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다.
        /// </summary>
        /// <param LabelName="_eventType">리액션을 일으킬 이벤트</param>
        /// <param LabelName="_reaction">이벤트가 일어났을 때 실행할 리액션</param>
        public IDisposable AddListener(string eventType, GameObject listener, Reaction reaction, bool isOnlyActiveGO = true)
        {
            if (!m_listeners.ContainsKey(eventType))
            {
                Subject<Unit> tempSubject = new Subject<Unit>();
                m_listeners.Add(eventType, tempSubject);
            }

            return m_listeners[eventType]
                .Where(_ => !isOnlyActiveGO || listener.activeInHierarchy)
                .Subscribe(_ => { reaction(); })
                .AddTo(listener);
        }

        public IDisposable AddListener(string eventType, Reaction reaction)
        {
            if (!m_listeners.ContainsKey(eventType))
            {
                Subject<Unit> tempSubject = new Subject<Unit>();
                m_listeners.Add(eventType, tempSubject);
            }

            return m_listeners[eventType]
                .Subscribe(_ => { reaction(); });
        }

        /// <summary>
        /// 리스너 추가
        /// 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다.
        /// </summary>
        /// <param LabelName="_eventType">리액션을 일으킬 이벤트</param>
        /// <param LabelName="_reaction">이벤트가 일어났을 때 실행할 리액션</param>
        public IDisposable WaitNofication(string eventType, GameObject listener, bool isOnlyActiveGO = true)
        {
            if (!m_listeners.ContainsKey(eventType))
            {
                Subject<Unit> tempSubject = new Subject<Unit>();

                m_listeners.Add(eventType, tempSubject);
            }

            return m_listeners[eventType]
                .Where(_ => !isOnlyActiveGO || listener.activeInHierarchy)
                .FirstOrDefault()
                .ToYieldInstruction()
                .AddTo(listener);
        }

        /// <summary>
        /// 지정된 이벤트가 발생했다고 리스너들에게 알림
        /// 
        /// </summary>
        /// <param LabelName="_eventType">전달할 이벤트</param>
        public void PostNofication(string eventType)
        {
            if (!m_listeners.ContainsKey(eventType)) return;

            //Debug.Log($"{eventType} 이벤트 발생!!");                        ///

            m_listeners[eventType].OnNext(Unit.Default);
        }

        /// <summary>
        /// 리스너 목록 초기화
        /// </summary>
        public void ClearListeners()
        {
            m_listeners.Clear();
        }

        #endregion
    }
}
