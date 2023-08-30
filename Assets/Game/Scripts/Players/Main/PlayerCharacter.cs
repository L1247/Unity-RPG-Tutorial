#region

using System;
using System.Collections.Generic;
using Game.Scripts.Helpers;
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

        public void SetPos(Vector2 newPos)
        {
            Trans.position = newPos;
        }

        public void SetStatAmount(string statName , float statAmount)
        {
            var (contains , stat) = stats.FindContent(_ => _.Name == statName);
            if (contains) stat.SetAmount(statAmount);
            else stats.Add(new Stat(new Stat.Data(statName , statAmount)));
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
            data.statDatas.ForEach(data => stats.Add(new Stat(data)));
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Data
        {
        #region Public Variables

            [ListDrawerSettings(CustomAddFunction = "AddNewStatData")]
            [ValidateInput("StatDataValidation" , ContinuousValidationCheck = true)]
            public List<Stat.Data> statDatas = new List<Stat.Data>();

        #endregion

        #region Private Methods

            private void AddNewStatData()
            {
                var data = new Stat.Data(string.Empty) { isPlayer = true };
                statDatas.Add(data);
            }

            private bool StatDataValidation(List<Stat.Data> datas , ref string errorMessage)
            {
                return ValidateHelper.StatDataValidation(datas , ref errorMessage);
            }

        #endregion
        }

    #endregion
    }
}