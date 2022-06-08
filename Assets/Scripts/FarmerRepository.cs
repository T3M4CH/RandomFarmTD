using UnityEngine;
using System.Collections.Generic;

public class FarmerRepository : IFarmerRepository
{
    private readonly Dictionary<UnitInfo, int> _levelData = new Dictionary<UnitInfo, int>();

    public void GetLevel(UnitInfo info)
    {
        if (_levelData.ContainsKey(info))
        {
            Debug.Log(info + " " + _levelData[info]);
        }
        else
        {
            Debug.Log("Такой хуйни нет");
        }
    }

    public void IncreaseLevel(UnitInfo unitInfo)
    {
        if (_levelData.ContainsKey(unitInfo))
        {
            _levelData[unitInfo] += 1;
        }
        else
        {
            _levelData.Add(unitInfo, 1);
        }

        Debug.Log(unitInfo + " " + _levelData[unitInfo]);
    }
}