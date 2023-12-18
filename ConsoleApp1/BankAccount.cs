using System;
using System.Collections.Generic;
using System.Text;

class BankAccount
{
    private static int _accountNumberSeed = 1234567890;

    private List<Transaction> _allTransactions = new List<Transaction>();
    
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;

        if (initialBalance != 0)
            MakeDeposit(0, DateTime.Now, "initial");
        MakeDeposit(initialBalance, DateTime.Now, "initial balance");
    }
    
    public string Number { get; }

    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var trans in _allTransactions)
            {
                balance += trans.Amount;
            }

            return balance;
        }
    }
    
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, "Ammount must have positive value.");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, "Ammount must have positive value.");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }

        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }

    // homework #4
    public string GetAccountHistory()
    {
        var history = new StringBuilder();

        history.AppendLine("Transaction History:");
        foreach (var trans in _allTransactions)
        {
            history.AppendLine($"Date: {trans.Date}, Amount: {trans.Amount}, Notes: {trans.Notes}, Balance: {CalculateBalanceAtTransaction(trans)}");
        }

        return history.ToString();
    }

    private decimal CalculateBalanceAtTransaction(Transaction transaction)
    {
        decimal balance = 0;
        foreach (var trans in _allTransactions)
        {
            balance += trans.Amount;
            if (trans == transaction)
            {
                break;
            }
        }

        return balance;
    }
}