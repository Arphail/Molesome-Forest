using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUi : MonoBehaviour
{
    [SerializeField] private GameObject _levelupUiPanel;

    public void ShowUiPanel() => _levelupUiPanel.SetActive(true);

    public void HideUiPanel() => _levelupUiPanel.SetActive(false);
}
