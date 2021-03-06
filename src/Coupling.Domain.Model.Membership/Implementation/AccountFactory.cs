﻿
using System;

namespace Coupling.Domain.Model.Membership.Implementation
{
    public class AccountFactory : IAccountFactory
    {
        private readonly IAccountRepository _repository;

        public AccountFactory(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Account Create(string username, string salt, string hashPassword, string activationToken)
        {
            if (_repository.GetByUsername(username) != null) throw new Exception("Account with Username already exists");

            var acc = new Account();
            if (string.IsNullOrEmpty(activationToken))
            {

                acc.SetCredentials(_repository.GetNextUserId(), username, salt, hashPassword);
                acc.Activate(activationToken);
            }
            else
            {
                acc.SetCredentials(_repository.GetNextUserId(), username, salt, hashPassword, activationToken);
            }

            _repository.Store(acc);
            return acc;
        }
    }
}
