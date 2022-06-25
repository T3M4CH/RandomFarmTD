using Zenject;
using UnityEngine;
using Builder.Interfaces;
using Inventory.OptionalItems.Interfaces;

namespace Inventory.OptionalItems
{
    public class TowerBuilder : IBuilder
    {
        public TowerBuilder(IBuilderSettings builderSettings)
        {
            _builderSettings = builderSettings;
            _gridBuilding = builderSettings.GridBuilding;
            _crate = builderSettings.Building;
            _inventory = builderSettings.Inventory;
            _towerCreator = builderSettings.TowerCreator;

            _builderSettings.VoidChannel.Subscribe(Use);
        }
        
        private IBuilderSettings _builderSettings;
        private GridBuilding _gridBuilding;
        private Building _crate;
        private Inventory _inventory;
        private TowerCreator _towerCreator;
        
        public void Use()
        {
            _towerCreator.CreateTower(_crate);
            Debug.Log("хуй");
        }
    }
}