using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<OrderDetail> orderDetails, originalOrderDetails;
        string[] standardTypes;
        string[] customTypes;
        private Decimal totalAmount = 0, actualAmount = 0, depositAmount = 0;


        public FormOrder()
        {
            initial();
            textBoxCustomerName.Enabled = true;
            textBoxTel.Enabled = true;
            buttonSearch.Visible = true;
            comboBoxDeliveryType.SelectedIndex = 0;
            dateTimePickerGetDate.Value = DateTime.Today;
            dateTimePickerReturnDate.Value = DateTime.Today;
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
                originalOrderDetails = new List<OrderDetail>(orderDetails);
                for (int i = 0; i < orderDetails.Count; i++)
                {
                    if (standardTypes.Contains(orderDetails.ElementAt(i).orderType))
                    {
                        generateOrderRow(i * 21 + 33);
                        textBoxSns.ElementAt(i).Text = orderDetails.ElementAt(i).wd_id;
                        textBoxPrices.ElementAt(i).Text = orderDetails.ElementAt(i).wd_price;
                        textBoxMemo.Text = orderDetails.ElementAt(i).memo;
                        List<string> sizes = ReadData.getSizesByWdId(orderDetails.ElementAt(i).wd_id);
                        (comboBoxSizes.ElementAt(i) as ComboBox).DataSource = sizes;
                        (comboBoxSizes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxSizes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_size);

                        //if (sizes.Contains(orderDetails.ElementAt(i).wd_size))
                        //{
                        //    (comboBoxSizes.ElementAt(i) as ComboBox).DataSource = sizes;
                        //    (comboBoxSizes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxSizes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_size);
                        //}
                        //else
                        //{
                        //    (comboBoxSizes.ElementAt(i) as ComboBox).Items.Add(orderDetails.ElementAt(i).wd_size);
                        //    (comboBoxSizes.ElementAt(i) as ComboBox).SelectedIndex = (comboBoxSizes.ElementAt(i) as ComboBox).FindStringExact(orderDetails.ElementAt(i).wd_size);
                        //}
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
                comboBoxDeliveryType.SelectedIndex = comboBoxDeliveryType.FindStringExact(order.deliveryType);
                //if (comboBoxDeliveryType.SelectedIndex == 0)
                //{
                textBoxAddress.Text = order.address;
                //}
                //else
                //{
                dateTimePickerGetDate.Value = order.getDate;
                dateTimePickerReturnDate.Value = order.returnDate;
                // }
            }
            else
            {
                generateOrderRow(33);
                comboBoxDeliveryType.SelectedIndex = 0;
                dateTimePickerGetDate.Value = DateTime.Today;
                dateTimePickerReturnDate.Value = DateTime.Today;
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
                if (customer.brideName != "")
                {
                    customer = ReadData.getCustomerByName(customer.brideName);
                }
                else if (customer.brideContact != "")
                {
                    customer = ReadData.getCustomerByTel(customer.brideContact);
                }
            }
            else
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

            standardTypes = new String[] { "租赁", "标准码", "量身定制", "卖样衣" };
            customTypes = new String[] { "微定制", "来图定制" };
            comboBoxCustomType.Items.AddRange(customTypes);
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
                bool isNewOrder = false;
                if (order == null || order.orderID == null)
                {
                    isNewOrder = true;
                    order = new Order();
                    order.orderID = OrderNumberBuilder.NextBillNumber();
                    order.customerID = customer.customerID;
                }
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

                //if (comboBoxDeliveryType.SelectedIndex == 0)
                //{
                //    order.getDate = new DateTime(1900, 01, 01);
                //    order.returnDate = order.getDate;
                //}
                //else
                //{
                order.getDate = dateTimePickerGetDate.Value;
                order.returnDate = dateTimePickerReturnDate.Value;
                //}
                order.address = textBoxAddress.Text.Trim();
                order.deliveryType = comboBoxDeliveryType.Text.Trim();
                order.totalAmount = textBoxTotalAmount.Text.Trim();
                order.depositAmount = textBoxDeposit.Text.Trim();
                order.orderAmountafter = textBoxActualAmount.Text.Trim();
                order.memo = textBoxMemo.Text.Trim();
                if (isNewOrder)
                {
                    SaveData.insertOrder(order, orderDetails);
                }
                else
                {
                    SaveData.updateOrderbyId(order, orderDetails, originalOrderDetails);
                }
                wait.Abort();
                if (MessageBox.Show("打印否？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormPrintPreview printPreviewForm = new FormPrintPreview(printDocument);
                    printPreviewForm.ShowDialog();
                    printDocument.Print();
                }
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
            Font drawTitleFont = new Font("新宋体", 12);
            Font drawContentFont = new Font("新宋体", 10);
            Font drawDateFont = new Font("新宋体", 8);
            Font drawWarningFont = new Font("新宋体", 6);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);

            //Body 
            float startBody = 35f;
            float stepBody = 20f;
            float stepBodySmall = 15f;
            int iNum = 0;
            int iNumHSLF = 1;
            e.Graphics.DrawString("订单编号:" + customer.customerID, drawDateFont, drawBrush, 25f, 10f);//打印编号
            e.Graphics.DrawString(printTitle, drawTitleFont, drawBrush, 270f, 10f);//打印标题
            e.Graphics.DrawString("打印日期:" + DateTime.Now.ToLongDateString(), drawDateFont, drawBrush, 590f, 5f);//打印日期
            e.Graphics.DrawString("接待顾问：" + customer.jdgw, drawDateFont, drawBrush, 590f, 20f);//打印接待顾问
            string printBrideLine = string.Format("{0,-12}", "新娘姓名：" + customer.brideName) + string.Format("{0,-12}", "新娘电话：" + customer.brideContact) + string.Format("{0,-12}", "新郎姓名：" + customer.groomName) + string.Format("{0,-12}", "新郎电话：" + customer.groomContact) + string.Format("{0,-20}", "婚期：" + customer.marryDay);
            string printTaoBao = string.Format("{0,-16}", "客户渠道：" + customer.infoChannel) + string.Format("{0,-20}", "旺旺ID:" + customer.wangwangID + "   备注: " + order.memo);

            //string deliveryText;
            //if (comboBoxDeliveryType.SelectedIndex == 0)
            //{
            //    deliveryText = string.Format("{0,-20}", "婚期：" + customer.marryDay) + ;
            //}
            //else
            //{
            string deliveryText = string.Format("{0,-10}", "收货方式:" + order.deliveryType) + string.Format("{0,-15}", "取纱日:" + order.getDate.ToShortDateString()) + string.Format("{0,-15}", "还纱日:" + order.returnDate.ToShortDateString()) + string.Format("{0,-80}", "地址:" + order.address);
            //}

            e.Graphics.DrawString("__________________________________________________________________________________________", drawTitleFont, drawBrush, 25f, startBody + (iNum++) * stepBody - 10);
            e.Graphics.DrawString(printBrideLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(deliveryText, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString("净身高：" + customer.scsj_jsg + "cm  穿鞋身高：" + customer.scsj_cxsg + "cm  体重：" + customer.scsj_tz + "kg  胸围：" + customer.scsj_xw + "cm  下胸围：" + customer.scsj_xxw + "cm  腰围：" + customer.scsj_yw + "cm  肚脐围：" + customer.scsj_dqw + "cm  臀围：" + customer.scsj_tw + "cm  肩宽：" + customer.scsj_jk + "cm", drawWarningFont, drawBrush, 25f, startBody + (iNum++) * stepBody + 5);
            e.Graphics.DrawString("颈围：" + customer.scsj_jw + "cm  大臀围：" + customer.scsj_dbw + "cm  腰到底长：" + customer.scsj_yddc + "cm  前腰结：" + customer.scsj_qyj + "cm  BP距离：" + customer.scsj_bpjl + "cm", drawWarningFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printTaoBao, drawWarningFont, drawBrush, 25f, startBody + (iNum++) * stepBody);

            //婚纱礼服数据
            e.Graphics.DrawString("订单编号" + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount("订单编号")).ToString() + "货号" + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount("货号")).ToString() + "类型" + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount("类型")).ToString() + "颜色" + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount("颜色")).ToString() + "尺码" + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount("尺码")).ToString() + "价格" + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount("价格")).ToString(), drawDateFont, drawBrush, 35f, startBody + (iNum++) * stepBody);

            foreach (OrderDetail orderDetail in orderDetails)
            {
                if (customTypes.Contains(orderDetail.orderType))
                {
                    e.Graphics.DrawString(orderDetail.orderID + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.orderID)).ToString() + orderDetail.wd_id + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.wd_id)).ToString() + orderDetail.orderType + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.orderType)).ToString(), drawDateFont, drawBrush, 35f, startBody + (iNum - 1) * stepBody + (iNumHSLF++) * stepBodySmall);
                }
                else
                {
                    e.Graphics.DrawString(orderDetail.orderID + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.orderID)).ToString() + orderDetail.wd_id + new StringBuilder().Insert(0, " ", 30 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.wd_id)).ToString() + orderDetail.orderType + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.orderType)).ToString() + orderDetail.wd_color + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.wd_color)).ToString() + orderDetail.wd_size + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.wd_size)).ToString() + orderDetail.wd_price + new StringBuilder().Insert(0, " ", 15 - Encoding.GetEncoding("GB2312").GetByteCount(orderDetail.wd_price)).ToString(), drawDateFont, drawBrush, 35f, startBody + (iNum - 1) * stepBody + (iNumHSLF++) * stepBodySmall);
                }
            }

            //订单金额 260f
            e.Graphics.DrawString("订单金额:￥" + order.totalAmount + "    实付金额：￥" + order.orderAmountafter + "     租赁押金：￥" + order.depositAmount, drawDateFont, drawBrush, 25f, 260f);

            float startWarning = 280f;
            float stepWarning = 15;
            int jNum = 0;
            e.Graphics.DrawString("温馨提示:", drawDateFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("1.租赁流程：订单签署当日支付订单全额租金，我们将确保您在租期内的产品库存和品质；如支付定金，请在三日内补齐尾款，以便保证产品库存和品质；婚纱使用前1周新娘需到店测量尺寸，以", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("  保证我们为您提供合身的产品；婚纱使用前1天到店取订单内全部产品，并付清押金（除租金外产品出售总价）；订单内产品退还当日，退还押金；由于客人个人原因取消订单，租金/定金不退还。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("2.租期说明：店内商品租金为租赁3天的价格，若使用时间超过3天，按照租金*20%/日额外加收。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("3.押金说明：押金为保证店内产品正常使用并退还。退还时，如出现不可修复的产品污损，根据情况，将扣除产品售价的5%-100%为赔偿金；若产品未退还，押金不退。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("4.租赁婚纱使用提示：结婚当天新娘尽量避免接触红酒、彩条喷雾、冷烟花等容易对婚纱造成无法修复伤害的物品，避免婚纱污损带来的现场尴尬及经济损失。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("5.定制工期说明：艾慕婚纱量身定制和来图定制的制作工期为50-60天，根据款式、工艺、改版要求等不同，定制时间不同，具体工期以店内婚纱顾问确认时间为准。定制工期以客户实际支付之日开始计算。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("6.尺寸说明：量身定制/来图定制的婚纱，尺寸以店内婚纱顾问实际测量尺寸为准。定制婚纱如出现尺寸与订单尺寸不符的情况，无条件免费修改；非定制（标准码）婚纱款式，不提供尺寸修改服务。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("7.定制服装，由于手工定制产品的特性，产品与样板允许有轻微的差异，包括但不限于面料的轻微色差、手工缝花的差异等。如顾客方有特殊要求，应在签订合同前确认。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("8.关于租赁退单的说明：在支付租金后的三天内申请退单，收取租金额度的20%做为违约金；在支付租金后的七天内申请退单，收取租金额度的50%做为违约金；超过七天退单的，租金不可退；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("  只交定金申请退单的，定金不可退。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("9.定制退换货说明：婚纱订单在交付全款后生效。婚纱定制的款式以实际网拍/店内确认为准。在网拍/店内确认之前如需调换婚纱款式，需要联系婚纱顾问重新确认工期、尺寸测量及定制细节。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("  量身/来图定制的订单，如果客人取消订单，费用不退还；量身定制类的婚纱如有问题，艾慕提供无条件修改，非质量问题不退货。标准码婚纱签收后48小时内，保持婚纱整洁可联系客服退换。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("婚纱顾问签名：", drawDateFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("顾客签名：", drawDateFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("------------------------------------------------------------------------------------------", drawTitleFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("地址：" + Sharevariables.getUserAddress(), drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("预约电话：" + Sharevariables.getUserTel(), drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("店铺网址：http://iambride.taobao.com  http://iam-missy.taobao.com", drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("官网网址：http://www.iambride.com.cn", drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);

            //如果打印还有下一页，将HasMorePages值置为true;
            e.HasMorePages = false;
        }

        private void comboBoxDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDeliveryType.SelectedIndex == 0)
            {
                labelAddress.Visible = true;
                textBoxAddress.Visible = true;
                labelGetDate.Visible = true;
                labelReturnDate.Visible = true;
                dateTimePickerGetDate.Visible = true;
                dateTimePickerReturnDate.Visible = true;

            }
            else
            {
                labelAddress.Visible = false;
                textBoxAddress.Visible = false;
                textBoxAddress.Text = "";
                labelGetDate.Visible = true;
                labelReturnDate.Visible = true;
                dateTimePickerGetDate.Visible = true;
                dateTimePickerReturnDate.Visible = true;
            }
        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            if (pictureBoxLeft.Image == null)
            {
                return;
            }
            Form sbp = new ShowBigPics(pictureBoxLeft.Image);
            sbp.ShowDialog();
        }

        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            if (pictureBoxRight.Image == null)
            {
                return;
            }
            Form sbp = new ShowBigPics(pictureBoxRight.Image);
            sbp.ShowDialog();
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
                textBoxTotalAmount.Focus();
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
            if (comboBoxDeliveryType.SelectedIndex == 0)
            {
                if (textBoxAddress.Text.Trim() == "")
                {
                    MessageBox.Show("邮寄地址不能为空！");
                    textBoxAddress.Focus();
                    return false;
                }
            }
            //else
            //{
            if (dateTimePickerGetDate.Value.Date >= dateTimePickerReturnDate.Value.Date)
            {
                MessageBox.Show("归还日期必须在取纱日期之后！");
                dateTimePickerReturnDate.Focus();
                return false;
            }
            //}
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
                    if ((comboBoxTypes.ElementAt(textBoxSns.IndexOf(tb)) as ComboBox).SelectedIndex == 0)
                    {
                        int leftCount = ReadData.getCount(order.orderID, tb.Text.Trim(), comboBoxSizes.ElementAt(textBoxSns.IndexOf(tb)).Text, dateTimePickerGetDate.Value, dateTimePickerReturnDate.Value);
                        if (leftCount <= 0)
                        {
                            DataTable dt = ReadData.getDressRentalDuration(order.orderID, tb.Text.Trim(), comboBoxSizes.ElementAt(textBoxSns.IndexOf(tb)).Text, dateTimePickerGetDate.Value, dateTimePickerReturnDate.Value);
                            string message = "";
                            foreach (DataRow row in dt.Rows)
                            {
                                message += row.ItemArray[0].ToString() + "   " + row.ItemArray[1].ToString() + "   " + DateTime.Parse(row.ItemArray[2].ToString()).ToShortDateString() + "---" + DateTime.Parse(row.ItemArray[3].ToString()).ToShortDateString() + "\n";
                            }
                            if (message.Length == 0)
                            {
                                if (DialogResult.No == MessageBox.Show("没有库存，是否继续?", "", MessageBoxButtons.YesNo))
                                {
                                    tb.Focus();
                                    tb.SelectAll();
                                    return false;
                                }
                            }
                            else
                            {
                                if (DialogResult.No == MessageBox.Show("与以下租赁时间冲突\n" + message + "\n是否继续?", "", MessageBoxButtons.YesNo))
                                {
                                    tb.Focus();
                                    tb.SelectAll();
                                    return false;
                                }
                            }
                        }
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
                    list.ElementAt(i).Top -= 21;
                }
            }
            if (controls.ElementAt(0).Count == 0)
            {
                generateOrderRow(33);
            }
        }

        private void textBoxSn_Leave(object sender, EventArgs e)
        {
            int index = textBoxSns.IndexOf(sender as TextBox);
            if (textBoxPrices.ElementAt(index).Text.Trim() == "")
            {
                if ((sender as TextBox).Text != "")
                {
                    DataTable properties = ReadData.getPropertiesByWdId((sender as TextBox).Text);
                    if (properties.Rows.Count == 0)
                    {
                        MessageBox.Show("未找到此货号！");
                        (sender as TextBox).SelectAll();
                        (sender as TextBox).Focus();
                        return;
                    }
                    //if (sizes.Count == 0)
                    //{
                    //    MessageBox.Show("货号 " + (sender as TextBox).Text + " 断货");
                    //    (sender as TextBox).Text = "";
                    //    (sender as TextBox).Focus();
                    //    return;
                    //}
                    (comboBoxSizes.ElementAt(index) as ComboBox).Items.AddRange(properties.AsEnumerable().Select(r => r.Field<string>("wd_size")).ToArray());
                    (comboBoxSizes.ElementAt(index) as ComboBox).SelectedIndex = 0;
                    textBoxPrices.ElementAt(index).Text = properties.Rows[0].ItemArray[1].ToString();
                    (comboBoxColors.ElementAt(index) as ComboBox).DataSource = ReadData.getColorsByWdId((sender as TextBox).Text);
                    (comboBoxTypes.ElementAt(index) as ComboBox).SelectedIndex = 0;
                }
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
            textBoxSn.Leave += new System.EventHandler(textBoxSn_Leave);
            textBoxSns.Add(textBoxSn);
            textBoxSn.Focus();
            // 
            // comboBoxSize
            // 
            ComboBox comboBoxSize = new ComboBox();
            comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxSize.FormattingEnabled = true;
            comboBoxSize.Location = new System.Drawing.Point(84, top);
            comboBoxSize.Margin = new System.Windows.Forms.Padding(0);
            comboBoxSize.Size = new System.Drawing.Size(80, 20);
            comboBoxSize.TabIndex = 7;
            panelList.Controls.Add(comboBoxSize);
            comboBoxSizes.Add(comboBoxSize);
            // 
            // comboBoxType
            // 
            ComboBox comboBoxType = new ComboBox();
            comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new System.Drawing.Point(224, top);
            comboBoxType.Margin = new System.Windows.Forms.Padding(0);
            comboBoxType.Size = new System.Drawing.Size(80, 20);
            comboBoxType.Items.AddRange(standardTypes);
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
