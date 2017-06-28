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
using System.IO;


namespace aimu
{
    public partial class OMGivePicCustomization : Form
    {
        public OMGivePicCustomization()
        {
            InitializeComponent();
            coPre.orderID = OrderNumberBuilder.NextBillNumber();
            //来图定制
            cleanPicPath();
        }

        Customer ct = new Customer();
        Order coPre = new Order();

        static string printTitlePre = "IAM艾慕婚纱商品来图定制";
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
           /* foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int index = dataGridView2.Rows.Add(r.Clone() as DataGridViewRow);
                foreach (DataGridViewCell o in r.Cells)
                {
                    dataGridView2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }
            */
            tabControl1.SelectTab(2);

            //计算订单
            button8_Click(sender, e);

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

            /*dataGridView1.DataSource = dt;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add(c.Clone() as DataGridViewColumn);
            }*/


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


                //this.comboBox3.Text = "";
            }
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


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //printTitle = printTitlePre+ "订单凭证";
            orderData = "";

            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;
                if (float.TryParse(tbOrderAmount.Text.Trim(), out tbResultAmountTmp))
                {
                    f_num_total = tbResultAmountTmp;
                }
            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误");
            }

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


            string printWeddingDayLine = string.Format("{0,-20}", "婚期：" + dtpMarryDate.Value.ToString("yyyy-MM-dd")) + string.Format("{0,-30}", "取纱方式:" + qv + " 日期：" + dateTimePicker3.Value.ToString("yyyy-MM-dd"));
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
            e.Graphics.DrawString("来图定制", drawDateFont, drawBrush, 45f, 185f + stepBody);


            //订单金额 310f
            e.Graphics.DrawString("订单金额：￥" + tbOrderAmount.Text.Trim() + "    付款类型：" + comboBox6.Text + "    付款方式：" + comboBox5.Text, drawDateFont, drawBrush, 25f, 310f);


            //计算合计金额
            try
            {

            }
            catch (Exception ef)
            {
                MessageBox.Show("输入错误");
            }
            e.Graphics.DrawString("合计金额：￥" + f_num_total.ToString(), drawDateFont, drawBrush, 25f, 310f + stepBody - 5);
            //                  


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
            coPre.orderAmountPre = "";// tbOrderAmount.Text.Trim();
            coPre.orderAmountafter = "";// tbResultAmount.Text.Trim();
            coPre.orderDiscountRate = "";// tbDiscount.Text.Trim();
            coPre.orderPaymentMethod = "";// comboBox2.Text.Trim();
            coPre.reservedAmount = "";// textBox1.Text.Trim();//定金金额
            coPre.depositAmount = "";// tbDeposit.Text.Trim();//订单押金金额
            coPre.depositPaymentMethod = "";// comboBox3.Text.Trim();
            coPre.totalAmount = f_num_total.ToString();
            coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            coPre.orderStatus = "0";//0 订单进行中，1结束订单  需要在归还页面里设置为1
            coPre.orderType = "来图定制订单";  //0 定金类型，1租赁订单类型 ，2来图定制订单，3来图定制，4来图定制            
            coPre.receptionConsultant = tbJDGW.Text.Trim();


            coPre.shenpiren = "";// comboBox3.Text;
            coPre.gongfei = ""; //textBox1.Text;
            coPre.jiajifei = "";// textBox5.Text;
            coPre.jiachangfei = "";// textBox3.Text;
            coPre.jiakuanfei = "";// textBox4.Text;

        }

        private void setCoPre()
        {
            orderData = "";

            //计算合计金额
            try
            {
                float tbResultAmountTmp = 0.0f;
                if (float.TryParse(tbOrderAmount.Text.Trim(), out tbResultAmountTmp))
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
            coPre.orderAmountPre = f_num_total.ToString();// tbOrderAmount.Text.Trim();
            coPre.orderAmountafter = f_num_total.ToString(); ;// tbResultAmount.Text.Trim();
            coPre.orderDiscountRate = "1";// tbDiscount.Text.Trim();
            coPre.orderPaymentMethod = comboBox5.Text;// comboBox2.Text.Trim();
            coPre.reservedAmount = "";// textBox1.Text.Trim();//定金金额
            coPre.depositAmount = "";// tbDeposit.Text.Trim();//订单押金金额
            coPre.depositPaymentMethod = "";// comboBox3.Text.Trim();
            coPre.totalAmount = f_num_total.ToString();
            coPre.returnAmount = "0"; //退款需要在归还页面里设置为退款金额
            coPre.orderStatus = "店面已提交订单";//店面已提交订单->总部财务已确认收款->工厂已确认接单->工厂已确认发货—>门店已确认收货
            coPre.orderType = "来图定制订单";    //0 定金类型，1租赁订单类型 ，2来图定制订单，3来图定制，4来图定制           
            coPre.receptionConsultant = tbJDGW.Text.Trim();


            coPre.shenpiren = "";// comboBox3.Text;
            coPre.gongfei = "";// textBox1.Text;
            coPre.jiajifei = "";// textBox5.Text;
            coPre.jiachangfei = "";// textBox3.Text;
            coPre.jiakuanfei = "";// textBox4.Text;




        }


        //计算
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                float totalAmount = float.Parse(tbOrderAmount.Text.Trim());

                tbOrderAmount.Text = (totalAmount).ToString();

            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.ToString());
            }
        }




        //将客户的来图定制存储为其他-来图定制里 ，编号是订单号
        private void savaPicLTDZ()
        {

            if (tbBrideID.Text.Trim() == "")
            {
                MessageBox.Show("客户编号不能为空！");
                tbBrideID.Focus();
                return;
            }

            try
            {
                //coPre.orderID订单号 = 婚纱编号
                bool bResult = SaveData.InsertWeddingDressProperties(coPre.orderID, dtpMarryDate.Text.Trim(), "其他","来图定制", "艾慕", "来图", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "False", "来图定制", "60", "60", "是");

                if (bResult)
                {
                    bool bResult2 = saveSizeAndCount(coPre.orderID);
                    bool bResultPic = savePicAll();

                    if (bResult2 && bResultPic)
                    {
                        //MessageBox.Show("保存成功,请继续录入婚纱商品！");
                        //this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("婚纱商品插入失败，请重试！" + ex.ToString());
            }
        }


        private bool savePicAll()
        {
            if (picDataInfo.picPath1 != "")
            {
                savePic(coPre.orderID, "1", picDataInfo.picPath1);
            }
            if (picDataInfo.picPath2 != "")
            {
                savePic(coPre.orderID, "2", picDataInfo.picPath2);
            }
            if (picDataInfo.picPath3 != "")
            {
                savePic(coPre.orderID, "3", picDataInfo.picPath3);
            }
            if (picDataInfo.picPath4 != "")
            {
                savePic(coPre.orderID, "4", picDataInfo.picPath4);
            }
            if (picDataInfo.picPath5 != "")
            {
                savePic(coPre.orderID, "5", picDataInfo.picPath5);
            }
            if (picDataInfo.picPath6 != "")
            {
                savePic(coPre.orderID, "6", picDataInfo.picPath6);
            }
            if (picDataInfo.picPath7 != "")
            {
                savePic(coPre.orderID, "7", picDataInfo.picPath7);
            }
            if (picDataInfo.picPath8 != "")
            {
                savePic(coPre.orderID, "8", picDataInfo.picPath8);
            }
            if (picDataInfo.picPath9 != "")
            {
                savePic(coPre.orderID, "9", picDataInfo.picPath9);
            }

            picDataInfo.picPath1 = "";
            picDataInfo.picPath2 = "";
            picDataInfo.picPath3 = "";
            picDataInfo.picPath4 = "";
            picDataInfo.picPath5 = "";
            picDataInfo.picPath6 = "";
            picDataInfo.picPath7 = "";
            picDataInfo.picPath8 = "";
            picDataInfo.picPath9 = "";

            return true;
        }

        private bool savePic(string wd_id, string picID, string picPath)
        {
            long m_lImageFileLength = 0;
            byte[] m_barrImg;
            FileInfo fiImage = new FileInfo(picPath);
            m_lImageFileLength = fiImage.Length;
            FileStream fs = new FileStream(picPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            m_barrImg = new byte[Convert.ToInt32(m_lImageFileLength)];
            int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(m_lImageFileLength));
            fs.Close();

            SaveData.InsertPicture(wd_id, picID, Path.GetFileName(picPath), m_barrImg);
            return true;
        }

        private bool saveSizeAndCount(string wd_id)
        {
            bool bResult = false;
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XS", "0", "0", "0", 0, wd_id+ "-XS", wd_id + "-XS", 0);
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "S", "0", "0", "0", 0, wd_id + "-S", wd_id + "-S", 0);
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "M", "0", "0", "0", 0, wd_id + "-M", wd_id + "-M", 0);
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "L", "0", "0", "0", 0, wd_id + "-L", wd_id + "-L", 0);
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XL", "0", "0", "0", 0, wd_id + "-XL", wd_id + "-XL", 0);
            SaveData.InsertWeddingDressSizeAndNumber(wd_id, "XXL", "0", "0", "0", 0, wd_id + "-XXL", wd_id + "-XXL", 0);
            bResult = SaveData.InsertWeddingDressSizeAndNumber(wd_id, "LSDZ", "0", "0", "0", 0, wd_id + "-LSDZ", wd_id + "-LSDZ", 0);


            return bResult;
        }




    private bool cleanPicPath()
    {
        picDataInfo.picPath1 = "";
        picDataInfo.picPath2 = "";
        picDataInfo.picPath3 = "";
        picDataInfo.picPath4 = "";
        picDataInfo.picPath5 = "";
        picDataInfo.picPath6 = "";
        picDataInfo.picPath7 = "";
        picDataInfo.picPath8 = "";
        picDataInfo.picPath9 = "";
        return true;
    }

    public void cleanPictureBox()
    {

        if (pictureBox1.Image != null)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }

        if (pictureBox2.Image != null)
        {
            pictureBox2.Image.Dispose();
            pictureBox2.Image = null;
        }

        if (pictureBox3.Image != null)
        {
            pictureBox3.Image.Dispose();
            pictureBox3.Image = null;
        }

        if (pictureBox4.Image != null)
        {
            pictureBox4.Image.Dispose();
            pictureBox4.Image = null;
        }

        if (pictureBox5.Image != null)
        {
            pictureBox5.Image.Dispose();
            pictureBox5.Image = null;
        }

        if (pictureBox6.Image != null)
        {
            pictureBox6.Image.Dispose();
            pictureBox6.Image = null;
        }

        if (pictureBox7.Image != null)
        {
            pictureBox7.Image.Dispose();
            pictureBox7.Image = null;
        }

        if (pictureBox8.Image != null)
        {
            pictureBox8.Image.Dispose();
            pictureBox8.Image = null;
        }

        if (pictureBox9.Image != null)
        {
            pictureBox9.Image.Dispose();
            pictureBox9.Image = null;
        }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath1 = dlg.FileName;
            //SaveData.InsertPicture("","",Path.GetFileName(dlg.FileName), m_barrImg);

        }

        dlg.Dispose();
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }
            pictureBox2.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath2 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
            }
            pictureBox3.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath3 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox4.Image != null)
            {
                pictureBox4.Image.Dispose();
                pictureBox4.Image = null;
            }
            pictureBox4.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath4 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox5.Image != null)
            {
                pictureBox5.Image.Dispose();
                pictureBox5.Image = null;
            }
            pictureBox5.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath5 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox6.Image != null)
            {
                pictureBox6.Image.Dispose();
                pictureBox6.Image = null;
            }
            pictureBox6.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath6 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox7.Image != null)
            {
                pictureBox7.Image.Dispose();
                pictureBox7.Image = null;
            }
            pictureBox7.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath7 = dlg.FileName;
        }

        dlg.Dispose();

    }

    private void pictureBox8_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox8.Image != null)
            {
                pictureBox8.Image.Dispose();
                pictureBox8.Image = null;
            }
            pictureBox8.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath8 = dlg.FileName;
        }

        dlg.Dispose();
    }

    private void pictureBox9_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.Title = "Open Image";
        dlg.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (pictureBox9.Image != null)
            {
                pictureBox9.Image.Dispose();
                pictureBox9.Image = null;
            }
            pictureBox9.Image = new Bitmap(dlg.OpenFile());
            picDataInfo.picPath9 = dlg.FileName;
        }

        dlg.Dispose();
    }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cleanPicPath();
            cleanPictureBox();
        }



        private void OMGivePicCustomization_Load(object sender, EventArgs e)
        {
            this.tbBrideID.Text = Sharevariables.getCustomerID();
            this.tbJDGW.Text = Sharevariables.getLoginOperatorName();
            if (tbBrideID.Text.Trim() != "")
            {
                button4_Click(sender, e);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbOrderAmount.Text = "5000";

            if (comboBox3.Text == "婚纱")
            {
                tbOrderAmount.Text = "8000";
            }

            if (comboBox3.Text == "商品")
            {
                tbOrderAmount.Text = "5000";
            }
        }

        private void isEmptyPics()
        {
            if (picDataInfo.picPath1 != "" || picDataInfo.picPath2 != "" || picDataInfo.picPath3 != "" || picDataInfo.picPath4 != "" || picDataInfo.picPath5 != "" || picDataInfo.picPath6 != "" || picDataInfo.picPath7 != "" || picDataInfo.picPath8 != "" || picDataInfo.picPath9 != "" )
            {

            }


        }

        //成交
        private void button3_Click(object sender, EventArgs e)
        {
            if (tbBrideID.Text.Trim()=="" || tbBrideName.Text=="")
            {
                MessageBox.Show("客户信息不能用空！");
                return;
            }


            if (comboBox3.Text.Trim()=="婚纱" && float.Parse(tbOrderAmount.Text.Trim())<5000)
            {
                MessageBox.Show("提示：来图定制的婚纱价格至少大于5000￥，否则订单不予提交");
                return;
            }

            if (comboBox3.Text.Trim() == "商品" && float.Parse(tbOrderAmount.Text.Trim()) < 3000)
            {
                MessageBox.Show("提示：来图定制的商品价格至少大于3000￥，否则订单不予提交");
                return;
            }


            if (picDataInfo.picPath1 != "" || picDataInfo.picPath2 != "" || picDataInfo.picPath3 != "" || picDataInfo.picPath4 != "" || picDataInfo.picPath5 != "" || picDataInfo.picPath6 != "" || picDataInfo.picPath7 != "" || picDataInfo.picPath8 != "" || picDataInfo.picPath9 != "")
            {
                setCoPre();
                saveCustomerOrder(coPre);
                savaPicLTDZ();//保存来图定制位样品

                this.tbOrderAmount.Enabled = false;
                this.button3.Enabled = false;
                this.button12.Enabled = true;
                //MessageBox.Show("保存成功！");
                //return;
            }
            else
            {
                MessageBox.Show("来图至少多于1张，否则不能生成订单！");
            }
        }

        private void button12_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

            }
            catch (Exception ef)
            {
                MessageBox.Show("请先从试穿列表里选择婚纱商品！" + ef.ToString());
            }


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}