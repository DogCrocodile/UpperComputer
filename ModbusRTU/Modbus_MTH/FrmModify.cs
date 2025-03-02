using MTHProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH
{
    public partial class FrmModify : Form
    {
        public FrmModify(string titleName,string bindVarName,string currentValue)
        {
            InitializeComponent();

            this.lbl_Title.Text = titleName;
            this.bindVarName = bindVarName;
            this.lbl_CurrentValue.Text = currentValue;

            this.txt_SetValue.Focus();
        }

        /// <summary>
        /// 变量标签
        /// </summary>
        private string bindVarName = string.Empty;

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            var result = CommonMethods.CommonWrite(this.bindVarName,this.txt_SetValue.Text.Trim());

            if(result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgBoxWithoutAck("参数修改失败,请检查参数！","参数修改").Show();
            }


        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 无边框拖动
        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void txt_SetValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btn_Sure_Click(null, null);
            }
        }
    }
}
