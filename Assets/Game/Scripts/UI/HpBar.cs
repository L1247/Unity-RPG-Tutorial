#region

using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Game.Scripts.UI
{
    public class HpBar : MonoBehaviour
    {
    #region Private Variables

        private bool delayEffectExecuting;

        [SerializeField]
        [Required]
        private Image delta;

        [SerializeField]
        [Required]
        private Image front;

        [SerializeField]
        private bool useDelayEffect = true;

        [SerializeField]
        private float delayEffectDuration = 0.5f;

    #endregion

    #region Public Methods

        public void SetPercent(float percent)
        {
            front.fillAmount = percent;

            if (useDelayEffect == false)
            {
                delta.fillAmount = front.fillAmount;
                return;
            }

            if (delayEffectExecuting) return;
            delayEffectExecuting = true;
            Observable.Timer(TimeSpan.FromSeconds(delayEffectDuration))
                      .Subscribe(_ => DoDelayEffect())
                      .AddTo(gameObject);
        }

    #endregion

    #region Private Methods

        private void DoDelayEffect()
        {
            // delta.fillAmount      = front.fillAmount;
            delta.DOFillAmount(front.fillAmount , 0.3f)
                 .SetEase(Ease.InOutCubic)
                 .OnComplete(() => delayEffectExecuting = false);
        }

    #endregion
    }
}