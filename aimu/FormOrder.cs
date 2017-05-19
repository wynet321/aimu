﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Decimal totalAmount = 0, actualAmount = 0, depositAmount = 0;


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

                for (int i = 0; i < orderDetails.Count; i++)
                {
                    if (standardTypes.Contains(orderDetails.ElementAt(i).orderType))
                    {
                        generateOrderRow(i * 21 + 33);
                        textBoxSns.ElementAt(i).Text = orderDetails.ElementAt(i).wd_id;
                        textBoxPrices.ElementAt(i).Text = orderDetails.ElementAt(i).wd_price;
                        textBoxMemo.Text = orderDetails.ElementAt(i).memo;
                        (comboBoxSizes.ElementAt(i) as ComboBox).DataSource = ReadData.getSizesByWdId(orderDetails.ElementAt(i).wd_id);
                        (comboBoxSizes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxSizes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_size);
                        (comboBoxColors.ElementAt(i) as ComboBox).DataSource = ReadData.getColorsByWdId(orderDetails.ElementAt(i).wd_id);
                        (comboBoxColors.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxColors.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_color);
                        (comboBoxTypes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxTypes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).orderType);
                    }
                    else
                    {
                        //customTypes
                        comboBoxCustomType.SelectedIndex = comboBoxCustomType.FindStringExact(orderDetails.ElementAt(i).orderType);
                        byte[] imageBinary = (byte[])orderDetails.ElementAt(i).wd_image;
                        string imageLocation = "./images/" + Guid.NewGuid().ToString();
                        FileStream fs = new FileStream(imageLocation, FileMode.Create, FileAccess.Write);
                        fs.Write(imageBinary, 0, imageBinary.Length);
                        fs.Flush();
                        fs.Close();
                        if (pictureBoxLeft.ImageLocation == null)
                        {
                            pictureBoxLeft.ImageLocation = imageLocation;
                            pictureBoxLeft.Load();
                        }
                        else
                        {
                            pictureBoxRight.ImageLocation = imageLocation;
                            pictureBoxRight.Load();
                        }
                    }
                }

                textBoxTotalAmount.Text = order.totalAmount;
                textBoxTotalAmount.Focus();
                textBoxActualAmount.Text = order.orderAmountafter;
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

        private static void showProcessing()
        {
            FormProcessing fp = new FormProcessing();
            fp.ShowDialog();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
               
                ThreadStart ts = new ThreadStart(showProcessing);
                Thread wait = new Thread(ts);
                wait.Start();
                if (controls.ElementAt(0).Count > 0)
                {
                    int index = 0;
                    orderDetails = new List<OrderDetail>();
                    foreach (TextBox tb in textBoxSns)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.orderID = order.orderID;
                        orderDetail.orderType = comboBoxTypes.ElementAt(index).Text.Trim();
                        orderDetail.wd_id = textBoxSns.ElementAt(index).Text.Trim();
                        //orderDetail.wd_huohao = orderDetail.wd_id;
                        orderDetail.wd_color = comboBoxColors.ElementAt(index).Text.Trim();
                        orderDetail.wd_size = comboBoxSizes.ElementAt(index).Text.Trim();
                        orderDetail.wd_price = textBoxPrices.ElementAt(index).Text.Trim();
                        orderDetails.Add(orderDetail);
                        index++;
                    }
                }
                if (pictureBoxLeft.Image != null)
                {
                    OrderDetail orderDetail = createImageOrderDetail(pictureBoxLeft.ImageLocation);
                    orderDetails.Add(orderDetail);
                }
                if (pictureBoxRight.Image != null)
                {
                    OrderDetail orderDetail = createImageOrderDetail(pictureBoxRight.ImageLocation);
                    orderDetails.Add(orderDetail);
                }
                if (order == null || order.orderID == null)
                {
                    order = new Order();
                    order.orderID = OrderNumberBuilder.NextBillNumber();
                    order.customerID = customer.customerID;
                    order.totalAmount = textBoxTotalAmount.Text.Trim();
                    order.depositAmount = textBoxDeposit.Text.Trim();
                    order.orderAmountafter = textBoxActualAmount.Text.Trim();
                    order.memo = textBoxMemo.Text.Trim();
                    SaveData.insertOrder(order, orderDetails);
                }
                else
                {
                    order.totalAmount = textBoxTotalAmount.Text.Trim();
                    order.depositAmount = textBoxDeposit.Text.Trim();
                    order.orderAmountafter = textBoxActualAmount.Text.Trim();
                    order.memo = textBoxMemo.Text.Trim();
                    SaveData.updateOrderbyId(order,orderDetails);
                }
                wait.Abort();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();
                this.Close();
            }
        }

        private OrderDetail createImageOrderDetail(string imageLocation)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.orderID = order.orderID;
            orderDetail.orderType = comboBoxCustomType.Text.Trim();
            orderDetail.wd_id = OrderNumberBuilder.NextBillNumber();
            long imageSize = 0;
            byte[] imageBinary;
            FileInfo imageInfo = new FileInfo(imageLocation);
            imageSize = imageInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
            imageBinary = new byte[Convert.ToInt32(imageSize)];
            fs.Read(imageBinary, 0, Convert.ToInt32(imageSize));
            fs.Close();
            orderDetail.wd_image = imageBinary;
            return orderDetail;
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string printTitle = "IAM艾慕婚纱礼服订单凭证";
            //orderData = "";
            Font drawTitleFont = new Font("Arial", 12);
            Font drawContentFont = new Font("Arial", 10);
            Font drawDateFont = new Font("Arial", 8);
            Font drawWarningFont = new Font("Arial", 6);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);

            //Body 
            float startBody = 35f;
            float stepBody = 20f;
            float stepBodySmall = 15f;
            int iNum = 0;
            int iNumHSLF = 1;

            e.Graphics.DrawString("订单编号:" + customer.customerID, drawContentFont, drawBrush, 25f, 10f);//打印编号
            e.Graphics.DrawString(printTitle, drawTitleFont, drawBrush, 250f, 10f);//打印标题
            e.Graphics.DrawString("打印日期:" + DateTime.Now.ToLongDateString(), drawDateFont, drawBrush, 590f, 5f);//打印日期
            e.Graphics.DrawString("接待顾问：" + customer.jdgw, drawDateFont, drawBrush, 590f, 20f);//打印接待顾问


            string printBrideLine = string.Format("{0,-20}", "新娘姓名：" + customer.brideName) + string.Format("{0,-20}", "新娘电话：" + customer.brideContact) + string.Format("{0,-20}", "新郎姓名：" + customer.groomName) + string.Format("{0,-20}", "新郎电话：" + customer.groomContact);
            string printTaoBao = string.Format("{0,-20}", "客户渠道：" + customer.infoChannel) + string.Format("{0,-20}", "旺旺ID:" + customer.wangwangID) + string.Format("{0,-20}", "成交日期：" + DateTime.Now.Date.ToString("yyyy-MM-dd"));

            //string qv = this.radioButton1.Checked ? "到店" : "快递";
            //string huan = this.radioButton4.Checked ? "到店" : "快递";


            //string printWeddingDayLine = string.Format("{0,-20}", "婚期：" + customer.marryDay + string.Format("{0,-30}", "取纱方式:" + qv + " 日期：" + dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            //string printPostAddress = string.Format("{0,-100}", "邮寄地址：" + customer.address);

            //35f
            e.Graphics.DrawString("_____________________________________________________________________________________________________________________________________________", drawTitleFont, drawBrush, 25f, startBody + (iNum++) * stepBody - 5);
            e.Graphics.DrawString(printBrideLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printTaoBao, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            //e.Graphics.DrawString(printWeddingDayLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            //e.Graphics.DrawString(printPostAddress, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);

            //身材数据 135f            
            e.Graphics.DrawString("身材数据:", drawContentFont, drawBrush, 25f, 135f);
            e.Graphics.DrawString("净身高：" + customer.scsj_jsg + "cm  穿鞋身高：" + customer.scsj_cxsg + "cm  体重：" + customer.scsj_tz+ "kg  胸围：" + customer.scsj_xw + "cm  下胸围：" + customer.scsj_xxw + "cm  腰围：" + customer.scsj_yw + "cm  肚脐围：" + customer.scsj_dqw + "cm  ", drawDateFont, drawBrush, 45f, 135f + 1 * stepBodySmall);
            e.Graphics.DrawString("臀围：" + customer.scsj_tw + "cm  肩宽：" + customer.scsj_jk + "cm  颈围：" + customer.scsj_jw + "cm  大臀围：" + customer.scsj_dbw + "cm  腰到底长：" + customer.scsj_yddc + "cm  前腰结：" + customer.scsj_qyj + "cm  BP距离：" + customer.scsj_bpjl + "cm", drawDateFont, drawBrush, 45f, 135f + 2 * stepBodySmall);

            //婚纱礼服数据  185f
            //string printContent = "1490    婚纱    白纱    XL    白色   ￥1390";

            e.Graphics.DrawString("婚纱礼服数据:", drawContentFont, drawBrush, 25f, 185f);
            e.Graphics.DrawString("编号    大类    小类    尺码    颜色    价格", drawDateFont, drawBrush, 45f, 185f + stepBody);

            //dataGridView2.Refresh();
            StringBuilder sb = new StringBuilder();
            foreach(OrderDetail orderDetail in orderDetails)
            {
                sb.Append(orderDetail.orderID).Append("    ").Append(orderDetail.orderType).Append("    ").Append(orderDetail.wd_color).Append("    ").Append(orderDetail.wd_size).Append("    ").Append(orderDetail.wd_price).Append("    ").Append(orderDetail.memo).Append("    ").Append(orderDetail.wd_id).Append("\n");
            }
            e.Graphics.DrawString(sb.ToString(), drawDateFont, drawBrush, 45f, 185f + stepBody + (iNumHSLF++) * stepBodySmall);
            //foreach (DataGridViewRow r in dataGridView2.Rows)
            //{
            //    string printContent = "";

            //    for (int ij = 0; ij < r.Cells.Count; ij++)
            //    {
            //        try
            //        {
            //            printContent += r.Cells[ij].Value.ToString() + "    ";
            //        }
            //        catch (Exception ef)
            //        {
            //            //MessageBox.Show(ef.ToString());
            //            printContent += "";
            //        }
            //    }
            //    orderData += printContent + "~";
            //    e.Graphics.DrawString(printContent, drawDateFont, drawBrush, 45f, 185f + stepBody + (iNumHSLF++) * stepBodySmall);
            //}


            //订单金额 340f
            //e.Graphics.DrawString("订单金额:", drawContentFont, drawBrush, 45f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString("订单金额:￥" + order.totalAmount + "    实付金额：￥" + order.orderAmountafter+ "     租金：￥"+ order.depositAmount, drawDateFont, drawBrush, 25f, 310f);


            //计算合计金额
            //try
            //{
            //    float tbResultAmountTmp = 0.0f;


            //    if (float.TryParse(tbResultAmount.Text.Trim(), out tbResultAmountTmp))
            //    {
            //        f_num_total = tbResultAmountTmp;
            //    }




            //}
            //catch (Exception ef)
            //{
            //    MessageBox.Show("输入错误");
            //}
            //e.Graphics.DrawString("合计金额： ￥" + f_num_total.ToString(), drawDateFont, drawBrush, 25f, 310f + stepBody - 5);


            //warning  340f
            float startWarning = 340f;
            float stepWarning = 15;
            int jNum = 0;
            e.Graphics.DrawString("温馨提示:", drawDateFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("1.工期说明：艾慕婚纱量身定制和来图定制的制作工期为50-60天，根据款式、工艺、改版要求等不同，定制时间不同，具体工期以店内婚纱顾问确认时间为准。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("                       定制工期以客户实际支付之日开始计算；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("2.尺寸说明：量身定制/来图定制的婚纱，尺寸以店内婚纱顾问实际测量尺寸为准。定制婚纱如出现尺寸与订单尺寸不符的情况，无条件免费修改。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("                       非定制（标准码）婚纱款式，不提供尺寸修改服务；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("3.退换货说明：婚纱订单在交付全款后生效。婚纱定制的款式以实际网拍/店内确认为准。在网拍/店内确认之前如需调换婚纱款式，需要联系婚纱顾问重新确认工期、尺寸测量及定制细节。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("                       在量身/来图定制订单生效后，如果客人取消订单，费用不退还。量身/来图定制类的婚纱如有任何质量问题，艾慕提供无条件修改，量身/来图定制类婚纱不退换。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("                       标准码婚纱，签收后48小时内，保持婚纱整洁可联系客服退换。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("婚纱顾问签名：", drawDateFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("顾客签名：", drawDateFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", drawTitleFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("地址：" + Sharevariables.getUserAddress(), drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("预约电话：" + Sharevariables.getUserTel(), drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("店铺网址：http://iambride.taobao.com  http://iam-missy.taobao.com", drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("官网网址：http://www.iambride.com.cn", drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);


            //如果打印还有下一页，将HasMorePages值置为true;
            e.HasMorePages = false;

            //coPre.orderID = OrderNumberBuilder.NextBillNumber();
            //coPre.customerID = customer.customerID;
            //coPre.wdData = orderData.Trim();
            //coPre.orderAmountPre = tbOrderAmount.Text.Trim();
            //coPre.orderAmountafter = tbResultAmount.Text.Trim();
            //coPre.orderDiscountRate = tbDiscount.Text.Trim();
            //coPre.orderPaymentMethod = comboBox2.Text.Trim();
            //coPre.reservedAmount = "";// textBox1.Text.Trim();//定金金额
            //coPre.depositAmount = "";// tbDeposit.Text.Trim();//订单押金金额
            //coPre.depositPaymentMethod = "";// comboBox3.Text.Trim();
            //coPre.totalAmount = f_num_total.ToString();
            //coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            //coPre.orderStatus = "0";//0 订单进行中，1结束订单  需要在归还页面里设置为1
            //coPre.orderType = "标准码订单";  //0 定金类型，1租赁订单类型 ，2标准码订单，3量身定制，4来图定制            
            //coPre.receptionConsultant = tbJDGW.Text.Trim();


            //coPre.shenpiren = comboBox3.Text;
            //coPre.gongfei = "";
            //coPre.jiajifei = "";
            //coPre.jiachangfei = "";
            //coPre.jiakuanfei = "";
        }

        private Boolean validateInput()
        {
            if (controls.ElementAt(0).Count == 0 && pictureBoxLeft.Image == null)
            {
                MessageBox.Show("未输入有效订单！");
                return false;
            }
            if (textBoxTotalAmount.Text.Trim() == "")
            {
                MessageBox.Show("订单金额不能为空！");
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

            Decimal i;
            if (Decimal.TryParse(textBoxTotalAmount.Text.Trim(), out i))
            {
                totalAmount = Decimal.Parse(textBoxTotalAmount.Text.Trim());
            }
            if (Decimal.TryParse(textBoxActualAmount.Text.Trim(), out i))
            {
                actualAmount = Decimal.Parse(textBoxActualAmount.Text.Trim());
            }
            if (Decimal.TryParse(textBoxDeposit.Text.Trim(), out i))
            {
                depositAmount = Decimal.Parse(textBoxDeposit.Text.Trim());
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
                //textBoxTotalAmount.Text =(totalAmount + int.Parse(textBoxPrices.ElementAt(index).Text)).ToString();
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
