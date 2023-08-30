#region

using System;
using System.Collections.Generic;
using Game.Scripts.Helpers;
using Game.Scripts.Names;
using Game.Scripts.RPG;
using rStarUtility.Generic.Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
    #region Public Variables

        public IEnumerable<Stat> Stats => stats.Contents;

        public Transform Trans
        {
            get
            {
                if (trans == null) trans = transform;
                return trans;
            }
        }

    #endregion

    #region Private Variables

        private readonly GenericRepository<Stat> stats = new GenericRepository<Stat>();

        [Inject]
        private Data data;

        private Transform trans;

    #endregion

    #region Public Methods

        public Vector2 GetPos()
        {
            return Trans.position;
        }

        public float GetStatFinalValue(string statName)
        {
            var finalValue = 0f;
            var (contains , stat) = FindStat(statName);
            if (contains) finalValue = stat.Amount;
            return finalValue;
        }

        public void SetAtk(float atk)
        {
            var (contains , stat) = stats.FindContent(_ => _.Name == StatNames.Atk);
            if (contains) stat.SetAmount(atk);
            else stats.Add(new Stat(StatNames.Atk , atk));
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            var (contains , stat) = stats.FindContent(_ => _.Name == StatNames.MoveSpeed);
            if (contains) stat.SetAmount(moveSpeed);
            else stats.Add(new Stat(StatNames.MoveSpeed , moveSpeed));
        }

        public void SetPos(Vector2 newPos)
        {
            Trans.position = newPos;
        }

    #endregion

    #region Private Methods

        private (bool contains , Stat stat) FindStat(string statName)
        {
            (bool contains , Stat stat) findStat = stats.FindContent(_ => _.Name == statName);
            return findStat;
        }

        [Inject]
        private void Init()
        {
            InitStats();
        }

        private void InitStats()
        {
            foreach (var statData in data.statDatas)
            {
                var stat = new Stat(statData.Name , statData.Amount);
                stats.Add(stat);
            }
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Data
        {
        #region Public Variables

            [ValidateInput("StatDataValidation" , ContinuousValidationCheck = true)]
            public List<Stat.Data> statDatas = new List<Stat.Data>();

        #endregion

        #region Private Methods

            private bool StatDataValidation(List<Stat.Data> datas , ref string errorMessage)
            {
                return ValidateHelper.StatDataValidation(datas , ref errorMessage);
            }

        #endregion
        }

    #endregion
    }
}