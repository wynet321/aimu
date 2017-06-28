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
    public partial class OMTailored : Form
    {
        public OMTailored()
        {
            InitializeComponent();
            coPre.orderID = OrderNumberBuilder.NextBillNumber();
        }

        Customer ct = new Customer();
        Order coPre = new Order();

        static string printTitlePre = "IAM艾慕婚纱商品量身定制";
        string printTitle = printTitlePre + "订单凭证";
        //Boolean isOrder = true;

        string orderData = "";
        float f_num_total = 0.0f;
        //计算合计金额


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
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }

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
                try
                {
                    //加长费：身高大于173小于等于180，加150￥；大于180，加300￥
                    int cxsgInt = int.Parse(ct.scsj_cxsg);
                    if (cxsgInt > 172 && cxsgInt <= 179)
                    {
                        textBox3.Text = "150";
                    }
                    if (cxsgInt >= 180)
                    {
                        textBox3.Text = "300";
                    }


                    int ywInt = int.Parse(ct.scsj_yw);
                    if (ywInt >= 80 && ywInt < 90)
                    {
                        textBox4.Text = "150";
                    }
                    if (ywInt >= 90)
                    {
                        textBox4.Text = "300";
                    }
                }
                catch (Exception ef)
                {

                }


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

                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.comboBox3.Text = "";
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
                        saveCustomerOrder(coPre);
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
                SaveData.InsertCustomerOrderFull(co);
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
            tbBrideID.Text = Sharevariables.getCustomerID();
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
            orderData = "";

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

            e.Graphics.DrawString("订单编号:" + ct.customerID, drawContentFont, drawBrush, 25f, 10f);//打印编号
            e.Graphics.DrawString(printTitle, drawTitleFont, drawBrush, 250f, 10f);//打印标题
            e.Graphics.DrawString("打印日期:" + DateTime.Now.ToLongDateString(), drawDateFont, drawBrush, 590f, 5f);//打印日期
            e.Graphics.DrawString("接待顾问：" + tbJDGW.Text.Trim(), drawDateFont, drawBrush, 590f, 20f);//打印接待顾问


            string printBrideLine = string.Format("{0,-20}", "新娘姓名：" + ct.brideName) + string.Format("{0,-20}", "新娘电话：" + ct.brideContact) + string.Format("{0,-20}", "新郎姓名：" + ct.groomName) + string.Format("{0,-20}", "新郎电话：" + ct.groomContact);
            string printTaoBao = string.Format("{0,-20}", "客户渠道：" + ct.infoChannel) + string.Format("{0,-20}", "旺旺ID:" + ct.wangwangID) + string.Format("{0,-20}", "成交日期：" + DateTime.Now.Date.ToString("yyyy-MM-dd"));

            string qv = this.radioButton1.Checked ? "到店" : "快递";
            //string huan = this.radioButton4.Checked ? "到店" : "快递";


            string printWeddingDayLine = string.Format("{0,-20}", "婚期：" + dtpMarryDate.Value.ToString("yyyy-MM-dd")) + string.Format("{0,-30}", "取纱方式:" + qv + " 日期："+ dateTimePicker3.Value.ToString("yyyy-MM-dd")) ;
            string printPostAddress = string.Format("{0,-100}", "邮寄地址：" + tbAddress.Text.Trim());

            //35f
            e.Graphics.DrawString("_____________________________________________________________________________________________________________________________________________", drawTitleFont, drawBrush, 25f, startBody + (iNum++) * stepBody - 5);
            e.Graphics.DrawString(printBrideLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printTaoBao, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printWeddingDayLine, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString(printPostAddress, drawContentFont, drawBrush, 25f, startBody + (iNum++) * stepBody);

            //身材数据 135f            
            e.Graphics.DrawString("身材数据:", drawContentFont, drawBrush, 25f, 135f);
            e.Graphics.DrawString("净身高：" + tb_scsj_jsg.Text.Trim() + "cm  穿鞋身高：" + tb_scsj_cxsg.Text.Trim() + "cm  体重：" + tb_scsj_tz.Text.Trim() + "kg  胸围：" + tb_scsj_xw.Text.Trim() + "cm  下胸围：" + tb_scsj_xxw.Text.Trim() + "cm  腰围：" + tb_scsj_yw.Text.Trim() + "cm  肚脐围：" + tb_scsj_dqw.Text.Trim() + "cm  ", drawDateFont, drawBrush, 45f, 135f + 1 * stepBodySmall);
            e.Graphics.DrawString("臀围：" + tb_scsj_tw.Text.Trim() + "cm  肩宽：" + tb_scsj_jk.Text.Trim() + "cm  颈围：" + tb_scsj_jw.Text.Trim() + "cm  大臀围：" + tb_scsj_dbw.Text.Trim() + "cm  腰到底长：" + tb_scsj_yddc.Text.Trim() + "cm  前腰结：" + tb_scsj_qyj.Text.Trim() + "cm  BP距离：" + tb_scsj_bpjl.Text.Trim() + "cm", drawDateFont, drawBrush, 45f, 135f + 2 * stepBodySmall);

            //婚纱商品数据  185f
            //string printContent = "1490    婚纱    白纱    XL    白色   ￥1390";

            e.Graphics.DrawString("婚纱商品数据:", drawContentFont, drawBrush, 25f, 185f);
            e.Graphics.DrawString("编号    大类    小类    尺码    颜色    价格", drawDateFont, drawBrush, 45f, 185f + stepBody);

            dataGridView2.Refresh();

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
                orderData += printContent + "~";
                e.Graphics.DrawString(printContent, drawDateFont, drawBrush, 45f, 185f + stepBody + (iNumHSLF++) * stepBodySmall);
            }


            //订单金额 340f
            //e.Graphics.DrawString("订单金额:", drawContentFont, drawBrush, 45f, startBody + (iNum++) * stepBody);
            e.Graphics.DrawString("订单金额(折扣前):￥" + tbOrderAmount.Text.Trim() + "    付款类型：" + comboBox1.Text + "    付款方式：" + comboBox2.Text + "    折扣系数：" + tbDiscount.Text + "    实付金额(折扣后)：￥" + tbResultAmount.Text , drawDateFont, drawBrush, 25f, 310f);

           
            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;


                if (float.TryParse(tbResultAmount.Text.Trim(), out tbResultAmountTmp))
                {
                    f_num_total = tbResultAmountTmp;
                }

               

            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误");
            }
            e.Graphics.DrawString("合计金额： ￥" + f_num_total.ToString()+ "，其中包括工费：" + textBox1.Text + " ,加急费：" + textBox5.Text + " ,加长费：" + textBox3.Text + " ,加宽费：" + textBox4.Text, drawDateFont, drawBrush, 25f, 310f + stepBody - 5);
            //                  
            //e.Graphics.DrawString(, drawDateFont, drawBrush, 25f, 340f + stepBody - 5);


            //warning  370f
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
            coPre.customerID = ct.customerID;
            coPre.wdData = orderData.Trim();
            coPre.orderAmountPre = tbOrderAmount.Text.Trim();
            coPre.orderAmountafter = tbResultAmount.Text.Trim();
            coPre.orderDiscountRate = tbDiscount.Text.Trim();
            coPre.orderPaymentMethod = comboBox2.Text.Trim();
            coPre.reservedAmount = "";// textBox1.Text.Trim();//定金金额
            coPre.depositAmount = "";// tbDeposit.Text.Trim();//订单押金金额
            coPre.depositPaymentMethod = "";// comboBox3.Text.Trim();
            coPre.totalAmount = f_num_total.ToString();
            coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            coPre.orderStatus = "0";//0 订单进行中，1结束订单  需要在归还页面里设置为1
            coPre.orderType = "量身定制订单";  //0 定金类型，1租赁订单类型 ，2量身定制订单，3量身定制，4来图定制            
            coPre.receptionConsultant = tbJDGW.Text.Trim();


            coPre.shenpiren = comboBox3.Text;
            coPre.gongfei = textBox1.Text;
            coPre.jiajifei = textBox5.Text;
            coPre.jiachangfei = textBox3.Text;
            coPre.jiakuanfei = textBox4.Text;

        }

        private void setCoPre()
        {
            orderData = "";
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
                orderData += printContent + "~";
            }


            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;


                if (float.TryParse(tbResultAmount.Text.Trim(), out tbResultAmountTmp))
                {
                    f_num_total = tbResultAmountTmp;
                }

               


            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误");
            }

            coPre.customerID = ct.customerID;
            coPre.wdData = orderData.Trim();
            coPre.orderAmountPre = tbOrderAmount.Text.Trim();
            coPre.orderAmountafter = tbResultAmount.Text.Trim();
            coPre.orderDiscountRate = tbDiscount.Text.Trim();
            coPre.orderPaymentMethod = comboBox2.Text.Trim();
            coPre.reservedAmount = "";// textBox1.Text.Trim();//定金金额
            coPre.depositAmount = "";// tbDeposit.Text.Trim();//订单押金金额
            coPre.depositPaymentMethod = "";// comboBox3.Text.Trim();
            coPre.totalAmount = f_num_total.ToString();
            coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            coPre.orderStatus = "0";//0 订单进行中，1结束订单  需要在归还页面里设置为1
            coPre.orderType = "量身定制订单";    //0 定金类型，1租赁订单类型 ，2量身定制订单，3量身定制，4来图定制           
            coPre.receptionConsultant = tbJDGW.Text.Trim();


            coPre.shenpiren = comboBox3.Text;
            coPre.gongfei = textBox1.Text;
            coPre.jiajifei = textBox5.Text;
            coPre.jiachangfei = textBox3.Text;
            coPre.jiakuanfei = textBox4.Text;


            

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
                MessageBox.Show("请先从试穿列表里选择婚纱商品！" + ef.ToString());
            }
        }

        //计算
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                float totalAmount = 0.0f;
                foreach (DataGridViewRow r in dataGridView2.Rows)
                {
                    totalAmount += float.Parse(r.Cells[5].Value.ToString());
                }
                tbOrderAmount.Text = totalAmount.ToString();

                float a = totalAmount * float.Parse(tbDiscount.Text.Trim());//量身定制订单金额
                float gf = float.Parse(textBox1.Text.Trim());//工费500
                float jjf = float.Parse(textBox5.Text.Trim()); //加急费
                float jcf = float.Parse(textBox3.Text.Trim());//加长费
                float jkf = float.Parse(textBox4.Text.Trim());//加宽费

                tbResultAmount.Text = (a + gf+ jjf+ jcf+ jkf).ToString();


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
            OMBorrowInfo_Load(sender, e);
            fillDataForBorrowInfo();//刷新
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "全款")
            {
                tbResultAmount.Enabled = true;
               // textBox1.Enabled = false;
               // textBox1.Text = "0";
                //isOrder = true;
                printTitle = printTitlePre + "订单凭证";

            }

            if (comboBox1.Text.Trim() == "定金")
            {
                tbResultAmount.Enabled = false;
                tbResultAmount.Text = "0";
               // tbDeposit.Text = "0";
              //  textBox1.Enabled = true;
               // textBox1.Text = "200";
                //isOrder = false;
                printTitle = printTitlePre + "定金凭证";

            }

        }

        private void OMStandardCode_Load(object sender, EventArgs e)
        {
            tbBrideID.Text = Sharevariables.getCustomerID();
            if (tbBrideID.Text.Trim() != "")
            {
                button4_Click(sender, e);
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                button8_Click(sender, e);//调用计算

                if ((float.Parse(tbDiscount.Text.Trim())) < 0.8 && comboBox3.Text == "")
                {
                    MessageBox.Show("请输入审批人！");
                    return;
                }

                if (dataGridView2.Rows.Count > 0)
                {
                    setCoPre();
                    saveCustomerOrder(coPre);

                    this.button10.Enabled = false;
                    this.comboBox1.Enabled = false;
                    this.comboBox2.Enabled = false;
                    this.tbOrderAmount.Enabled = false;
                    this.tbDiscount.Enabled = false;
                    this.tbResultAmount.Enabled = false;
                    //this.button8.Enabled = false;
                    this.comboBox3.Enabled = false;

                    this.button7.Enabled = true;
                    this.button6.Enabled = true;
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("订单为空，不能保存！");
                }


            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }

        private void OMTailored_Load(object sender, EventArgs e)
        {
            this.tbBrideID.Text = Sharevariables.getCustomerID();
            this.tbJDGW.Text = Sharevariables.getLoginOperatorName();
            if (tbBrideID.Text.Trim() != "")
            {
                button4_Click(sender, e);
            }
        }

        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            this.tbAddress.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text.Trim())<50)
            {
                textBox5.Text = "200";
            }

            if (int.Parse(textBox2.Text.Trim()) >= 50)
            {
                textBox5.Text = "0";
            }

            button8_Click(sender,e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }
    }
}
