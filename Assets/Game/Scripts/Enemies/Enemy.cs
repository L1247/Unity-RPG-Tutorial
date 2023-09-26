#region

using System;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

#endregion

namespace Game.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
    #region Private Variables

        private bool flashEffectExecuting;

        [Required]
        [SerializeField]
        private HpBar hpBar;

        [SerializeField]
        [Min(1)]
        private int maxHp;

        [SerializeField]
        [Min(1)]
        private int hp;

        [SerializeField]
        [Required]
        private Material normalMaterial;

        [SerializeField]
        [Required]
        private Material flashMaterial;

        [SerializeField]
        [Required]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        [Min(0.1f)]
        private float flashDuration;

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
            UpdateHpBar();
            DoFlashEffect();
        }

    #endregion

    #region Private Methods

        private void DoFlashEffect()
        {
            spriteRenderer.material = flashMaterial;
            if (flashEffectExecuting) return;
            flashEffectExecuting = true;
            Observable.Timer(TimeSpan.FromSeconds(flashDuration))
                      .Subscribe(_ => SetNormalMaterial())
                      .AddTo(gameObject);
        }

        private void SetNormalMaterial()
        {
            spriteRenderer.material = normalMaterial;
            flashEffectExecuting    = false;
        }

        private void UpdateHpBar()
        {
            var percent = hp / (float)maxHp;
            hpBar.SetPercent(percent);
        }

    #endregion
    }
}