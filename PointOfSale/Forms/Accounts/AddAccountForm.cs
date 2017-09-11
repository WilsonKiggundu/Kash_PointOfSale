using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var budget = tbBudget.Text;
            var fees = tbFees.Text;
            var currency = cbCurrency.SelectedValue;
            var depreciation = tbDepreciation.Text;

            var parentAccount = cbParentAccount.SelectedValue;
            var purchaseAccount = cbPurchaseAccount.SelectedValue;
            var balanceSheetCategory = cbBalanceSheetCategory.SelectedValue;
            var category = cbCategory.SelectedValue;
            var cashflowCategory = cbCashflowCategory.SelectedValue;

            var account = new Account
            {
                Name = name,
                Budget = budget.ToDecimal(),
                Fees = fees.ToDecimal(),
                Depreciation = depreciation.ToDecimal(),
                CurrencyId = currency.ToInteger(),
                // BalanceSheetCategory = (BalanceSheetCategory)balanceSheetCategory,
                // ParentAccountId = Convert.ToInt32(parentAccount),
                // PurchaseAccountId = Convert.ToInt32(purchaseAccount),
                // Category = (AccountCategory)category,
                // CashflowCategory = (CashflowCategory)cashflowCategory
            };

            db.Accounts.Add(account);
            db.SaveChanges();
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            var accounts = db.Accounts.OrderBy(d => d.Name)
                                .Select(s => new
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                }).ToList();

            cbPurchaseAccount.DataSource = accounts;
            cbPurchaseAccount.DisplayMember = "Name";
            cbPurchaseAccount.ValueMember = "Id";

            cbParentAccount.DataSource = accounts;
            cbParentAccount.DisplayMember = "Name";
            cbParentAccount.ValueMember = "Id";

            var currencies = db.Currencies.OrderBy(d => d.Name)
                                .Select(s => new
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                }).ToList();
            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Name";
            cbCurrency.ValueMember = "Id";

        }
    }
}
