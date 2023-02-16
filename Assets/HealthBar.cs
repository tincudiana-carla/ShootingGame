using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalhealthImage;
    [SerializeField] private Image currenthealthImage;
    private void Update()
    {
        currenthealthImage.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Start()
    {
        totalhealthImage.fillAmount = playerHealth.currentHealth / 10;
    }
}
