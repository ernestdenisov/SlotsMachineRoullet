using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : SingletonBase<Wallet>
{
    [Header("Set In Inspector")]
    /// <summary>
    /// Общее количество денег
    /// </summary>
    [SerializeField] private int walletMoney;
    /// <summary>
    /// Ставка
    /// </summary>
    [SerializeField] private int bet;
    public int Bet => bet;
    /// <summary>
    /// Текст общего колечества денег
    /// </summary>
    [SerializeField] private Text walletMoneyTxt;
    /// <summary>
    /// Текст ставки
    /// </summary>
    [SerializeField] private Text betTxt;
    [Header("Set In Dinamycally")]
    /// <summary>
    /// Количество денег на старте
    /// </summary>
    [SerializeField] private int walletMoneyStart;

    private void Start()
    {
        walletMoneyStart = walletMoney;
        bet = 50;
        betTxt.text = "BET  " + bet;

        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }

    public void MinusBet()
    {
        if (bet > 0)
        {
            bet -= 50;
            walletMoney += 50;
        }
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }
    public void PlusBet()
    {
        if (bet < walletMoney || walletMoney > 0)
        {
            bet += 50;
            walletMoney -= 50;
        }
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }
    public void MaxBet()
    {
        if (walletMoney > 0)
        {
            bet += walletMoney;
            walletMoney = 0;
        }

        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " +  walletMoney.ToString();
    }
    public void WinCash(int winMoney)
    {
        AudioManager.Instance.WinAudio();
        walletMoney += winMoney + bet * 2;
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }
    public void LoseCash()
    {
        AudioManager.Instance.LoseAudio();
        if (walletMoney > 0)
        {
            walletMoney -= bet;
            bet = 50;
        }
        else if (walletMoney <= 0)
        {
            walletMoney = 0;
            bet = 0;
        }
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
        RegisterMoneyNull();
    }
    public void RegisterMoneyNull()
    {
        if (walletMoney <= 0)
        {
            walletMoney = 0;
            betTxt.text = "BET  " + bet;
            walletMoneyTxt.text = "$ " + walletMoney.ToString();
            StartCoroutine(CorUpdateWallet());
        }
    }
    IEnumerator CorUpdateWallet()
    {
        yield return new WaitForSeconds(20f);
        walletMoney = walletMoneyStart;
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ "+ walletMoney.ToString();
    }
}
