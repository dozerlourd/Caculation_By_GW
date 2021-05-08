using UnityEngine;
using UnityEngine.UI;
using System;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 상속 받은 대상 <para></para>
    /// 
    /// </summary>
    #endregion
    public abstract class TextController : MonoBehaviour
    {
        #region 변수

        Text m_textUI;

        [SerializeField] string m_prefix;
        [SerializeField] string m_suffix;
        [SerializeField] string m_keyword;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_textUI = GetComponent<Text>();
            if (!String.IsNullOrWhiteSpace(m_keyword)) ObserverSystem.Instance.AddListener(m_keyword, gameObject, RefreshUIElement, false);
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 구현부

        void RefreshUIElement()
        {
            m_textUI.text = $"{m_prefix}{WriteText}{m_suffix}";
            AnimationText();
        }

        protected abstract string WriteText { get; }

        protected virtual void AnimationText() { }

        #endregion
    }
}
