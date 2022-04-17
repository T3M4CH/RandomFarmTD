using UnityEngine;

public interface Item
{
    /// <summary>
    /// 0:Watermelon
    /// 1:Pumpkin
    /// 2:Cabbage
    /// </summary>
    /// <returns></returns>
    public int Type();
    public Texture2D GetTexture();
    public bool Sellable();
}
