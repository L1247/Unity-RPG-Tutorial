#region

using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Datas
{
    [CreateAssetMenu(fileName = "PlayerCharacterDataContainer" , menuName = "PlayerCharacterDataContainer" , order = 0)]
    public class PlayerCharacterDataContainer : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private PlayerCharacter.Data playerCharacterData;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(playerCharacterData);
        }

    #endregion
    }
}