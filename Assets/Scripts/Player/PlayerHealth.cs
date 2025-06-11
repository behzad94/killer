using System.IO;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 3;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverContainer;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    public bool isGodMode = false;

    AudioManager audioManager;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            isGodMode = !isGodMode;
            Debug.Log("God mode: " + (isGodMode ? "ON" : "OFF"));
        }
    }

    public void TakeDamage(int amount)
    {
        if (isGodMode)
        {
            Debug.Log("God Mode active, no damage taken");
            return;
        }

        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        audioManager.SetGameOverSnapshot();
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
