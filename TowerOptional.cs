using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Entities.Tower
{
    public class TowerOptional : MonoBehaviour
    {
        [SerializeField] private CircleController circle;
        [SerializeField] private TextMeshProUGUI damageText;

        private IRepository<int> _repository;
        private Tower _tower;

        [Inject]
        private void Construct(IRepository<int> repository)
        {
            _repository = repository;
        }

        public void SetInfo()
        {
            _tower = circle.Target.GetComponent<Tower>();
            UpdateText();
        }

        private void UpdateText()
        {
            damageText.text =
                $"{_tower.Damage}+<color=#00E714>{_tower.AdditionalDamage:0.0}</color>";
        }

        private void OnEnable()
        {
            _repository.OnChanged += UpdateText;
        }

        private void OnDisable()
        {
            _repository.OnChanged -= UpdateText;
        }
    }
}