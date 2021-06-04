﻿using Gof.Design.Patterns.Winforms.Extensions;
using Gof.Design.Patterns.Winforms.Patterns.Facade;
using Gof.Design.Patterns.Winforms.Patterns.Template;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Gof.Design.Patterns.Winforms.Forms.Employee
{
    public partial class FrmComputation : Form
    {
        public FrmComputation()
        {
            InitializeComponent();
        }

        private void AddStatus(string msg)
        {
            dgvStatus.Rows.Insert(0, new string[]
            {
                DateTime.Now.StandardDt(), msg
            });
            dgvStatus.RowsDefaultCellStyle.BackColor = Color.Black;
            dgvStatus.RowsDefaultCellStyle.ForeColor = Color.White;

        }
        private void DataGridViewStatusInit()
        {
            dgvStatus.AutoGenerateColumns = false;

            DataGridViewColumn colDate = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "statDate";
            colDate.HeaderText = "Date";
            colDate.Name = "statDate";
            colDate.Width = 100;
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn colMessage = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "statMessage";
            colMessage.HeaderText = "Message";
            colMessage.Name = "statMessage";
            colMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvStatus.Columns.Add(colDate);
            dgvStatus.Columns.Add(colMessage);


        }

        private void FrmComputation_Load(object sender, EventArgs e)
        {
            this.DataGridViewStatusInit();
            EmployeeFacade employeeFacade = new EmployeeFacade();
            foreach (var employee in employeeFacade.EmployeeList)
            {
                this.AddStatus("Computing gross-income of " + employee.Name);
                //Thread.Sleep(700);
            }
            foreach (var employee in employeeFacade.EmployeeList)
            {
                this.AddStatus("Computing deduction of " + employee.Name);
                //Thread.Sleep(700);
            }
            foreach (var employee in employeeFacade.EmployeeList)
            {
                this.AddStatus("Computing net-income of " + employee.Name);
                //Thread.Sleep(700);
            }
        }
    }
}
