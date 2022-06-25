using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItem : ScriptableObject
    {
        public abstract void Use(int count);
        
        [field: SerializeField]
        public Texture2D Texture
        {
            get;
            private set;
        }

        [field: SerializeField] 
        public int Type
        {
            get;
            private set;
        }
        
        [field: SerializeField] 
        public int MaxStack
        {
            get;
            private set;
        }
    }
}
