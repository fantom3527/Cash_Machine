﻿using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace CashMachine.Infrastructure.DataAccess.Migrations;

/// <summary>
/// Миграция для создания начальных данных.
/// </summary>
[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    /// <summary>
    /// Получает SQL-скрипт для применения миграции.
    /// </summary>
    /// <param name="serviceProvider">Провайдер служб.</param>
    /// <returns>SQL-скрипт для создания типа "user_role".</returns>
    protected override string GetUpSql(IServiceProvider serviceProvider)
        => @"
    CREATE TYPE ""user_role"" as enum
    (
        'admin',
        'customer'
    );

    CREATE TYPE bank_account_history_method as enum
    (
        'add',
        'delete',
        'edit',
        'withdrawbalance',
        'topupbalance'
    );

    CREATE TABLE ""user"" (
        id UUID PRIMARY KEY,
        password_hash VARCHAR(64) NOT NULL,
        role user_role NOT NULL,
        name VARCHAR(255) NOT NULL,
        description TEXT,
        actual BOOLEAN NOT NULL,
        ts TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL
    );

    CREATE TABLE IF NOT EXISTS bank_account (
        id UUID PRIMARY KEY,
        user_id UUID NOT NULL REFERENCES ""user""(id),
        pin_code_hash VARCHAR(64),
        ""number"" SMALLINT NOT NULL,
        balance DECIMAL(20, 2) NOT NULL,
        actual BOOLEAN NOT NULL,
        ts TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL
    );

    CREATE TABLE IF NOT EXISTS bank_account_history (
        id UUID PRIMARY KEY,
        bank_account_id UUID NOT NULL REFERENCES bank_account(id),
        method bank_account_history_method NOT NULL,
        description TEXT,
        ts TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL
    );
    ";

    /// <summary>
    /// Переопределение метода для запроса SQL на удаление таблиц в базе данных, если не получилось их добавить в GetUpSql.
    /// </summary>
    /// <param name="serviceProvider">Провайдер служб для взаимодействия с внешним сервисами и фреймворками.</param>
    /// <returns>SQL-запрос на удаление таблиц пользователя, банковского счета и истории банковских счетов.</returns>
    protected override string GetDownSql(IServiceProvider serviceProvider)
        => @"
    DROP TABLE ""user"";
    DROP TABLE bank_account
    DROP TABLE bank_account_history

    DROP TYPE ""user_role""
    DROP TYPE bank_account_history_method
    ";

}

