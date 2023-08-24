#region

using System;
using System.Collections.Generic;
using Game.Scripts.RPG;
using rStarUtility.Generic.Infrastructure;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
    #region Public Variables

        public float MoveSpeed => GetStatFinalValue("MoveSpeed");

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

        public void SetMoveSpeed(float moveSpeed)
        {
            var (contains , stat) = stats.FindContent(_ => _.Name == "MoveSpeed");
            Debug.Log($"MoveSpeed: {contains} ");
            if (contains) stat.SetAmount(moveSpeed);
            else stats.Add(new Stat("MoveSpeed" , moveSpeed));
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

        private float GetStatFinalValue(string statName)
        {
            var finalValue = 0f;
            var (contains , stat) = FindStat(statName);
            if (contains) finalValue = stat.Amount;
            return finalValue;
        }

        [Inject]
        private void Init()
        {
            foreach (var statData in data.statDatas)
            {
                var stat = new Stat(statData.name , statData.amount);
                stats.Add(stat);
            }
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Data
        {
        #region Public Variables

            public List<Stat.Data> statDatas = new List<Stat.Data>();

        #endregion
        }

    #endregion
    }
}