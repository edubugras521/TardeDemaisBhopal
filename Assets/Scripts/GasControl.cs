using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasControl : MonoBehaviour
{
    public float MaxHealth;
    public float GasMaskHealth;
    public float DamagePerTick;
    public float RegenerationSpeed;
    public static bool GasMaskEquipped = false;
    public Text HealthAmount;
    public Text GasMaskHealthAmount;
    public Image GasTimer;
    public Image GasMaskIcon;
    public GameObject gasMaskDisplay;
    public CanvasGroup GameOverCanvas;
    public CanvasGroup GameWonCanvas;
    public Image BloodiedScreen;
    public Transform GasChecker;
    public LayerMask GasLayer;

    public AudioSource SourceBreathing;
    public AudioSource SourceCough;

    public static bool gameOver = false;
    public static bool gameWon = false;

    float CurrentHealth;
    float CurrentGasMaskHealth;
    float GasDistance = 1.0f;
    float colorMultiplier;
    float alphaMultiplier;
    bool RegenerationActive = true;
    bool InGas = false;
    Color FullHealthColor;
    Color LowHealthColor;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        //HealthAmount.text = "Health: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
        CurrentGasMaskHealth = GasMaskHealth;
        //GasMaskHealthAmount.text = "Gas Mask: " + CurrentGasMaskHealth.ToString() + " / " + GasMaskHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            InGas = Physics.CheckSphere(GasChecker.position, GasDistance, GasLayer);

            if (GasMaskEquipped)
            {
                gasMaskDisplay.SetActive(true);
            }
            else
            {
                gasMaskDisplay.SetActive(false);
            }

            Regenerate();

            if (InGas)
            {
                RegenerationActive = false;
                GasDamage();
            }

            else if (!InGas)
            {
                RegenerationActive = true;
                SourceBreathing.mute = true;
                SourceBreathing.Stop();
                SourceCough.mute = true;
                SourceCough.Stop();
            }
            UpdateHealthIndicators();
        }
        else
        {
            SourceBreathing.mute = true;
            SourceCough.mute = true;
            SourceBreathing.Stop();
            SourceCough.Stop();
        }

        GameOverCheck();
    }
    //void OnTriggerExit(Collider other)
    //{
   //     if (other.gameObject.CompareTag("Gas"))
    //    {
    //        RegenerationActive = true;
    //        TimeSinceLastTick = 0;
    //        InGas = false;
    //    }
   // }
    //void OnTriggerEnter(Collider other)
   // {
    //    if (other.gameObject.CompareTag("Gas"))
   //     {
   //         RegenerationActive = false;
    //        InGas = true;
   //     }
   // }

    void GasDamage()
    {
        if (!GasMaskEquipped)
        {
            CurrentHealth -= DamagePerTick * Time.deltaTime;
            //MaxHealth -= (DamagePerTick / 2) * Time.deltaTime;

            if (!SourceCough.isPlaying)
            {
                SourceCough.Play();
            }

            SourceCough.mute = false;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            //HealthAmount.text = "Health: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
        }

        if (GasMaskEquipped)
        {
            if (CurrentGasMaskHealth > 0)
            {
                CurrentGasMaskHealth -= DamagePerTick * Time.deltaTime;
                SourceBreathing.mute = false;
                if (!SourceBreathing.isPlaying)
                {
                    SourceBreathing.Play();
                }
                //GasMaskHealthAmount.text = "Gas Mask: " + CurrentGasMaskHealth.ToString() + " / " + GasMaskHealth.ToString();
            }

            if (CurrentGasMaskHealth < 0)
            {
                CurrentGasMaskHealth = 0;
                SourceBreathing.mute = true;
                SourceBreathing.Stop();
                //GasMaskHealthAmount.text = "Gas Mask: " + CurrentGasMaskHealth.ToString() + " / " + GasMaskHealth.ToString();
            }

            if (CurrentGasMaskHealth == 0)
            {
                CurrentHealth -= DamagePerTick * Time.deltaTime;
                SourceBreathing.mute = true;
                SourceBreathing.Stop();
                SourceCough.mute = false;
                if (!SourceCough.isPlaying)
                {
                    SourceCough.Play();
                }

                //MaxHealth -= (DamagePerTick / 2) * Time.deltaTime;
                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                    SourceCough.mute = true;
                    SourceCough.Stop();
                }
                //HealthAmount.text = "Health: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
            }
        }
    }

    void Regenerate()
    {
        if (RegenerationActive && CurrentGasMaskHealth < GasMaskHealth)
        {
            CurrentGasMaskHealth += RegenerationSpeed * 2 * Time.deltaTime;
            //GasMaskHealthAmount.text = "Gas Mask: " + CurrentGasMaskHealth.ToString() + " / " + GasMaskHealth.ToString();
        }

        if (CurrentGasMaskHealth > GasMaskHealth)
        {
            CurrentGasMaskHealth = GasMaskHealth;
            //GasMaskHealthAmount.text = "Gas Mask: " + CurrentGasMaskHealth.ToString() + " / " + GasMaskHealth.ToString();
        }

        if (RegenerationActive && CurrentHealth < MaxHealth)
        {
            CurrentHealth += RegenerationSpeed * Time.deltaTime;
            //HealthAmount.text = "Health: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
        }

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            //HealthAmount.text = "Health: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
        }
    }

    void UpdateHealthIndicators()
    {
        GasTimer.fillAmount = (CurrentGasMaskHealth / GasMaskHealth);
        colorMultiplier = 1 - ((CurrentGasMaskHealth * 2) / GasMaskHealth);
        alphaMultiplier = 1 - (CurrentHealth / MaxHealth);

        if((CurrentGasMaskHealth / GasMaskHealth) < 0.5f)
        {
            GasTimer.color = new Color(colorMultiplier, 0, 0, 1);
            GasMaskIcon.color = new Color(colorMultiplier, 0, 0, 1);
        }

        BloodiedScreen.color = new Color(1, 1, 1, (alphaMultiplier / 2));
    }

    void GameOverCheck()
    {
        if(CurrentHealth <= 0)
        {
            gameOver = true;
        }

        if (!gameOver && gameWon) gameOver = true;

        if(gameOver && !gameWon)
        {
            GameOverCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            if (GameOverCanvas.alpha < 1)
            {
                GameOverCanvas.alpha += (0.5f * Time.deltaTime);
            }
        }

        if (gameOver && gameWon)
        {
            GameWonCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            if (GameWonCanvas.alpha < 1)
            {
                GameWonCanvas.alpha += (0.5f * Time.deltaTime);
            }
        }
    }

    public void WinGame()
    {
        gameWon = true;
    }
}