using Channels;
using Repositories.Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Trader
{
    public class MeepoBonus : MonoBehaviour
    {
        [SerializeField] private VoidChannel meepoBonus;
        [SerializeField] private Image panel;
        [SerializeField] private Button firstButton;
        [SerializeField] private Button secondButton;
        [SerializeField] private Button thirdButton;

        private IRepository<EUpgradeType> _upgradeRepository;
        
        [Inject]
        public void Construct(IRepository<EUpgradeType> upgradeRepository)
        {
            _upgradeRepository = upgradeRepository;
        }
        
        private void Start()
        {
            firstButton.onClick.AddListener(IncreaseDamage);
            secondButton.onClick.AddListener(IncreaseIncome);
            thirdButton.onClick.AddListener(GetTower);
            meepoBonus.Subscribe(OpenPanel);
        }

        private void IncreaseDamage()
        {
            Debug.Log("Increase Damage");
            _upgradeRepository.Use(EUpgradeType.Damage);
            
            ClosePanel();
        }

        private void IncreaseIncome()
        {
            Debug.Log("Increase Income");
            _upgradeRepository.Use(EUpgradeType.Income);
            
            ClosePanel();
        }

        private void GetTower()
        {
            Debug.Log("Get Tower");
            
            ClosePanel();
        }

        private void OpenPanel()
        {
            panel.gameObject.SetActive(true);
        }

        private void ClosePanel()
        {
            panel.gameObject.SetActive(false);
        }
    }
}