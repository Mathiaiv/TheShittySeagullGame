using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script for all things to do with poop
/// </summary>
public class Poop : MonoBehaviour
{
    [SerializeField] private GameObject poop;
    [SerializeField] private Slider poopBar;
    [SerializeField] private float maxPoop = 10;
    [SerializeField] private float poopRegenRate;
    private float _poopAmount;

    /// <summary>
    /// Increases the poop gradually over time based on poopRegenRate
    /// </summary>
    private void FixedUpdate()
    {
        if (_poopAmount < maxPoop) 
        {
            _poopAmount += poopRegenRate * Time.fixedDeltaTime;
        }
        else _poopAmount = maxPoop;
        poopBar.value = _poopAmount / maxPoop;
    }

    /// <summary>
    /// The seagull poops if there is poop inside its body
    /// </summary>
    private void OnFire()
    {
        if (_poopAmount < 1) return;
        _poopAmount--;
        Instantiate(poop, transform.position, default);
    }
}
