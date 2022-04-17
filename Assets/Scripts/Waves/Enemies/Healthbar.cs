using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] 
    private GameObject prefabHealth;
    private Enemy enemy;
    private GameObject healthBar;
    private Image healthImage;
    private Canvas canvas;
    private float maxHp;
    private float currentHp;
    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        canvas = GameObject.Find("WorldCanvas").GetComponent<Canvas>();
        healthBar = Instantiate(prefabHealth, canvas.transform);
        healthImage = healthBar.transform.GetChild(1).GetComponent<Image>();
        enemy.AddListener(GetDamage);
        healthImage.fillAmount = 1f;
        maxHp = enemy.Health;
        currentHp = maxHp;
    }

    private void LateUpdate()
    {
        healthBar.transform.position = enemy.gameObject.transform.position + Vector3.up * 2;
    }

    private void GetDamage()
    {
        healthImage.fillAmount = enemy.Health/maxHp;
    }
    private void OnDestroy()
    {
        enemy.RemoveListener(GetDamage);
        Destroy(healthBar);
    }
}
