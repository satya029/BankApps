﻿using Bank.Application.CQRS.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bank.Application.AccountDomain.Commands
{
    public class MoneyTransferCommand : ICommand
    {
        [Required]
        public int ReceiverAccountId { get; set; }

        [Required]
        public int SenderAccountId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}