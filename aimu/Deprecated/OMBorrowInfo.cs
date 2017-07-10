using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;//添加命名空间


namespace aimu
{
    public partial class OMBorrowInfo : Form
    {
        Customer ct = new Customer();
        Order coPre = new Order();
        List<OrderDetail> coDetailsList = new List<OrderDetail>();//客户订单详情

       

        static string printTitlePre = "IAM艾慕婚纱礼服租赁";
        string printTitle= printTitlePre + "订单凭证";
        Boolean isOrder = true;


        public OMBorrowInfo()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CMQueryCustormer
            Sharevariables.setCustomerID("");
            Sharevariables.setCustomerName("");
            //Form nc = new CMCurrentCustomerBookList(true);
            Form nc = new CustomerQuery(true);

            nc.ShowDialog();
            this.tbBrideID.Text = Sharevariables.getCustomerID();


            if (tbBrideID.Text == "")
            {
                MessageBox.Show("请输入用户编号进行查询！");
                return;

            }
            fillDataForBorrowInfo();//


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.tbAddress.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.tbAddress.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int index = dataGridView2.Rows.Add(r.Clone() as DataGridViewRow);
                foreach (DataGridViewCell o in r.Cells)
                {
                    dataGridView2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }

            tabControl1.SelectTab(2);

            //计算订单
            button8_Click(sender, e);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (lvTryDressList.SelectedItems.Count>0)
            {
                lvTryDressList.SelectedItems[0].Remove();
            }*/

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (tbBrideID.Text == "")
            {
                MessageBox.Show("请输入用户编号进行查询！");
                return;

            }
            fillDataForBorrowInfo();

        }





