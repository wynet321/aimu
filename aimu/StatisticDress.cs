using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimu
{
    public partial class StatisticDress : Form
    {
        public StatisticDress()
        {
            InitializeComponent();
        }

        private void changeDataGridViewColumnTitle(DataGridView view)
        {
            view.Columns["wd_id"].HeaderText = "货号";
            view.Columns["cnt"].HeaderText = "次数";
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
        }

       
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }

        private void refreshDataGridViews()
        {
            Data rent = ShardDb.getDressStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), "租赁");
            if (!rent.Success)
            {
                this.Close();
                return;
            }
            dataGridViewRent.DataSource = rent.DataTable;
            Data sample = ShardDb.getDressStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), "卖样衣");
            if (!sample.Success)
            {
                this.Close();
                return;
            }
            dataGridViewSampleDress.DataSource = sample.DataTable; 
            Data standard = ShardDb.getDressStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), "标准码");
            if (!standard.Success)
            {
                this.Close();
                return;
            }
            dataGridViewStandardDress.DataSource = standard.DataTable;
            Data specific = ShardDb.getDressStatistic(dateTimePickerStartDate.Value.ToShortDateString(), dateTimePickerEndDate.Value.ToShortDateString(), "量身定制");
            if (!specific.Success)
            {
                this.Close();
                return;
            }
            dataGridViewSpecificDress.DataSource = specific.DataTable;

            changeDataGridViewColumnTitle(dataGridViewRent);
            changeDataGridViewColumnTitle(dataGridViewSampleDress);
            changeDataGridViewColumnTitle(dataGridViewStandardDress);
            changeDataGridViewColumnTitle(dataGridViewSpecificDress);
        }
    }
}
