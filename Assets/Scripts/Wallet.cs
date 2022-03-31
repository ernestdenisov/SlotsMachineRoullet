using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : SingletonBase<Wallet>
{
    [Header("Set In Inspector")]
    /// <summary>
    /// ����� ���������� �����
    /// </summary>
    [SerializeField] private int walletMoney;
    /// <summary>
    /// ������
    /// </summary>
    [SerializeField] private int bet;
    public int Bet => bet;
    /// <summary>
    /// ����� ������ ���������� �����
    /// </summary>
    [SerializeField] private Text walletMoneyTxt;
    /// <summary>
    /// ����� ������
    /// </summary>
    [SerializeField] private Text betTxt;
    [Header("Set In Dinamycally")]
    /// <summary>
    /// ���������� ����� �� ������
    /// </summary>
    [SerializeField] private int walletMoneyStart;

    /*
    в общем, у тебя везде мелькает цифра 50. Это не хорошо, не понятно что это за число
    плюс если тебе его надо будет менять, то придётся менять в 10-ти местах
    лучше создать константу и использовать её вот так

    public const int BET_STEP = 50;

    // bet -= BET_STEP;
    // walletMoney += BET_STEP;
    */
    private void Start()
    {
        walletMoneyStart = walletMoney;
        bet = 50;
        betTxt.text = "BET  " + bet;

        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }

    /*
    у тебя куча мест где дублируется вот такой код:

    betTxt.text = "BET  " + bet;
    walletMoneyTxt.text = "$ " + walletMoney.ToString();

    лучше вынести в отдельную private функцию

    private void updateWalletAndBetText() {
        betTxt.text = "BET  " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }

    но, с другой стороны это слишком разнородные операции чтобы лежать в одном методе
    и вообще очень странная логика того как связаны bet и walletMoney
    по хорошему у тебя walletMoney уменьшается при каждой ставке на размер ставки

    при этом в стандартной азартной игре пока ты не нажал на кнопку SPIN, ну то есть не начал раунд
    то пока ты меняешь Bet, то деньги в кошельке меняться не должны, они изменяются только после
    старта раунда и после победы
    */
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
        if (bet < walletMoney || walletMoney > 0) // а если walletMoney больше 0, но меньше чем 50???
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
        betTxt.text = "BET  " + bet; // вот здесь зачем тебе надо обновлять текст ставки?)))
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
            betTxt.text = "BET  " + bet; // здесь тоже ставка же не меняется + ты текст в методе выше уже обновил
            walletMoneyTxt.text = "$ " + walletMoney.ToString();
            StartCoroutine(CorUpdateWallet());
        }
    }
    IEnumerator CorUpdateWallet()
    {
        yield return new WaitForSeconds(20f);
        walletMoney = walletMoneyStart;
        betTxt.text = "BET  " + bet; // зачем тут текст менять?)
        walletMoneyTxt.text = "$ "+ walletMoney.ToString();
    }
}
