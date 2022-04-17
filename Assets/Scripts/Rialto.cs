using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Rialto : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO waveChannel;
    [SerializeField] private RialtoChannelSO inventoryChannel;
    [SerializeField] private TextMeshProUGUI incomeText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI watermelonText;
    [SerializeField] private TextMeshProUGUI pumpkinText;
    [SerializeField] private TextMeshProUGUI cabbageText;
    private int getDelay => Random.Range(5, 10);
    private int coinDelay;
    private float currentTime;
    private int waveCount = -1;
    private Dictionary<int, int> goods = new Dictionary<int, int>()
    {
        {0,0},
        {1,0},
        {2,0},
        {3,5}
    };
    private int money = 0;
    private void Start()
    {
        SetPrices();
        coinDelay = getDelay;
        waveChannel.VoidEventAddListener(SetPrices);
        inventoryChannel.AddListener(Sell);
    }
    private void Sell(int count, int type)
    {
        if (goods.TryGetValue(type, out int cost))
        {
            money += count * cost;
        }
        MoneyUpdate();
    }
    private void MoneyUpdate()
    {
        moneyText.text = money.ToString();
    }
    private void SetPrices()
    {
        waveCount += 1;
        goods[1] = Random.Range(50, 110) + waveCount;
        watermelonText.text = goods[1].ToString();
        goods[2] = Random.Range(50, 110) + waveCount;
        pumpkinText.text = goods[2].ToString();
        goods[3] = Random.Range(50, 110) + waveCount;
        cabbageText.text = goods[3].ToString();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > coinDelay)
        {
            TimerFinished();
        }
        incomeText.text = (coinDelay - (int)currentTime).ToString();
    }
    private void TimerFinished()
    {
        money += 150 + 10 * waveCount;
        MoneyUpdate();
        coinDelay = getDelay;
        currentTime = 0;
    }
}
