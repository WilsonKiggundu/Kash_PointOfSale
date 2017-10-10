using System;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;

namespace PointOfSale.Forms.Accounts
{
    public partial class AddAccountForm : Form
    {
        private readonly PointOfSaleContext db = new PointOfSaleContext();
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            var budget = cbBudget.Checked;
            var fees = cbFees.Checked;
            var currency = cbCurrency.SelectedValue.ToInteger();
            var depreciation = tbDepreciation.Text.ToDecimal();

            var parentAccount = cbParentAccount.SelectedValue.ToInteger();
            var balanceSheetCategory = cbBalanceSheetCategory.SelectedValue.GetEnumValue<BalanceSheetCategory>();
            var category = cbCategory.SelectedValue.GetEnumValue<AccountCategory>();
            var cashflowCategory = cbCashflowCategory.SelectedValue.GetEnumValue<CashflowCategory>();

            var account = new Account
            {
                Name = name,
                Budget = budget,
                Fees = fees,
                Depreciation = depreciation,
                CurrencyId = currency.ToInteger(),
                BalanceSheetCategory = balanceSheetCategory,
                ParentAccountId = parentAccount > 0 ? parentAccount : null,
                Category = category,
                CashflowCategory = cashflowCategory
            };

            db.Accounts.Add(account);
            db.SaveChanges();

            Close();
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = Enum.GetValues(typeof(AccountCategory));

            var accounts = db.Accounts.OrderBy(d => d.Name)
                                .Select(s => new
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                }).ToList();
            
            accounts.Insert(0, new {Id = 0, Name = "-- Select Account --"});

            cbParentAccount.DataSource = new BindingSource(accounts, null);
            cbParentAccount.DisplayMember = "Name";
            cbParentAccount.ValueMember = "Id";

            var currencies = db.Currencies.OrderBy(d => d.Name)
                                .Select(s => new
                                {
                                    Id = s.Id,
                                    Name = s.Code
                                }).ToList();

            currencies.Insert(0, new { Id = 0, Name = "-- Select Currency --" });

            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Name";
            cbCurrency.ValueMember = "Id";

        }
    }
}
