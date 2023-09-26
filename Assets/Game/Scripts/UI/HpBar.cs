#region

using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Game.Scripts.UI
{
    public class HpBar : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        [Required]
        private Image delta;

        [SerializeField]
        [Required]
        private Image front;

    #endregion

    #region Public Methods

        public void SetPercent(float percent)
        {
            // 0 - 1
            front.fillAmount = percent;
            delta.fillAmount = percent;
        }

    #endregion
    }
}