using UnityEngine;

public class LevelUpZone : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private MinionSpawner _spawner;
    [SerializeField] private LevelUpUi _ui;
    [SerializeField] private float _maxMinionsUpgradeCost;
    [SerializeField] private float _minionSpeedUpgradeCost;
    [SerializeField] private float _minionMiningSpeedUpgradeCost;

    public void IncreaseMaxMinion()
    {
        if (_base.Gold >= _maxMinionsUpgradeCost)
        {
            _spawner.IncreaseMaxMinion();
            _base.SpendGold(_maxMinionsUpgradeCost);
        }
    }

    public void IncreaseMinionSpeed()
    {
        if( _base.Gold >= _minionSpeedUpgradeCost)
        {
            _spawner.IncreaseMinionSpeed();
            _base.SpendGold(_minionSpeedUpgradeCost);
        }
    }

    public void IncreaseMinionMiningSpeed()
    {
        if(_base.Gold >= _minionMiningSpeedUpgradeCost)
        {
            _spawner.IncreaseMinionMiningSpeed();
            _base.SpendGold(_minionMiningSpeedUpgradeCost);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _ui.ShowUiPanel();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _ui.HideUiPanel();
    }
}
