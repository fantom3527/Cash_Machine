using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace CashMachine.Infrastructure.DataAccess.Migrations
{
    [Migration(2, "FillTestData")]
    public class FillTestData : SqlMigration
    {
        protected override string GetUpSql(IServiceProvider serviceProvider)
            => @"
		INSERT INTO ""user""(
		id, password_hash, role, name, description, actual, ts)
		VALUES ('0652e7d2-2864-4c98-822f-ce60302be94c', 
				'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'admin', 'Anton', 
				'Good boy', true, '2020-12-20 00:00:00'),
				('5b5a2f88-0f8d-4bdd-800d-72e797aae415', 
				 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'customer', 'Roman', 
				 'Nice Man', true, '2002-10-21 00:00:00');

        INSERT INTO bank_account(
	    id, user_id, pin_code_hash, ""number"", balance, actual, ts)
	    VALUES ('b5383568-0776-44eb-b22a-05b6220b8ed9', '0652e7d2-2864-4c98-822f-ce60302be94c', 
			    'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '123',
			    '20000', true, '2001-12-22 00:00:00');
        ";

        protected override string GetDownSql(IServiceProvider serviceProvider)
            => @"
		DELETE FROM bank_account;
		DELETE FROM ""user"";
		";
    }
}
