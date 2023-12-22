﻿namespace CashMachine.Application.Models.BankAccounts;

public record BankAccount(Guid Id, Guid UserId, ushort Number, string PinCodeHash, decimal Balance, bool Actual, DateTime Ts);