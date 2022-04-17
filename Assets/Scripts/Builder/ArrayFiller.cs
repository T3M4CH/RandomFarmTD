using UnityEngine;
using System.IO;
public class ArrayFiller : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private string[] array = new string[36];
    private string json => JsonUtility.ToJson(this,true);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {

            FillAray();
            File.WriteAllText("D:/Games/RandomFarmTD/RandomFarmTD/Assets/OtherStuff/Array.txt", json);
        }
    }


    private void FillAray()
    {
        for (int j = 0; j < 36; j++)
        {
            array[j] = "{";
            for (int i = 0; i < 36; ++i)
            {
                transform.position = new Vector3Int(8 + i, 7, 48 - j);
                if (Physics.Raycast(new Ray(transform.position, -transform.up), out RaycastHit hit, 2))
                {
                    if (hit.transform.gameObject.GetComponent<BoxCollider>())
                    {
                        array[j] += "1";
                    }
                    else
                    {
                        array[j] += "0";
                    }
                }
                else
                {
                    array[j] += "0";
                }
                if(i < 35)
                {
                    array[j] += ",";
                }
            }
            array[j] += "}";
        }
        
        Debug.Log("DOne");
    }
}