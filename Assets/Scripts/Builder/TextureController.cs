using UnityEngine;
public class TextureController : MonoBehaviour
{
    private int[,] Grid = new int[6, 6];
    private GridBuilding gridBuilding;
    private Texture2D texture;
    [SerializeField] TextureWrapMode wrapMode;
    [SerializeField] FilterMode filterMode;

    private void Start()
    {
        gridBuilding = FindObjectOfType<GridBuilding>();
        if (texture == null)
        {
            texture = new Texture2D(61, 61);
            GetComponent<Renderer>().material.mainTexture = texture;
            GetComponent<Renderer>().material.color -= new Color(0,0,0,0.5f);
        }

        texture.filterMode = filterMode;
        texture.wrapMode = wrapMode;
        texture.SetPixel(0, 0, new Color32(205, 205, 205, 205)); // Default Color
        for (int i = 0; i < texture.width; i++)
        {
            if (i % 10 == 0)
            {
                for (int j = 1; j < texture.height - 1; j++)
                {
                    if (j % 10 <= 1)
                    {

                        texture.SetPixel(i - 1, j, Color.clear);
                        texture.SetPixel(i, j - 1, Color.clear);

                        continue;
                    }
                    texture.SetPixel(i, j, Color.black);
                }
            }
            else
            {
                for (int j = 0; j < texture.height + 1; j += 10)
                {
                    if (i % 10 == 1)
                    {

                        texture.SetPixel(i, j + 1, Color.black);
                        texture.SetPixel(i - 2, j + 1, Color.black);
                        texture.SetPixel(i - 2, j - 1, Color.black);
                        texture.SetPixel(i, j - 1, Color.black);

                        continue;
                    }
                    texture.SetPixel(i, j, Color.black);
                }
            }
        }
        texture.Apply();
    }
    public void SetGrid(Vector2Int center)
    {
        transform.position = new Vector3(center.x + .5f, 6.1f, center.y + .5f);
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            { 
                Grid[i, j] = gridBuilding.GetCoord(Mathf.Clamp(46 - center.y + j, 0, 37), Mathf.Clamp(center.x - 9 + i, 0, 37));
                if (Grid[i, j] > 0)
                {
                    if ((i > 1 && i <= 3) && (j > 1 && j <= 3))
                        ChangeQuadTexture(i * 10 + 1, j * 10 + 1, new Color(0,255,0,100));
                    else
                        ChangeQuadTexture(i * 10 + 1, j * 10 + 1, new Color(255,255,255,100));
                }
                else
                { 
                    ChangeQuadTexture(i * 10 + 1, j * 10 + 1, new Color(255,0,0,100));
                }
            }
        }
        texture.Apply();
    }
    private void ChangeQuadTexture(int x, int y, Color color)
    {
        for (int i = x; i < x + 9; i++)
        {
            for (int j = y; j < y + 9; j++)
            {
                if ((i == x || i == x + 8) && (j == y || j == y + 8))
                    continue;
                texture.SetPixel(i, j, color);
            }
        }
    }

}
