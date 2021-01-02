
using UnityEngine;

public class PlayerHealht : MonoBehaviour
{

    public int currentHealht = 100;
    public int maxWealth = 0;
    public int currentWealth = 0;
    public int minWealth = 0;
    public TMPro.TextMeshProUGUI healht_txt;
    public TMPro.TextMeshProUGUI money_txt;
    public void LoseHealht()
    {
        currentHealht -= 25;
        healht_txt.text = "%" + currentHealht.ToString();
        if (currentHealht <= 0)
        {
            currentHealht = 0;
            healht_txt.text = "%" + currentHealht.ToString();
        }
    }

   public void HealhtUpgrade()
    {
        healht_txt.text = "%" + currentHealht.ToString();

    }
    public void GiveWealth( int wealthAmount)
    {
        
        currentWealth += wealthAmount;
        
        
        money_txt.text = currentWealth.ToString();
    }

    public void LoseMoney(int wealthAmount)
    {
        if (currentWealth <= 0)
        {
            currentWealth += wealthAmount;
            money_txt.text = currentWealth.ToString();
        }
        currentWealth -= wealthAmount;
        
       
        money_txt.text = currentWealth.ToString();
        
    }

    private void Awake()
    {
        currentWealth = PlayerPrefs.GetInt("Money");
    }

    void Update()
    {
        money_txt.text = currentWealth.ToString();
        if (currentHealht >= 100)
        {
            currentHealht = 100;
            healht_txt.text = "%" + currentHealht.ToString();
        }
        if(currentHealht <= 0)
        {
            currentHealht = 0;
            healht_txt.text = "%" + currentHealht.ToString();
        }
        if(currentWealth <= 0)
        {
            currentWealth = 0;
            money_txt.text = currentWealth.ToString();
        }
        
        
        //just add the following to save
        

    }

}