        private void fillTryDressList()
        {

            DataTable dt = ReadData.fillDataTableForTryDress(tbBrideID.Text);

            dataGridView1.DataSource = dt;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add(c.Clone() as DataGridViewColumn);
            }


        }


        private void fillDataForBorrowInfo()
        {
            ct = ReadData.getCustomersByID(tbBrideID.Text);
            fillTryDressList();//fillout tryDress list 试穿列表

            if (ct.brideName != null)
            {

                this.tbBrideName.Text = ct.brideName;
                this.tbBrideContact.Text = ct.brideContact;
                this.cbTryDress.Text = ct.tryDress;
                this.dtpMarryDate.Text = ct.marryDay;
                this.dtpReserveDate.Text = ct.reserveDate;
                this.dtReserveTime.Text = ct.reserveTime;
                this.tb_scsj_jsg.Text = ct.scsj_jsg;
                this.tb_scsj_cxsg.Text = ct.scsj_cxsg;
                this.tb_scsj_tz.Text = ct.scsj_tz;
                this.tb_scsj_xw.Text = ct.scsj_xw;
                this.tb_scsj_xxw.Text = ct.scsj_xxw;
                this.tb_scsj_yw.Text = ct.scsj_yw;
                this.tb_scsj_dqw.Text = ct.scsj_dqw;
                this.tb_scsj_tw.Text = ct.scsj_tw;
                this.tb_scsj_jk.Text = ct.scsj_jk;
                this.tb_scsj_jw.Text = ct.scsj_jw;
                this.tb_scsj_dbw.Text = ct.scsj_dbw;
                this.tb_scsj_yddc.Text = ct.scsj_yddc;
                this.tb_scsj_qyj.Text = ct.scsj_qyj;
                this.tb_scsj_bpjl.Text = ct.scsj_bpjl;
                this.tbJDGW.Text = ct.jdgw;

            }
            else
            {
                MessageBox.Show("没查到此客户！");

                this.tbBrideName.Text = "";
                this.tbBrideContact.Text = "";
                this.cbTryDress.Text = "";
                this.dtpMarryDate.Text = "";
                this.dtpReserveDate.Text = "";
                this.dtReserveTime.Text = "";
                this.tb_scsj_jsg.Text = "";
                this.tb_scsj_cxsg.Text = "";
                this.tb_scsj_tz.Text = "";
                this.tb_scsj_xw.Text = "";
                this.tb_scsj_xxw.Text = "";
                this.tb_scsj_yw.Text = "";
                this.tb_scsj_dqw.Text = "";
                this.tb_scsj_tw.Text = "";
                this.tb_scsj_jk.Text = "";
                this.tb_scsj_jw.Text = "";
                this.tb_scsj_dbw.Text = "";
                this.tb_scsj_yddc.Text = "";
                this.tb_scsj_qyj.Text = "";
                this.tb_scsj_bpjl.Text = "";
                this.tbJDGW.Text = "";
            }
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        //打印
        private void button6_Click(object sender, EventArgs e)
        {
            if (printVerify())
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
                    printDocument1.PrinterSettings.Copies = printDialog1.PrinterSettings.Copies;

                    try
                    {
                       
                        printDocument1.Print();
                    }
                    catch (InvalidPrinterException)
                    {
                        MessageBox.Show("打印机未就绪！");
                    }
                    finally
                    {
                        printDocument1.Dispose();
                    }
                }
                

            }
        }

        private Boolean saveCustomerOrder(Order co)
        {
            try
            {
                SaveData.InsertCustomerOrder(co);
                return true;
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
                return false;
            }
            
        }

        private Boolean saveCustomerOrderDetails(List<OrderDetail> coDetailsList)
        {
            try
            {
                SaveData.InsertCustomerOrderDetails(coDetailsList);
                return true;
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
                return false;
            }

        }


        //打印校验
        private Boolean printVerify()
        {
            if (tbBrideID.Text.Trim() == "")
            {
                MessageBox.Show("请先选择用户！");
                return false;
            }

            if (radioButton2.Checked)
            {
                if (tbAddress.Text.Trim() == "")
                {
                    MessageBox.Show("如果选择快寄婚纱，则快寄地址必填！");
                    return false;
                }

            }
            return true;

        }

        private void OMBorrowInfo_Load(object sender, EventArgs e)
        {
            this.tbBrideID.Text = Sharevariables.getCustomerID();
            this.tbJDGW.Text = Sharevariables.getLoginOperatorName();
            if (tbBrideID.Text.Trim() != "")
            {
                button4_Click(sender, e);
            }
        }

        private void lvWeddingDressStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //printTitle = printTitlePre+ "订单凭证";

            Font drawTitleFont = new Font("Arial", 10);
            Font drawContentFont = new Font("Arial", 8);
            Font drawDateFont = new Font("Arial", 8);
            Font drawWarningFont = new Font("Arial", 6);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);

            //Body 
            float startBody = 35f;
            float stepBody = 20f;
            float stepBodySmall = 15f;
            int iNum = 0;
            int iNumHSLF = 1;
            float WKDJJE = 0.0f;//尾款待交金额

            e.Graphics.DrawString("订单编号:" + ct.customerID, drawContentFont, drawBrush, 25f, 10f);//打印编号
            e.Graphics.DrawString(printTitle, drawTitleFont, drawBrush, 265f, 10f);//打印标题
            e.Graphics.DrawString("打印日期:" + DateTime.Now.ToLongDateString(), drawDateFont, drawBrush, 590f, 5f);//打印日期
            e.Graphics.DrawString("接待顾问：" + tbJDGW.Text.Trim(), drawDateFont, drawBrush, 590f, 20f);//打印接待顾问


            string printBrideLine = string.Format("{0,-20}", "新娘姓名：" + ct.brideName) + string.Format("{0,-20}", "新娘电话：" + ct.brideContact) + string.Format("{0,-20}", "新郎姓名：" + ct.groomName) + string.Format("{0,-20}", "新郎电话：" + ct.groomContact);
            string printTaoBao = string.Format("{0,-20}", "客户渠道：" + ct.infoChannel) + string.Format("{0,-20}", "旺旺ID:" + ct.wangwangID) + string.Format("{0,-20}", "成交日期：" + DateTime.Now.Date.ToString("yyyy-MM-dd"));

            string qv= this.radioButton1.Checked ? "到店" : "快递";
            string huan = this.radioButton4.Checked ? "到店" : "快递";


            string printWeddingDayLine = string.Format("{0,-20}", "婚期：" + dtpMarryDate.Value.ToString("yyyy-MM-dd")) + string.Format("{0,-30}", "取纱方式:"+ qv + " 日期："+ dateTimePicker3.Value.ToString("yyyy-MM-dd")) + string.Format("{0,-30}", "还纱方式:"+ huan + " 日期：" + dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            string printPostAddress = string.Format("{0,-100}", "邮寄地址：" + tbAddress.Text.Trim());
            string printMemo = string.Format("{0,-100}", "备注:" + textBoxMemo.Text.Trim());

            //35f
            e.Graphics.DrawString("_____________________________________________________________________________________________________________________________________________", drawTitleFont, drawBrush, 25f, startBody + (iNum++) * stepBody - 5);
            e.Graphics.DrawString(printBrideLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printTaoBao, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printWeddingDayLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printPostAddress, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printMemo, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);

            //身材数据 155f            
            e.Graphics.DrawString("身材数据:", drawContentFont, drawBrush, 25f, 155f);
            e.Graphics.DrawString("净身高：" + tb_scsj_jsg.Text.Trim() + "cm  穿鞋身高：" + tb_scsj_cxsg.Text.Trim() + "cm  体重：" + tb_scsj_tz.Text.Trim() + "kg  胸围：" + tb_scsj_xw.Text.Trim() + "cm  下胸围：" + tb_scsj_xxw.Text.Trim() + "cm  腰围：" + tb_scsj_yw.Text.Trim() + "cm  肚脐围：" + tb_scsj_dqw.Text.Trim() + "cm  ", drawDateFont, drawBrush, 45f, 155f + 1 * stepBodySmall);
            e.Graphics.DrawString("臀围：" + tb_scsj_tw.Text.Trim() + "cm  肩宽：" + tb_scsj_jk.Text.Trim() + "cm  颈围：" + tb_scsj_jw.Text.Trim() + "cm  大臀围：" + tb_scsj_dbw.Text.Trim() + "cm  腰到底长：" + tb_scsj_yddc.Text.Trim() + "cm  前腰结：" + tb_scsj_qyj.Text.Trim() + "cm  BP距离：" + tb_scsj_bpjl.Text.Trim() + "cm", drawDateFont, drawBrush, 45f, 155f + 2 * stepBodySmall);

            //婚纱商品数据  205f
            //string printContent = "1490    婚纱    白纱    XL    白色   ￥1390";

            e.Graphics.DrawString("婚纱商品数据:", drawContentFont, drawBrush, 25f, 205f);
            e.Graphics.DrawString("编号    大类    小类    尺码    颜色    价格", drawDateFont, drawBrush, 45f, 205f + stepBody);

            dataGridView2.Refresh();
            string orderData = "";
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                string printContent = "";
                for (int ij = 0; ij < r.Cells.Count; ij++)
                {
                    try
                    {
                        printContent += r.Cells[ij].Value.ToString() + "    ";
                    }
                    catch (Exception ef)
                    {
                        //MessageBox.Show(ef.ToString());
                        printContent += "";
                    }
                }
                orderData += printContent+"~";
                e.Graphics.DrawString(printContent, drawDateFont, drawBrush, 45f, 205f + stepBody + (iNumHSLF++) * stepBodySmall);
            }



            //订单金额 340f
            //e.Graphics.DrawString("订单金额:", drawContentFont, drawBrush, 45f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString("订单金额(折扣前):￥" + tbOrderAmount.Text.Trim() + "    付款类型：" + comboBox1.Text + "    付款方式：" + comboBox2.Text + "    折扣系数：" + tbDiscount.Text + "    实付金额(折扣后)：￥" + tbResultAmount.Text + "    定金金额：￥" + textBox1.Text, drawDateFont, drawBrush, 25f, 320f);

            float f_num_total = 0.0f;
            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;
                float tbReservedMoneyTmp = 0.0f;
                float tbDepositTmp = 0.0f;


                float aa = 0.0f;//婚纱定价
                float bb = 0.0f;//折扣系数
                float cc = 0.0f;//已交定金数
                float dd = 0.0f;//已交押金数
                float ee = 0.0f;//已交全款数

                if (float.TryParse(tbResultAmount.Text.Trim(), out tbResultAmountTmp))
                {
                    f_num_total += tbResultAmountTmp;
                }

                if (float.TryParse(textBox1.Text.Trim(), out tbReservedMoneyTmp))
                {
                    f_num_total += tbReservedMoneyTmp;
                }

                if (float.TryParse(tbDeposit.Text.Trim(), out tbDepositTmp))
                {
                    f_num_total += tbDepositTmp;
                }


                //float.TryParse(tbOrderAmount.Text.Trim(),out aa);//婚纱定价
                //float.TryParse(tbDiscount.Text.Trim(), out bb);//折扣系数
                //float.TryParse(textBox1.Text.Trim(), out cc);//已交定金数
                //float.TryParse(tbDeposit.Text.Trim(), out dd);//已交押金数
                //float.TryParse(tbResultAmount.Text.Trim(), out ee);//已交全款数
   
                //WKDJJE =   (aa+ aa * bb) -  (cc + dd + ee);


            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误"+ef.Message);
            }
            e.Graphics.DrawString("押金金额:￥" + tbDeposit.Text + "     押金付款方式：" + comboBox3.Text+ "        合计已交金额： ￥" + f_num_total.ToString(), drawDateFont, drawBrush, 25f, 320f + stepBody - 5);


            //warning  370f
            float startWarning = 350f;
            float stepWarning = 15;
            int jNum = 0;
            e.Graphics.DrawString("温馨提示:", drawDateFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("1.租期说明：店内商品租金为租赁3天的价格，若使用时间超过3天，按照租金*20%/日额外加收；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("2.租赁流程：订单签署当日支付订单租金全额为定金，我们将确保您在租期内的产品库存和品质；婚纱使用前1周新娘需到店测量尺寸，以保证我们为您提供合身的产品；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("                       婚纱使用前1天到店取订单内全部产品，并付清押金（除定金外产品出售总价）；订单内产品退还当日，退还押金；由于客人个人原因取消婚期，定金不退还。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("3.押金说明：押金为保证店内产品正常使用并退还。退还时，如出现不可修复的产品污损，根据情况，将扣除产品售价的5%-100%为赔偿金；若产品未退还，押金不退；", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("4.婚纱使用提示：结婚当天新娘尽量避免接触红酒、彩条喷雾、冷烟花等容易对婚纱造成无法修复伤害的物品，避免婚纱污损带来的现场尴尬及经济损失。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("5.关于退单的说明：在支付定金后的三天内申请退单，收取定金额度的20 % 做为违约金；在支付定金后的七天内申请退单，收取定金额度的50 % 做为违约金；超过七天退单的，定金不可退。", drawWarningFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            

            e.Graphics.DrawString("婚纱顾问签名：", drawDateFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("顾客签名：", drawDateFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------", drawTitleFont, drawBrush, 25f, startWarning + (jNum++) * stepWarning);

            e.Graphics.DrawString("地址：" + Sharevariables.getUserAddress(), drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("预约电话：" + Sharevariables.getUserTel(), drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);
            e.Graphics.DrawString("店铺网址：http://iambride.taobao.com  http://iam-missy.taobao.com", drawWarningFont, drawBrush, 25f, startWarning + (jNum) * stepWarning);
            e.Graphics.DrawString("官网网址：http://www.iambride.com.cn", drawWarningFont, drawBrush, 500f, startWarning + (jNum++) * stepWarning);




            //如果打印还有下一页，将HasMorePages值置为true;
            e.HasMorePages = false;
            

        }



        private void fillOrder()
        {
            string orderData = "";
           
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {

                OrderDetail coDetails = new OrderDetail();
                coDetails.orderID = coPre.orderID;

                string printContent = "";

                for (int ij = 0; ij < r.Cells.Count; ij++)
                {
                    try
                    {
                        printContent += r.Cells[ij].Value.ToString() + "    ";

                        if (ij==0)
                        {
                            coDetails.wd_id = r.Cells[ij].Value.ToString();
                        }

                        if (ij == 1)
                        {
                            coDetails.wd_big_category = r.Cells[ij].Value.ToString();
                        }

                        if (ij == 2)
                        {
                            coDetails.wd_litter_category = r.Cells[ij].Value.ToString();
                        }

                        if (ij == 3)
                        {
                            coDetails.wd_size = r.Cells[ij].Value.ToString();
                        }

                        

                    }
                    catch (Exception ef)
                    {
                        printContent += "";
                    }
                }

                coDetailsList.Add(coDetails);

                orderData += printContent + "~";
             }

            float f_num_total = 0.0f;
            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;
                float tbReservedMoneyTmp = 0.0f;
                float tbDepositTmp = 0.0f;

                if (float.TryParse(tbResultAmount.Text.Trim(), out tbResultAmountTmp))
                {
                    f_num_total += tbResultAmountTmp;
                }

                if (float.TryParse(textBox1.Text.Trim(), out tbReservedMoneyTmp))
                {
                    f_num_total += tbReservedMoneyTmp;
                }

                if (float.TryParse(tbDeposit.Text.Trim(), out tbDepositTmp))
                {
                    f_num_total += tbDepositTmp;
                }


            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误");
            }


            //save to customerOrderTable
            coPre.orderID = Common.generateId();
            coPre.customerID = ct.customerID;
            coPre.wdData = orderData.Trim();
            coPre.orderAmountPre = tbOrderAmount.Text.Trim();
            coPre.orderAmountafter = tbResultAmount.Text.Trim();
            coPre.orderDiscountRate = tbDiscount.Text.Trim();
            coPre.orderPaymentMethod = comboBox2.Text.Trim();
            coPre.reservedAmount = textBox1.Text.Trim();//定金金额
            coPre.depositAmount = tbDeposit.Text.Trim();//订单押金金额
            coPre.depositPaymentMethod = comboBox3.Text.Trim();
            coPre.totalAmount = f_num_total.ToString();
            coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            coPre.orderStatus = "门店已提交订单";//0 订单进行中，1结束订单  需要在归还页面里设置为1
            coPre.orderType = isOrder ? "租赁订单" : "租赁定金"; ;   //0 定金类型，1订单类型            
            coPre.receptionConsultant = tbJDGW.Text.Trim();
            coPre.memo = textBoxMemo.Text.Trim();
            coPre.address = tbAddress.Text.Trim();

            foreach (OrderDetail coDetails in coDetailsList)
            {
                coDetails.orderID = coPre.orderID;//赋值订单详情ID
                coDetails.memo = coPre.customerID;//临时存一下客户ID
            }


            float wkdfje = 0.0f;
            float.TryParse(textBox2.Text.Trim(), out wkdfje);
            if (wkdfje>0)
            {
                coPre.ifarrears = "尾款尚未结清";
            }

            if (wkdfje <= 0)
            {
                coPre.ifarrears = "尾款已结清";
            }

        }


        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //fillDataForBorrowInfo();
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();


               
                //测试订单存储
                //MessageBox.Show("测试订单存储，实际运行过程中应该是打印存储订单，不是预览存储！");
                //saveCustomerOrder(coPre);
         
            }
            catch (Exception ef)
            {
                MessageBox.Show("请先从试穿列表里选择婚纱商品！"+ ef.ToString());
            }
    }

        //计算
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                float totalAmount = 0.0f;
                if (tbOrderAmount.Text.Trim().Length == 0)
                {
                    foreach (DataGridViewRow r in dataGridView2.Rows)
                    {
                        totalAmount += float.Parse(r.Cells[5].Value.ToString());
                    }
                    tbOrderAmount.Text = totalAmount.ToString();
                   // float b = (totalAmount);//押金金额
                    textBox4.Text = totalAmount.ToString();
                }
                else
                {
                    totalAmount = float.Parse(tbOrderAmount.Text.Trim());
                }
               // float a =totalAmount * float.Parse(tbDiscount.Text.Trim());//租赁订单金额
               // tbResultAmount.Text =  a.ToString();
               
                //尾款
                float WKDJJE = 0.0f;//尾款待交金额
                float aa = 0.0f;//婚纱定价
                float bb = 0.0f;//折扣系数
                float cc = 0.0f;//已交定金数
                float dd = 0.0f;//已交押金数
                float ee = 0.0f;//已交全款数

                float.TryParse(tbOrderAmount.Text.Trim(), out aa);//婚纱定价
                float.TryParse("-"+tbDiscount.Text.Trim(), out bb);//折扣系数
                float.TryParse(textBox1.Text.Trim(), out cc);//已交定金数
                float.TryParse(tbDeposit.Text.Trim(), out dd);//已交押金数
                float.TryParse(tbResultAmount.Text.Trim(), out ee);//已交全款数

                WKDJJE = (aa + aa * bb) - (cc + dd + ee);
                textBox2.Text = WKDJJE.ToString();


                textBox3.Text = (aa + aa * bb).ToString();

            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form formOutput = new DressList();
            formOutput.ShowDialog();
            OMBorrowInfo_Load(sender,e);
            fillDataForBorrowInfo();//刷新
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim()=="全款")
            {
                tbResultAmount.Enabled = true;
                textBox1.Enabled = false;
                textBox1.Text = "0";
                isOrder = true;
                printTitle = printTitlePre + "订单凭证";

                button8_Click(sender,e);

            }

            if (comboBox1.Text.Trim() == "定金")
            {
                tbResultAmount.Enabled = false;
                tbResultAmount.Text = "0";
                tbDeposit.Text = "0";
                textBox1.Enabled = true;
                textBox1.Text = "200";
                isOrder = false;
                printTitle = printTitlePre + "定金凭证";

            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                button8_Click(sender,e);//计算一遍
                fillOrder();

                float wkdfje = 0.0f;
                float.TryParse(textBox2.Text.Trim(), out wkdfje);
                if (wkdfje > 0)
                {
                    coPre.ifarrears = wkdfje.ToString();
                    MessageBox.Show("客户: "+ tbBrideName.Text.Trim() + " 的订单尾款尚未结清，还差：￥"+ wkdfje);
                }

                if (wkdfje <= 0)
                {
                    coPre.ifarrears = wkdfje.ToString();
                }



                DialogResult dialogResult = MessageBox.Show("已确认该订单生效吗？", "退出", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    saveCustomerOrder(coPre);
                    saveCustomerOrderDetails(coDetailsList);
                    UpdateDate.updateCustomerStatus(coPre.customerID, "C"); //C：提交订单的客户，将客户状态置为C类客户
                    button6.Enabled = true;//打印按钮打开
                    button10.Enabled = false;//加入按钮关闭
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    tbDiscount.Enabled = false;
                    comboBox3.Enabled = false;
                    textBox1.Enabled = false;
                    tbResultAmount.Enabled = false;
                    tbDeposit.Enabled = false;

                    MessageBox.Show("该客户订单已生效！");
                    
                }
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }
    }
}
