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
    public partial class FormOrder : Form
    {
        private List<Control> textBoxSns, textBoxPrices;
        //private List<Control> panelButtonContainers;
        private List<Control> buttonDeletes;
        private List<Control> buttonAdds;
        private List<Control> comboBoxSizes, comboBoxColors, comboBoxTypes;
        private List<List<Control>> controls;
        private Customer customer;
        private Order order;
        private List<OrderDetail> orderDetails;
        List<String> standardTypes = new List<string>(4);
        List<String> customTypes = new List<String>(2);
        private int totalAmount=0, actualAmount=0, depositAmount=0;


        public FormOrder()
        {
            initial();
            textBoxCustomerName.Enabled = true;
            textBoxTel.Enabled = true;
            buttonSearch.Visible = true;
        }

        public FormOrder(Customer customer)
        {
            this.customer = customer;
            initial();
            retrieveCustomer();
            retrieveOrder();

        }

        private void retrieveOrder()
        {
            if (customer.customerID == null)
            {
                MessageBox.Show("未找到客户信息");
                return;
            }
            order = ReadData.getOrderByCustomerId(customer.customerID);
            if (order.orderID != null)
            {
                orderDetails = ReadData.getOrderDetailsById(order.orderID);
                if (standardTypes.Contains(orderDetails.ElementAt(0).orderType))
                {
                    for (int i = 0; i < orderDetails.Count; i++)
                    {
                        generateOrderRow(i * 21 + 33);
                        textBoxSns.ElementAt(i).Text = orderDetails.ElementAt(i).wd_huohao;
                        textBoxPrices.ElementAt(i).Text = orderDetails.ElementAt(i).wd_price;
                        (comboBoxSizes.ElementAt(i) as ComboBox).DataSource = ReadData.getSizesByWdId(orderDetails.ElementAt(i).wd_id);
                        (comboBoxSizes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxSizes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_size);
                        (comboBoxColors.ElementAt(i) as ComboBox).DataSource = ReadData.getColorsByWdId(orderDetails.ElementAt(i).wd_id);
                        (comboBoxColors.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxColors.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_color);
                        (comboBoxTypes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxTypes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).orderType);

                    }

                }
                else
                {
                    //customTypes

                }
                textBoxTotalAmount.Text = order.orderAmountafter;
                textBoxTotalAmount.Focus();
                textBoxActualAmount.Text = order.totalAmount;
                textBoxDeposit.Text = order.depositAmount;
                textBoxMemo.Text = order.memo;
            }
            else
            {
                generateOrderRow(33);
                textBoxSns.ElementAt(0).Focus();
            }
        }

        private void retrieveCustomer()
        {
            if (customer == null)
            {
                customer = new Customer();
                customer.brideName = textBoxCustomerName.Text.Trim();
                customer.brideContact = textBoxTel.Text.Trim();
            }
            if (customer.brideName != "")
            {
                customer = ReadData.getCustomerByName(customer.brideName);
            }
            else if (customer.brideContact != "")
            {
                customer = ReadData.getCustomerByTel(customer.brideContact);
            }
            if (customer.customerID != null)
            {
                textBoxCustomerName.Text = customer.brideName;
                textBoxTel.Text = customer.brideContact;
            }
        }
        private void initial()
        {
            InitializeComponent();
            textBoxSns = new List<Control>();
            //panelButtonContainers = new List<Control>();
            buttonDeletes = new List<Control>();
            textBoxPrices = new List<Control>();
            comboBoxColors = new List<Control>();
            comboBoxSizes = new List<Control>();
            buttonAdds = new List<Control>();
            comboBoxTypes = new List<Control>();
            controls = new List<List<Control>>();
            controls.Add(textBoxSns);
            controls.Add(textBoxPrices);
            // controls.Add(panelButtonContainers);
            controls.Add(buttonAdds);
            controls.Add(buttonDeletes);
            controls.Add(comboBoxTypes);
            controls.Add(comboBoxColors);
            controls.Add(comboBoxSizes);

            standardTypes.AddRange(new String[] { "标准码", "量身定制", "租赁" });
            customTypes.AddRange(new String[] { "微定制", "来图定制" });
            comboBoxCustomType.DataSource = customTypes;
        }
        private void buttonBrowseLeft_Click(object sender, EventArgs e)
        {
            pictureBoxLeft.ImageLocation = getPicturePath();
        }

        private void buttonBrowseRight_Click(object sender, EventArgs e)
        {
            pictureBoxRight.ImageLocation = getPicturePath();
        }

        private String getPicturePath()
        {
            DialogResult result = openFileDialog.ShowDialog();
            String picturePath = null;
            if (result == DialogResult.OK)
            {
                picturePath = openFileDialog.FileName;
            }
            return picturePath;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxSns.Count == buttonAdds.IndexOf(sender as Button) + 1)
            {
                generateOrderRow((sender as Button).Bottom + 2);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            retrieveCustomer();
            retrieveOrder();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                if (order == null||order.orderID==null)
                {
                    order = new Order();
                    order.orderID = OrderNumberBuilder.NextBillNumber();
                    order.customerID = customer.customerID;
                    order.totalAmount = textBoxTotalAmount.Text.Trim();
                    order.depositAmount = textBoxDeposit.Text.Trim();
                    order.orderAmountafter = textBoxActualAmount.Text.Trim();
                    order.memo = textBoxMemo.Text.Trim();
                    SaveData.insertOrder(order);
                }

                if (controls.ElementAt(0).Count > 0)
                {
                    int index = 0;
                    foreach (TextBox tb in textBoxSns)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.orderID = order.orderID;
                        orderDetail.orderType = comboBoxTypes.ElementAt(index).Text.Trim();
                        orderDetail.wd_id = textBoxSns.ElementAt(index).Text.Trim();
                        orderDetail.wd_huohao = orderDetail.wd_id;
                        orderDetail.wd_color = comboBoxColors.ElementAt(index).Text.Trim();
                        orderDetail.wd_size = comboBoxSizes.ElementAt(index).Text.Trim();
                        orderDetail.wd_price = textBoxPrices.ElementAt(index).Text.Trim();
                        SaveData.insertOrderDetail(orderDetail);
                        index++;
                    }
                }
                if (pictureBoxLeft.Image != null)
                {

                }
            }
        }

        private Boolean validateInput()
        {
            if (controls.ElementAt(0).Count == 0 && pictureBoxLeft.Image == null)
            {
                MessageBox.Show("未输入有效订单！");
                return false;
            }

            if (textBoxActualAmount.Text.Trim() == "")
            {
                MessageBox.Show("实收金额不能为空！");
                textBoxActualAmount.Focus();
                return false;
            }
            if (textBoxDeposit.Text.Trim() == "")
            {
                textBoxDeposit.Text = "0";
            }
            if (controls.ElementAt(0).Count > 0)
            {
                foreach (TextBox tb in textBoxSns)
                {
                    if (tb.Text == "")
                    {
                        MessageBox.Show("货号不能为空值");
                        return false;
                    }
                }
                foreach (TextBox tb in textBoxPrices)
                {
                    if (tb.Text == "")
                    {
                        return false;
                    }
                    if (decimal.Parse(tb.Text.Trim()).ToString() != tb.Text.Trim())
                    {
                        MessageBox.Show("价格必须是数字");
                        return false;
                    }
                }
            }
            if (pictureBoxLeft.Image != null)
            {

            }
            return true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            pictureBoxLeft.Image = null;
            pictureBoxRight.Image = null;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = buttonDeletes.IndexOf(sender as Button);
            foreach (List<Control> list in controls)
            {
                list.ElementAt(index).Dispose();
                list.RemoveAt(index);
                for (int i = index; i < list.Count; i++)
                {
                    list.ElementAt(i).Top -= 25;
                }
            }
            if (controls.ElementAt(0).Count == 0)
            {
                generateOrderRow(33);
            }
        }

        private void textBoxSn_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
            {
                int index = textBoxSns.IndexOf(sender as TextBox);
                textBoxPrices.ElementAt(index).Text = ReadData.getPriceByWdId((sender as TextBox).Text);
                if (textBoxPrices.ElementAt(index).Text == "")
                {
                    MessageBox.Show("未找到此货号！");
                    (sender as TextBox).SelectAll();
                    (sender as TextBox).Focus();
                    return;
                }
                (comboBoxSizes.ElementAt(index) as ComboBox).DataSource = ReadData.getSizesByWdId((sender as TextBox).Text);
                (comboBoxColors.ElementAt(index) as ComboBox).DataSource = ReadData.getColorsByWdId((sender as TextBox).Text);
                textBoxTotalAmount.Text =(totalAmount + int.Parse(textBoxPrices.ElementAt(index).Text)).ToString();
            }
        }

        private void generateOrderRow(int top)
        {

            TextBox textBoxSn = new TextBox();
            panelList.Controls.Add(textBoxSn);
            textBoxSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxSn.Size = new System.Drawing.Size(80, 21);
            textBoxSn.TabIndex = 6;
            textBoxSn.Location = new Point(4, top);
            // textBoxSn.Name = "textBoxSn" + textBoxSns.Count;
            textBoxSn.Leave += new System.EventHandler(textBoxSn_Leave);
            textBoxSns.Add(textBoxSn);

            // 
            // comboBoxSize
            // 
            ComboBox comboBoxSize = new ComboBox();
            comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxSize.FormattingEnabled = true;
            comboBoxSize.Location = new System.Drawing.Point(84, top);
            comboBoxSize.Margin = new System.Windows.Forms.Padding(0);
            // comboBoxSize.Name = "comboBoxSize" + comboBoxSizes.Count;
            comboBoxSize.Size = new System.Drawing.Size(80, 20);
            comboBoxSize.TabIndex = 7;
            panelList.Controls.Add(comboBoxSize);
            comboBoxSizes.Add(comboBoxSize);
            // 
            // comboBoxCategory
            // 
            ComboBox comboBoxType = new ComboBox();
            comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new System.Drawing.Point(224, top);
            comboBoxType.Margin = new System.Windows.Forms.Padding(0);
            // comboBoxType.Name = "comboBoxType" + comboBoxTypes.Count;
            comboBoxType.Size = new System.Drawing.Size(80, 20);
            comboBoxType.TabIndex = 8;
            comboBoxType.DataSource = standardTypes;
            panelList.Controls.Add(comboBoxType);
            comboBoxTypes.Add(comboBoxType);

            // 
            // comboBoxColor
            // 
            ComboBox comboBoxColor = new ComboBox();
            comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Location = new System.Drawing.Point(164, top);
            comboBoxColor.Margin = new System.Windows.Forms.Padding(0);
            // comboBoxColor.Name = "comboBoxSize" + comboBoxColors.Count;
            comboBoxColor.Size = new System.Drawing.Size(60, 20);
            comboBoxColor.TabIndex = 7;
            panelList.Controls.Add(comboBoxColor);
            comboBoxColors.Add(comboBoxColor);
            // 
            // textBoxPrice
            // 
            TextBox textBoxPrice = new TextBox();
            textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxPrice.Location = new System.Drawing.Point(304, top);
            // textBoxPrice.Name = "textBoxPrice" + textBoxPrices.Count;
            textBoxPrice.Size = new System.Drawing.Size(60, 21);
            textBoxPrice.TabIndex = 10;
            textBoxPrice.Enabled = false;
            panelList.Controls.Add(textBoxPrice);
            textBoxPrices.Add(textBoxPrice);
            // 
            // buttonAdd
            // 
            Button buttonAdd = new Button();
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdd.Location = new System.Drawing.Point(368, top);
            //   buttonAdd.Name = "buttonAdd" + buttonAdds.Count;
            buttonAdd.Size = new System.Drawing.Size(30, 23);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += new System.EventHandler(buttonAdd_Click);
            buttonAdds.Add(buttonAdd);
            panelList.Controls.Add(buttonAdd);
            // 
            // buttonDelete
            // 
            Button buttonDelete = new Button();
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Location = new System.Drawing.Point(400, top);
            //    buttonDelete.Name = "buttonDelete" + buttonDeletes.Count;
            buttonDelete.Size = new System.Drawing.Size(30, 23);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Del";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += new EventHandler(buttonDelete_Click);
            buttonDeletes.Add(buttonDelete);
            panelList.Controls.Add(buttonDelete);
            // 
            // panelButtonContainer
            // 
            //Panel panelButtonContainer = new Panel();
            //panelButtonContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //panelButtonContainer.Controls.Add(buttonAdd);
            //panelButtonContainer.Controls.Add(buttonDelete);
            //panelButtonContainer.Location = new System.Drawing.Point(364, top);
            //panelButtonContainer.Name = "panelButtonContainer"+panelButtonContainers.Count;
            //panelButtonContainer.Size = new System.Drawing.Size(80, 21);
            //panelButtonContainer.TabIndex = 13;
            //panelList.Controls.Add(panelButtonContainer);
            //panelButtonContainers.Add(panelButtonContainer);
        }
    }
}
