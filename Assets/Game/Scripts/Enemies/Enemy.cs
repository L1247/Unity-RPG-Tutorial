#region

using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Game.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
    #region Private Variables

        [Required]
        [SerializeField]
        private HpBar hpBar;

        [SerializeField]
        [Min(1)]
        private int maxHp;

        [SerializeField]
        [Min(1)]
        private int hp;

    #endregion

    #region Unity events

        private void Start()
        {
            hp = maxHp;
        }

    #endregion

    #region Public Methods

        [Button(ButtonSizes.Medium)]
        [GUIColor(1 , 0 , 0)]
        public void DealDamage(int damage)
        {
            hp -= damage;
            var percent = hp / (float)maxHp;
            hpBar.SetPercent(percent);
        }

    #endregion
    }
}